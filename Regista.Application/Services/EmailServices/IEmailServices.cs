using Regista.Domain.Dto.EmailModels;
using Regista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Application.Services.EmailServices
{
    public interface IEmailServices
    {
        bool Send(EmailSendDto email, Customer UserWhitCustomer);
    }
}
