using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplicationUtilities.Email;

namespace Core2WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IEmail Email { get; }

        public HomeController(ILogger<HomeController> logger, IEmail email)
        {
            _logger = logger;
            Email = email;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Example Log Message");
            return View();
        }

        public IActionResult Exception()
        {
            throw new Exception();
        }

        public IActionResult Error()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if( exceptionFeature != null)
            {
                try
                {
                    _logger.LogError(exceptionFeature.Error, exceptionFeature.Path);
                    Email.SendEmail(exceptionFeature.Error, exceptionFeature.Path);
                }
                catch
                {
                    //well shit!  The show must go on or the view won't return.  
                }
            }
            return View();
        }
    }
}
