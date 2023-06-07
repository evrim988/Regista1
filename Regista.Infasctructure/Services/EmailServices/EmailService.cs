using Microsoft.AspNetCore.Http;
using Regista.Application.Repositories;
using Regista.Application.Services.EmailServices;
using Regista.Domain.Dto.EmailModels;
using Regista.Domain.Entities;
using Regista.Persistance.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Infasctructure.Services.EmailServices
{
    public class EmailService : IEmailServices
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        private readonly RegistaContext context;

        private readonly SessionModel session;

        private readonly IUnitOfWork uow;
     
        public EmailService(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = httpContextAccessor;
        }

        public bool Send(EmailSendDto email, Customer UserWhitCustomer)
        {
            try
            {
                MailMessage mm = new MailMessage();
                mm.From = new MailAddress(UserWhitCustomer.ContectEmail, "Bildirim Mail");
                mm.To.Add(email.To);
                if (email.CCes != null)
                {
                    foreach (var item in email.CCes)
                    {
                        mm.CC.Add(item);
                    }
                }
                mm.Subject = email.Subject;
                if (!string.IsNullOrEmpty(email.AttachmentUrl))
                {
                    Attachment data = new Attachment(email.AttachmentUrl, MediaTypeNames.Application.Octet);
                    mm.Attachments.Add(data);
                }

                mm.IsBodyHtml = true;
                mm.Body = email.Body;
                SmtpClient smtp = new SmtpClient(UserWhitCustomer.ContectEmail);
                smtp.Host = UserWhitCustomer.EmailHost;
                smtp.Port = Convert.ToInt32(UserWhitCustomer.EmailPort);
                smtp.EnableSsl = UserWhitCustomer.EnableSsl;
                NetworkCredential nc = new NetworkCredential(UserWhitCustomer.ContectEmail, UserWhitCustomer.EmailPassword);//Emaili Gönderen Hesap

                smtp.Credentials = nc;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                System.Security.Cryptography.X509Certificates.X509Chain chain,
                System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };

                smtp.Send(mm);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
