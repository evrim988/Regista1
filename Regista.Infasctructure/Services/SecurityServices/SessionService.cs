using Microsoft.AspNetCore.Http;
using Regista.Application.Repositories;
using Regista.Application.Services.SecurityServices;
using Regista.Domain.Dto.SecurityModels;
using Regista.Domain.Entities;
using Regista.Domain.Enums;
using Regista.Persistance.Db;
using Registalaser.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Regista.Infasctructure.Services.SecurityServices
{
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly RegistaContext context;

        public SessionService(IHttpContextAccessor _httpContextAccessor, RegistaContext _context)
        {
            this.httpContextAccessor = _httpContextAccessor;
            context = _context;
        }

        public void CleanSession()
        {
            httpContextAccessor.HttpContext.Session.Clear();
        }

        public SessionModel GetInjection()
        {
            var user = new SessionModel();
            user.ID = -1;

            if (httpContextAccessor.HttpContext == null)
            {
                user.ID = -1;
                return user;
            }
            var val = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            if (val != null)
            {
                var val2 = httpContextAccessor.HttpContext.User.FindFirst("CustomerID");

                if (val2 != null)
                    user.CustomerID = Convert.ToInt32(val2.Value);


                if (val != null)
                    user.ID = Convert.ToInt32(val.Value);
            }
            else
            {

                var usr = GetUser();
                if (usr != null)
                    user = usr;
            }
            return user;
        }

        public T GetSession<T>(string key)
        {
            try
            {
                var session = httpContextAccessor.HttpContext.Session;
                byte[] ss;
                var ctry = session.TryGetValue(key, out ss);
                if (!ctry)
                    return default(T);
                if (ss == null)
                    return default(T);
                return FromByteArray<T>(ss);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public SessionModel GetUser()
        {
            return GetSession<SessionModel>("login");
        }

        public void SetSession<T>(string key, T model)
        {
            try
            {
                var ss = ToByteArray<T>(model);
                httpContextAccessor.HttpContext.Session.Set(key, ss);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SetUser(User user)
        {
            try
            {
                var sesionmodel = new SessionModel()
                {
                    CustomerID = user.CustomerID,
                    ID = user.ID,
                    Name = user.Name,
                    Surname = user.SurName
                };
                SetSession("login", sesionmodel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            var stringObj = Encoding.ASCII.GetString(data);
            return JsonSerializer.Deserialize<T>(stringObj);
        }
        public byte[] ToByteArray<T>(T obj)
        {
            var objToString = JsonSerializer.Serialize(obj);
            return Encoding.ASCII.GetBytes(objToString);
        }

        public ProjectSessionModel GetProject()
        {
            try
            {
                var key = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
                return context.Projects.Where(t => t.ProjectGuid.ToString() == key && t.ObjectStatus == ObjectStatus.NonDeleted && t.Status == status.Active).Select(s => new ProjectSessionModel()
                {
                    ID = s.ID,
                    Name = s.ProjectName,

                }).FirstOrDefault();

            }
            catch (Exception)
            {

                throw new UnAuth("Giriş Yapılamadı");
            }

        }
    }
}
