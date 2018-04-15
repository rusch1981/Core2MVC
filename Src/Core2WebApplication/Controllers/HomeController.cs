using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplicationUtilities.Email;
using Core2MVCService.Models;

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

        public ActionResult Application()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Application(Applicant applicant)
        {
            if (!ModelState.IsValid)
            {
                return View(applicant);
            }
            return View("Upload", applicant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(Applicant applicant)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Application");
            }

            return View(applicant);
        }

        public ActionResult Successful()
        {
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
