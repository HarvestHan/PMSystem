using log4net.Config;
using log4net.Repository;
using log4net;
using Microsoft.Data.SqlClient;
using OpenXmlPowerTools;

namespace PMSystem.Server.Util
{
    public static class LogHelper
    {
        private static readonly string RepositoryName = "NETCoreRepository";
        private static readonly string ConfigFile = "log4net.config";

        private static ILog RollingLog { get; set; }
        private static ILog ConsoleLog { get; set; }
        private static ILog FileLog { get; set; }
        private static ILoggerRepository repository { get; set; }

        private static ILog SqlLog { get; set; }

        public static void ConfigureLog()
        {
            repository = LogManager.CreateRepository(RepositoryName);
            XmlConfigurator.Configure(repository, new FileInfo(ConfigFile));
            RollingLog = LogManager.GetLogger(RepositoryName, "RollingLog");
            ConsoleLog = LogManager.GetLogger(RepositoryName, "ConsoleLog");
            FileLog = LogManager.GetLogger(RepositoryName, "FileLog");
            SqlLog = LogManager.GetLogger(RepositoryName, "SqlLog");
        }

        public static void Info(object message)
        {
            FileLog.Info(message);
            ConsoleLog.Info(message);
        }

        public static void SqlInfo(string sql, SugarParameter[] pars)
        {
            var message = UtilMethods.GetSqlString(DbType.SqlServer, sql, pars);
            SqlLog.Info(message);
            ConsoleLog.Info(message);
        }
        public static void Error(Exception ex)
        {
            string logMsg = ex.Message;
            RollingLog.Error(logMsg, ex);
            ConsoleLog.Error(logMsg, ex);
        }

        public static void Error(Exception ex, string paramStr)
        {
            string logMsg = $"{ex.Message}\r\nparam：{paramStr}";
            RollingLog.Error(logMsg, ex);
            ConsoleLog.Error(logMsg, ex);
        }
    }
}
