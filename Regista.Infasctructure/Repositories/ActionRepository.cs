using Microsoft.AspNetCore.Mvc.Rendering;
using Regista.Application.Repositories;
using Regista.Domain.Dto.ActionModels;
using Regista.Domain.Entities;
using Regista.Persistance.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
       

        public async Task<string> ActionsUpdate(Actions model)
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

        public async Task<string> AddActions(Actions model)
        {
            try
            {
                var actions = await GetById<Actions>(model.RequestID);
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
            var action = GetNonDeletedAndActive<Actions>(t => t.ID == ID);
            DeleteRange(action.ToList());
            Delete<Actions>(ID);
            return "";
        }

        public IQueryable<ActionDTO> GetList()
        {
            try
            {
                return GetNonDeletedAndActive<Actions>(t => true).Select(s => new ActionDTO()
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
        public async Task<List<SelectListItem>> ResponsiblehelperModelList()
        {
            try
            {
                return GetNonDeletedAndActive<User>(t => true)
                    .Select(s => new SelectListItem { Value = s.ID.ToString(), Text = s.Name + " " +  s.SurName }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
