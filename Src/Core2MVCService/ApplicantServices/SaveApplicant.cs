using Core2MVCService.Models;
using Core2MVCService.DAL;
using Microsoft.AspNetCore.Hosting;
using WebApplicationUtilities.Configuration;
using System.IO;

namespace Core2MVCService.ApplicantServices
{
    public class SaveApplicant : ISaveApplicant
    {
        private readonly string _fileLocation;
        private IApplicantRepository _applicantRepository;

        public SaveApplicant(IHostingEnvironment environment, IConfigManager configManager, IApplicantRepository applicantRepository)
        {
            _fileLocation = environment.ContentRootPath + configManager.GetFromSection<string>("UploadPath");
            _applicantRepository = applicantRepository;
        }

        public void Save(Applicant applicant)
        {
            _applicantRepository.CreateApplicant(applicant);

            //https://blog.mariusschulz.com/2016/05/22/getting-the-web-root-path-and-the-content-root-path-in-asp-net-core
            using (var stream = new FileStream(_fileLocation + applicant.FileName, FileMode.Create))
            {
                applicant.File.CopyTo(stream);
            }
        }
    }
}
