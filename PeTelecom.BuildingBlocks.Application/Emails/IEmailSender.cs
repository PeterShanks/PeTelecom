using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PeTelecom.BuildingBlocks.Application.Emails
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailMessage message);
    }
}
