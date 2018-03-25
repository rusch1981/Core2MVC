namespace WebApplicationUtilities.Configuration
{
    public interface IConfigManager
    {
        T GetFromSection<T>(string section);
    }
}
