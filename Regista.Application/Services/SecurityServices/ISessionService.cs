using Regista.Domain.Dto.SecurityModels;
using Regista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Application.Services.SecurityServices
{
    public interface ISessionService
    {
        void SetSession<T>(string key, T model);

        T GetSession<T>(string key);

        SessionModel GetUser();

        void SetUser(User user);

        SessionModel GetInjection();

        void CleanSession();

        ProjectSessionModel GetProject();
    }
}
