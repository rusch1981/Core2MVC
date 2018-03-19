using StructureMap;
using WebApplicationUtilities.Email;

namespace Core2WebApplication.IoC
{
    public class Core2MVCRegistry : Registry
    {
        public Core2MVCRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });

            //register more stuffs here
            For<IEmail>().Singleton().Use<Email>();
        }
    }
}
