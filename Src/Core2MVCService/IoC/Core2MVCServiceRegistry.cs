using StructureMap;
using WebApplicationUtilities.Email;
using WebApplicationUtilities.Configuration;
using Core2MVCService.ApplicantServices;
using Core2MVCService.DAL;

namespace Core2MVCService.IoC
{
    public class Core2MVCServiceRegistry : Registry
    {
        public Core2MVCServiceRegistry()
        {

            //register more stuffs here
            For<IEmail>().Singleton().Use<Email>();
            For<IConfigManager>().Use<ConfigManager>();
            For<IProcessApplicants>().Use<ProcessApplicantsDb>();
            For<ISaveApplicant>().Use<SaveApplicantDb>();
            For<IApplicantRepository>().Use<ApplicantRepository>();
        }
    }
}
