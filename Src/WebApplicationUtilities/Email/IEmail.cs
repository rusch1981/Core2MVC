using System;

namespace WebApplicationUtilities.Email
{
    public interface IEmail
    {
        void SendEmail(String message);
        void SendEmail(Exception exception, String message);
        void SendEmail(string subject, string message, string filePath);
    }
}
