using Regista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Application.Repositories
{
    public interface IProjectNoteRepository : IRepository
    {
        public Task<string> ProjectNoteAdd(ProjectNote projectNote);
        public void Delete(int id);
        public Task<IQueryable<ProjectNote>> GetList();
    }
}
