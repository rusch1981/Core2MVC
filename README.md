 .NET Core 2.0 MVC 

This example Applicant Website was created with NET Core 2.0 MVC.  

## Current Configuration:
* [Development and Production Exception Handling](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling)
  * additional reading [here](https://scottsauber.com/2017/04/03/adding-global-error-handling-and-logging-in-asp-net-core/)
* [Bower](http://weaintplastic.github.io/web-development-field-guide/Development/Frontend_Development/Setting_up_your_project/Setup_Dependency_Managers/Bower/Initialize_Bower_on_a_new_Project.html) client side management
  * additional reading [here](https://docs.microsoft.com/en-us/aspnet/core/client-side/bower)
* Bootstrap css/js
* [StructureMap](http://structuremap.github.io/)
  * additional reading [here](https://tech.io/playgrounds/5099/using-structuremap-with-asp-net-core)
* [Bundling and Minification](https://docs.microsoft.com/en-us/aspnet/core/client-side/bundling-and-minification?tabs=visual-studio%2Caspnetcore2x)
  * additional reading [here](http://rion.io/2016/07/18/bundling-and-minifying-in-asp-net-core-applications/)
* [Logging](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?tabs=aspnetcore2x)
  * Logging is currently set to debug and console via default setting of the [CreateDefaultBuilder()](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.webhost.createdefaultbuilder?view=aspnetcore-2.0)
* Migration
  * [WebApplicationUtilities](Src/WebApplicationUtilities/ApplicationUtilities.md):
    * IConfigManager/ConfigManager
    * IEmail/Email
  * [Service Project](Src/Core2MVCService/Core2MVCService.md)
    * Business Logic
      * Implemented [IFormFile](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads) for FileUploads
        * additional reading [here](https://dotnetcoretutorials.com/2017/03/12/uploading-files-asp-net-core/)
    * DAL
      * [Dapper](http://dapper-tutorial.net/dapper)
  * WebContent
      * Third Party JS and CSS Content via bower
      * Site specific JS and CSS content 
  * WebSite
      * Views without Captcha
      * Controller (in process Applicant [Validation](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/validation))

## Future System Stories:
* Migrate old MVC Code 
  * Controller 
  * Missed classes
* Migrate old API Code
* Production Content Environment Helpers - Layout Page
* Client side validation with [tag helpers](https://www.davepaquette.com/archive/2015/05/14/mvc6-validation-tag-helpers-deep-dive.aspx)
* Add Captcha
* Clean up site.cs
* Tests for Services 
* Build Pipeline
* Authentication
* Migrate Bower to [Yarn](https://bower.io/blog/2017/how-to-migrate-away-from-bower/)
  * additional reading [here](https://blogs.taiga.nl/martijn/2017/08/02/building-the-minimal-asp-net-core-app-with-webpack-and-npm/#step0)


## Future Feature Stories:
* Dynamically responding form application 
  * Utilize AjaxHelper tags to generate partial views.  
* Optimize images
* Web Site Face Lift