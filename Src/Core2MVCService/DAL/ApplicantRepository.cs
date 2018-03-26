using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dapper;
using Core2MVCService.Model;
using System.Data.SqlClient;
using WebApplicationUtilities.Configuration;

namespace Core2MVCService.DAL
{
    public class ApplicantRepository : IApplicantRepository
    {
        private const string GetIncompleteApplicantIdsSqlFile = @"Sql/GetIncompleteApplicantIds.sql";
        private const string SetApplicantToCompleteSqlFile = @"Sql/SetApplicantToComplete.sql";
        private const string GetApplicantSqlFile = @"Sql/GetApplicant.sql";
        private readonly string _connectionString;

        public ApplicantRepository(IConfigManager configManager)
        {
            _connectionString = configManager.GetFromSection<string>("ConnectionString");
        }

        public void CreateApplicant(Applicant applicant)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                //called SP on DB
                connection.Execute("dbo.Add_Applicant @Name, @Age, @Email, @AboutYou, @Experience, @SkillsTalents, @FileName", applicant);
            }
        }

        public List<int> GetIncompleteApplicants()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                //get sql string from embedded resource
                var getIncompleteApplicantIdsStatement = ReadEmbeddedResource(GetIncompleteApplicantIdsSqlFile);
                return connection.Query<int>(getIncompleteApplicantIdsStatement).ToList();
            }
        }

        public List<int> SetApplicantToComplete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var getSetApplicantToCompleteSqlFileStatement = ReadEmbeddedResource(SetApplicantToCompleteSqlFile);
                return connection.Query<int>(getSetApplicantToCompleteSqlFileStatement, new { id = id }).ToList();
            }
        }

        public Applicant GetApplicant(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var getGetApplicantSqlFileStatement = ReadEmbeddedResource(GetApplicantSqlFile);
                return connection.Query<Applicant>(getGetApplicantSqlFileStatement, new { id = id }).First();
            }
        }

        private string ReadEmbeddedResource(string resourceName) //todo does this really belong here?  really?
        {
            string content;
            var assembly = typeof(ApplicantRepository).Assembly;
            resourceName = $"{assembly.GetName().Name}.{resourceName.Replace(" ", "_").Replace("\\", ".").Replace("/", ".")}";
            using (var resourceStream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(resourceStream))
                {
                    content = reader.ReadToEnd();
                }
            }
            return content;
        }
    }
}
