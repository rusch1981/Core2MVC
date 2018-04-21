using Microsoft.AspNetCore.Mvc;
using System;
using Core2MVCService.ApplicantServices;
using Core2MVCService.Models;
using WebApplicationUtilities.Email;

namespace Core2WebApplication.Controllers.api
{
    [Route("api/Upload")]
    public class UploadController : Controller
    {
        private readonly ISaveApplicant _saveApplicant;
        private readonly IProcessApplicants _processApplicant;
        private readonly IEmail _emailUtil;

        public UploadController(ISaveApplicant saveApplicant, IProcessApplicants loadApplicants, IEmail emailUtil)
        {
            _saveApplicant = saveApplicant;
            _processApplicant = loadApplicants;
            _emailUtil = emailUtil;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post(Applicant applicant)
        {
            try
            {
                _saveApplicant.Save(applicant);
                _processApplicant.ProcessAll();
            }
            catch (Exception e)
            {
                _emailUtil.SendEmail(e, "Api Error");
            }
        }
    }
}
