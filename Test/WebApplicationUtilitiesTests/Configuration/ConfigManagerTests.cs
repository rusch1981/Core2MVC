using WebApplicationUtilities.Configuration;
using WebApplicationUtilitiesTests.Configuration.Fixtures;
using Xunit;

namespace WebApplicationUtilitiesTests.Configuration
{
    public class ConfigManagerTests
    {
        [Fact(DisplayName = "ConfigManager will get a section from settings file as the specified class")]
        public void ConfigManager_GetFromSection()
        {
            var configMgr = new ConfigManager();
            var config = configMgr.GetFromSection<TestSection>("test");
            Assert.NotNull(config);
            Assert.Equal("value", config.Property);
        }

        [Fact(DisplayName = "ConfigManager will get a section from settings file as the specified class and convert string to Uri")]
        public void ConfigManager_GetFromSection_String_to_Uri()
        {
            var configMgr = new ConfigManager();
            var config = configMgr.GetFromSection<UriConvertSection>("url-convert");
            Assert.NotNull(config);
            Assert.Equal("http://test/", config.Property.AbsoluteUri);
        }
    }
}
