using Core2MVCService.Model;
using Core2MVCService.DAL;
using Microsoft.AspNetCore.Hosting;
using WebApplicationUtilities.Configuration;
using System.IO;

namespace Core2MVCService.ApplicantService
{
    public class SaveApplicantDb : ISaveApplicant
    {
        private readonly string _fileLocation;
        private IApplicantRepository _applicantRepository;

        public SaveApplicantDb(IHostingEnvironment environment, IConfigManager configManager, IApplicantRepository applicantRepository)
        {
            _fileLocation = environment.ContentRootPath + configManager.GetFromSection<string>("UploadPath");
            _applicantRepository = applicantRepository;
        }

        public void Save(Applicant applicant)
        {
            _applicantRepository.CreateApplicant(applicant);

            using (var stream = new FileStream(_fileLocation, FileMode.Create))
            {
                applicant.File.CopyTo(stream);
            }
        }
    }
}
