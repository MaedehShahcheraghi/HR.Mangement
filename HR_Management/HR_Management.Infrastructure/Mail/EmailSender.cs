using HR_Management.Application.Contracts.Infrastructure;
using HR_Management.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Infrastructure.Mail
{
    public class EmailSender : IMailSender
    {
        private readonly EmailSetting _EmailSetting;

        public EmailSender(IOptions<EmailSetting> EmailSetting)
        {
            _EmailSetting=EmailSetting.Value;
        }
        public async Task<bool> Send(Email eamil)
        {
            var client = new SendGridClient(_EmailSetting.ApiKey);
            var to = new EmailAddress(eamil.To);
            var from = new EmailAddress()
            {
                Email = _EmailSetting.FromAddress,
                Name = _EmailSetting.FromName
            };
            var message= MailHelper.CreateSingleEmail(from, to, eamil.Subject,eamil.Body,eamil.Body);
            var response=await client.SendEmailAsync(message);
            return response.StatusCode==
                System.Net.HttpStatusCode.OK || response.StatusCode==System.Net.HttpStatusCode.Accepted;
        }
    }
}
