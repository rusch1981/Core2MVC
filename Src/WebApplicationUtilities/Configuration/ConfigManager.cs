using Microsoft.Extensions.Configuration;

namespace WebApplicationUtilities.Configuration
{
    public class ConfigManager
    {
        private readonly IConfiguration _config;

        public ConfigManager(string settingsFile = "appsettings.json")
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile(settingsFile)
                .Build();
        }

        public T GetFromSection<T>(string section) => _config.GetSection(section)
            .Get<T>();
    }
}
