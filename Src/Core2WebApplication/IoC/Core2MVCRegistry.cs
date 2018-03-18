using StructureMap;

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

                //register more stuffs here
            });
        }
    }
}
