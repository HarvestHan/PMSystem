using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Logging;
using System.Net;

namespace PMSystem.Server
{
    public class CustomHandleErrorAttribute:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //1.异常日志记录（正式项目里面一般是用log4net记录异常日志）
            Util.LogHelper.Error(context.Exception);
            base.OnException(context);
        }
    }
}
