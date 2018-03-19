namespace WebApplicationUtilities.Models
{
    public class EmailConfig
    {
        public string EmailAccount { get; set; }
        public string ErrorEmailAddress { get; set; }
        public string Credentials { get; set; }
        public string ToEmail { get; set; }
        public string SmtpHost { get; set; }
        public bool EnableSsl { get; set; }
        public int SmtpPort { get; set; }
    }
}