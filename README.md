# .NET Core 2.0 MVC 

This example Applicant Website was created with NET Core 2.0 MVC.  

## Current Configuration:
* Development and Production Exception Handling
* [Bower](http://weaintplastic.github.io/web-development-field-guide/Development/Frontend_Development/Setting_up_your_project/Setup_Dependency_Managers/Bower/Initialize_Bower_on_a_new_Project.html) client side management
  * additional reading [here](https://docs.microsoft.com/en-us/aspnet/core/client-side/bower)
* Bootstrap css/js
* [StructureMap](http://structuremap.github.io/)
  * additional reading [here](https://tech.io/playgrounds/5099/using-structuremap-with-asp-net-core)
* [Bundling and Minification](https://docs.microsoft.com/en-us/aspnet/core/client-side/bundling-and-minification?tabs=visual-studio%2Caspnetcore2x)
  * additional reading [here](http://rion.io/2016/07/18/bundling-and-minifying-in-asp-net-core-applications/)
* [Logging](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?tabs=aspnetcore2x)
  * Logging is currently set to debug and console via default setting of the [CreateDefaultBuilder()](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.webhost.createdefaultbuilder?view=aspnetcore-2.0)
## Future System Stories:
* Migrate old MVC Code 
  * add missing jQueryfiles to bower.json
  * add all thirdparty files to bundleconfig.json
* Authentication
* Migrate Bower to [Yarn](https://bower.io/blog/2017/how-to-migrate-away-from-bower/)
  * additional reading [here](https://blogs.taiga.nl/martijn/2017/08/02/building-the-minimal-asp-net-core-app-with-webpack-and-npm/#step0)


## Future Feature Stories:
* Dynamically responding form application 
  * Utilize AjaxHelper tags to generate partial views.  