using Regista.Domain.Dto.SecurityModels;
using Regista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Application.Repositories
{
    public interface IProjectRepository : IRepository
    {
        public Task<string> AddProject(Project model);
        public void Delete(int id);
        public Task<IQueryable<Project>> GetList();
        ProjectSessionModel GetProjectKey(string key);
    }
}
