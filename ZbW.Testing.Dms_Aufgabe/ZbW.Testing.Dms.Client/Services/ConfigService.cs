using System.Configuration;

namespace ZbW.Testing.Dms.Client.Services
{
    public static class ConfigService
    {
        public static string GetConfigValueByKey(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
