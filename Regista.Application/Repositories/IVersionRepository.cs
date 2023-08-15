using Regista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = Regista.Domain.Entities.Version;

namespace Regista.Application.Repositories
{
    public interface IVersionRepository
    {
        public Task<IQueryable<Version>> GetList();
        public Task<string> AddVersion(Version model);
        public Task<string> UpdateVersion(Version model);
        public string DeleteVersion(int ID);
    }
}
