using Microsoft.EntityFrameworkCore;
using Regista.Application.Repositories;
using Regista.Domain.Dto.ActionModels;
using Regista.Domain.Dto.ResponsibleHelperModels;
using Regista.Domain.Entities;
using Regista.Persistance.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Infasctructure.Repositories
{
    public class RequestRepository : Repository, IRequestRepository
    {
        private readonly RegistaContext context;
        private readonly UnitOfWork uow;
        private readonly SessionModel session;
        public RequestRepository(RegistaContext _context,SessionModel _session, UnitOfWork _uow) : base(_context,_session)
        {
            this.context = _context;
            this.uow = _uow;
            this.session= _session;
        }

        public async Task<string> RequestAdd(Request model)
        {
            try
            {
                //model.CustomerID = session.CustomerID;
                await uow.repository.Add(model);
                await uow.SaveChanges();
                return "";
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public async Task<string> Update(Request model)
        {
            Update(model);
            await uow.SaveChanges();
            return "";
        }
        public void Delete(int id)
        {
            var request = GetNonDeletedAndActive<Request>(t => t.ID == id);
            DeleteRange(request.ToList());

            Delete<Request>(id);
        }
        public async Task<IQueryable<Request>> GetList()
        {
            var model = GetNonDeletedAndActive<Request>(t => true);
            return model;
        }
        public async Task<List<ResponsibleDevextremeSelectListHelper>> GetProject()
        {
            try
            {
                List<ResponsibleDevextremeSelectListHelper> ResponsibleHelpers = new List<ResponsibleDevextremeSelectListHelper>();
                var model = context.Projects
                    .Where(t => true);
                foreach (var item in model)
                {
                    ResponsibleDevextremeSelectListHelper helper = new ResponsibleDevextremeSelectListHelper()
                    {
                        ID = item.ID,
                        Name = item.ProjectName,
                    };
                    ResponsibleHelpers.Add(helper);
                }
                return ResponsibleHelpers;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<ActionDTO>> GetActionDetail(int RequestId)
        {
            return await GetNonDeletedAndActive<Actions>(t => t.RequestID == RequestId).Select(s => new ActionDTO()
            {
                ID = s.ID,
                Description = s.Description,
                EndDate = s.EndDate,
                OpeningDate = s.OpeningDate,
                ResponsibleID = s.ResponsibleID,
                ActionStatus = s.ActionStatus,
                ActionDescription = s.ActionDescription

            }).ToListAsync();
            //return await GetNonDeletedAndActive<Actions>(t => true).Select(s => new ActionDTO()
            //{
            //    ID = s.ID,
            //    Description = s.Description,
            //    EndDate = s.EndDate,
            //    OpeningDate = s.OpeningDate,
            //    ResponsibleID = s.ResponsibleID,
            //    ActionStatus = s.ActionStatus,
            //    ActionDescription = s.ActionDescription
            //}).ToListAsync();
        }
    }
}
