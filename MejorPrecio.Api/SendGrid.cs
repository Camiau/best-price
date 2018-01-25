// using SendGrid's C# Library
// https://github.com/sendgrid/sendgrid-csharp
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Example
{
    public class Example2
    {
        public void Main()
        {
            Execute().Wait();
        }

        static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("sendGridApiKey");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("gastonh_lu@lagash.com", "GH2");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("harari.gaston@gmail.com", "GH");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}