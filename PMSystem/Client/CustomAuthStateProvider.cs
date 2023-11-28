using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace PMSystem.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private ILocalStorageService _localStorageService;
        private HttpClient _httpClient;
        public CustomAuthStateProvider(ILocalStorageService localStorageService,HttpClient httpClient)
        {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
        }
        /// <summary>
        /// 登录后授权
        /// </summary>
        /// <returns></returns>
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //从本地缓存获取authToken
            string authToken = await _localStorageService.GetItemAsStringAsync("authToken");

            var identity = new ClaimsIdentity();
            _httpClient.DefaultRequestHeaders.Authorization = null;

            //authToken不为空,登录过
            if (!string.IsNullOrEmpty(authToken))
            {
                try
                {
                    //不为空，在HttpClient请求头中加入Bearer authToken,之后请求都会带着这个Bearer
                    //identity存用户身份信息，如ID、权限
                    IEnumerable<Claim> claims = NewParseClaimsFromJwt(authToken);
                    identity = new ClaimsIdentity(claims,"jwt");
                    //判断是否过期
                    Claim expClaim = claims.Where(c => c.Type == "exp").FirstOrDefault();
                    if (expClaim is not null)
                    {
                        long timestamp = long.Parse(expClaim.Value);
                        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));//当地时区
                        var time = startTime.AddSeconds(timestamp);
                        //过期抛出异常,进入catch
                        if (time < DateTime.Now)
                            throw new Exception();
                    }

                    _httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", authToken.Replace("\"", ""));
                }
                //报错，或者token过期了
                catch
                {
                    //从缓存中移除Token
                    await _localStorageService.RemoveItemAsync("authToken");
                    identity = new ClaimsIdentity();
                }
            }

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }
        /// <summary>
        /// 将jwt转为byte[]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        byte[] Decode(string input)
        {
            var output = input;
            output = output.Replace('-', '+'); // 62nd char of encoding
            output = output.Replace('_', '/'); // 63rd char of encoding
            switch (output.Length % 4) // Pad with trailing '='s
            {
                case 0: break; // No pad chars in this case
                case 2: output += "=="; break; // Two pad chars
                case 3: output += "="; break; // One pad char
                default: throw new System.ArgumentOutOfRangeException("input", "Illegal base64url string!");
            }
            var converted = Convert.FromBase64String(output); // Standard base64 decoder
            return converted;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2:base64 += "==";break;
                case 3:base64 += "=";break;  
            }
            return Convert.FromBase64String(base64);
        }
        /// <summary>
        /// 从jwt中解析用户身份信息
        /// </summary>
        /// <param name="jwt"></param>
        /// <returns></returns>
        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            //var jsonBytes = ParseBase64WithoutPadding(payload);
            var jsonBytes = Encoding.UTF8.GetString(
            this.Decode(payload));
            var keyValuePairs =
                JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            var claims = keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
            return claims;
        }

        private IEnumerable<Claim> NewParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            //var jsonBytes = ParseBase64WithoutPadding(payload);
            var jsonBytes = Encoding.UTF8.GetString(
                this.Decode(payload));
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

    }
}
