using StructureMap;
using Core2MVCService.IoC;
using WebApplicationUtilities.Email;
using WebApplicationUtilities.Configuration;
using Core2MVCService.ApplicantServices;
using Core2MVCService.DAL;
using System;

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
        }

        private void RegisterCore2Service()
        {
            IncludeRegistry<Core2MVCServiceRegistry>();
        }
    }
}
