using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Regista.Application.Repositories;
using Regista.Domain.Dto.ActionModels;
using Regista.Domain.Dto.Entities.ActionModels;
using Regista.Domain.Dto.ResponsibleHelperModels;
using Regista.Domain.Entities;
using Regista.Persistance.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = Regista.Domain.Entities.Action;

namespace Regista.Infasctructure.Repositories
{
    public class ActionRepository : Repository, IActionRepository
    {
        private readonly RegistaContext _context;
        private readonly SessionModel _session;
        private readonly IUnitOfWork _uow;
        public ActionRepository(RegistaContext context, SessionModel session, IUnitOfWork uow) : base(context, session)
        {
            _context = context;
            _session = session;
            _uow = uow;
        }
       

        public async Task<string> ActionsUpdate(Action model)
        {
            try
            {
                Update(model);
                await _uow.SaveChanges();
                return "";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> AddActions(Action model)
        {
            try
            {
                var actions = await GetById<Action>(model.RequestID);
                await _uow.repository.Add(model);
                
                await _uow.SaveChanges();
                return "";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string Delete(int ID)
        {
            var action = GetNonDeletedAndActive((Action t) => t.ID == ID);
            DeleteRange(action.ToList());
            Delete<Action>(ID);
            return "";
        }

        public async Task<ActionPageDTO> GetAction(int ID)
        {
            try
            {
                return await GetNonDeletedAndActive<Action>(t => t.ID == ID).Select(s => new ActionPageDTO
                {
                    ID = s.ID,
                    Reponsible = s.Responsible.Fullname,
                    OpeningDate = s.OpeningDate,
                    EndDate = s.EndDate,
                    Description = s.Description,
                    ActionStatus = s.ActionStatus,
                    RequestID = s.RequestID
                }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public IQueryable<ActionDTO> GetList()
        {
            try
            {
                return GetNonDeletedAndActive<Action>(t => true).Select(s => new ActionDTO()
                {
                    ID = s.ID,
                    Description = s.Description,
                    EndDate = s.EndDate,
                    OpeningDate = s.OpeningDate,
                    ResponsibleID = s.ResponsibleID,
                    ActionStatus = s.ActionStatus,
                    ActionDescription = s.ActionDescription
                });
            }
            catch (Exception e)
            {
                throw e;
            }
           
        }

        public async Task<List<ResponsibleDevextremeSelectListHelper>> GetRequest()
        {
            try
            {
                List<ResponsibleDevextremeSelectListHelper> RequestHelpers = new List<ResponsibleDevextremeSelectListHelper>();
                var model = context.Requests
                    .Where(t => true);
                foreach (var item in model)
                {
                    ResponsibleDevextremeSelectListHelper helper = new ResponsibleDevextremeSelectListHelper()
                    {
                        ID = item.ID,
                        Name = item.RequestSubject,
                    };
                    RequestHelpers.Add(helper);
                }
                return RequestHelpers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SelectListItem>> ResponsiblehelperModelList()
        {
            try
            {
                return GetNonDeletedAndActive<User>(t => true)
                    .Select(s => new SelectListItem { Value = s.ID.ToString(), Text = s.Name + " " +  s.Surname }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
