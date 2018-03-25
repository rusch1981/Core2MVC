using StructureMap;
using WebApplicationUtilities.Email;
using WebApplicationUtilities.Configuration;
using Core2MVCService.ApplicantService;

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
            For<IConfigManager>().Use<ConfigManager>();
            For<IProcessApplicants>().Use<ProcessApplicantsDb>();
            For<ISaveApplicant>().Use<SaveApplicantDb>();
        }
    }
}
