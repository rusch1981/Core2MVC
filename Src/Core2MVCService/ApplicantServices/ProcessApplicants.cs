using Microsoft.AspNetCore.Hosting;
using WebApplicationUtilities.Configuration;
using WebApplicationUtilities.Email;
using Core2MVCService.DAL;
using Core2MVCService.Models;
using System.IO;

namespace Core2MVCService.ApplicantServices
{
    public class ProcessApplicants : IProcessApplicants
    {
        private readonly string _fileLocation;
        private IEmail _emailemail;
        private IApplicantRepository _applicantRepository;

        public ProcessApplicants(IHostingEnvironment environment, IConfigManager configManager, IApplicantRepository applicantRepository, IEmail email)
        {
            _fileLocation = environment.ContentRootPath + configManager.GetFromSection<string>("UploadPath");
            _applicantRepository = applicantRepository;
            _emailemail = email;
        }

        public void ProcessAll()
        {
            var ids = _applicantRepository.GetIncompleteApplicants();

            foreach (var id in ids)
            {
                Applicant applicant = GetApplicant(id);
                _emailemail.SendEmail(GetName_Id(id, applicant), applicant.Message, GetFilePath(applicant));
                File.Delete(GetFilePath(applicant));
                _applicantRepository.SetApplicantToComplete(id);
            }
        }

        private static string GetName_Id(int id, Applicant applicant)
        {
            return applicant.Name + "_" + id;
        }

        private string GetFilePath(Applicant applicant)
        {
            return _fileLocation + applicant.FileName;
        }

        private Applicant GetApplicant(int id)
        {
            return _applicantRepository.GetApplicant(id);
        }
    }
}