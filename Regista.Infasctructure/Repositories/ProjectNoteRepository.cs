using Microsoft.EntityFrameworkCore;
using Regista.Application.Repositories;
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
    public class ProjectNoteRepository : Repository, IProjectNoteRepository
    {
        private readonly RegistaContext registaContext;
        private readonly UnitOfWork uow;
        private readonly SessionModel session;
        public ProjectNoteRepository(RegistaContext _registaContext,SessionModel _session, UnitOfWork _uow) : base(_registaContext,_session)
        {
            this.registaContext = _registaContext;
            this.uow =_uow;
            this.session = _session;
        }

        public async Task<string> ProjectNoteAdd(ProjectNote model)
        {
            try
            {
                await uow.repository.Add(model);
                await uow.SaveChanges();
                return "";
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Delete(int id)
        {
            var project = GetNonDeletedAndActive<ProjectNote>(t => t.ID == id);
            DeleteRange(project.ToList());
            Delete<ProjectNote>(id);
        }

        public async Task<IQueryable<ProjectNote>> GetList()
        {
            var model = GetNonDeletedAndActive<ProjectNote>(t => true);
            return model;
        }
        public async Task<string> Update(Project model)
        {
            Update(model);
            await uow.SaveChanges();
            return "";
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
    }
}
