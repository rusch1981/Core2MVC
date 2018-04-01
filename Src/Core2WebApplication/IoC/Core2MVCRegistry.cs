using StructureMap;
using Core2MVCService.IoC;
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

            RegisterCore2Service();
            RegisterWebApplicationUtilities();
        }

        private void RegisterWebApplicationUtilities()
        {
            For<IEmail>().Use<Email>();
        }

        private void RegisterCore2Service()
        {
            IncludeRegistry<Core2MVCServiceRegistry>();
        }
    }
}
