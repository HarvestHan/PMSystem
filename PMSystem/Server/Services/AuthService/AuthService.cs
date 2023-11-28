using Microsoft.IdentityModel.Tokens;
using PMSystem.Server.DataBase;
using PMSystem.Server.Entities;
using PMSystem.Shared;
using PMSystem.Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PMSystem.Server.Services.AuthService
{
    /// <summary>
    /// 身份验证Service
    /// </summary>
    public class AuthService : IAuthService
    {
        private IConfiguration _configuration;
        private UserRepository _repository;
        private IHttpContextAccessor _httpContextAccessor;
        private IMapper _mapper;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="repository"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="mapper"></param>
        public AuthService(IConfiguration configuration,UserRepository repository,IHttpContextAccessor httpContextAccessor , IMapper mapper)
        {
            _configuration = configuration;
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<LoginInfoModel>> GetLoginInfo()
        {
            var response = new ServiceResponse<LoginInfoModel>();
            try
            {
                LoginInfoModel loginInfoModel = new LoginInfoModel();
                loginInfoModel.IP = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();
                loginInfoModel.LoginTime = DateTime.Now;
                response.Success = true;
                response.Data = loginInfoModel;
                response.Message = "获取成功";
            }
            catch (Exception ex) 
            {
                response.Message = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model">传入ChangePasswordModel</param>
        /// <returns></returns>
        public async Task<ServiceResponse<string>> ChangePassword(ChangePasswordModel model)
        {
            var response = new ServiceResponse<string>();
            //数据库查询
            User user = await _repository.GetByIdAsync(GetUserID());

            user.user_password = EncryptPassword(model.Password);

            if (await _repository.UpdateAsync(user))
            {
                response.Success = true;
                response.Message = "修改成功";
            }
            else
            {
                response.Message = "修改失败";
            }
            return response;
        }

        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// <returns>用户ID</returns>
        public int GetUserID() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <returns>用户第一个权限</returns>
        public string GetUserRole() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="usercode"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<string>> Login(string usercode, string password)
        {
            var response = new ServiceResponse<string>();
            //数据库查询
            User user = await _repository.AsQueryable()
                .Where(u => u.user_code == usercode && u.user_password == EncryptPassword(password))
                .Includes(u => u.Roles).SingleAsync();
            if (user is null)
            {
                response.Success = false;
                response.Message = "登录失败,用户名或密码不正确";
            }
            else
            {
                response.Success = true;
                response.Data = CreateToken(user);
                response.Message = "登陆成功";
            }
            return response;
        }
        /// <summary>
        /// 给用户创建Token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                //相当于身份证信息
                new Claim(ClaimTypes.NameIdentifier,user.id.ToString()),
                new Claim(ClaimTypes.Name,user.user_name),
                //new Claim(ClaimTypes.Role,user.Role.RoleType.ToString())
            };
            foreach (var item in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role,item.role_type.ToString()));
            }
            //从配置文件中获取
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                    claims:claims,
                    expires:DateTime.Now.AddDays(7),
                    signingCredentials:creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="rawPassword"></param>
        /// <returns>加密后的字符串</returns>
        public string EncryptPassword(string rawPassword)
        {
            var bytes = System.Text.Encoding.Default.GetBytes(rawPassword);
            var SHA = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            var encryptbytes = SHA.ComputeHash(bytes);
            return Convert.ToBase64String(encryptbytes);
        }
    }
}
