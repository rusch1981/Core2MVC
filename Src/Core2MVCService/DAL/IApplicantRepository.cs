using System;
using System.Collections.Generic;
using System.Text;
using Core2MVCService.Model;

namespace Core2MVCService.DAL
{
    public interface IApplicantRepository
    {
         void CreateApplicant(Applicant applicant);

         List<int> GetIncompleteApplicants();

         List<int> SetApplicantToComplete(int id);

         Applicant GetApplicant(int id);

         string ReadEmbeddedResource(string resourceName);
    }
}
