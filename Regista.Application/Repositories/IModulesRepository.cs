using Regista.Domain.Dto.ModulesModels;
using Regista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Application.Repositories
{
    public interface IModulesRepository
    {
        public Task<IQueryable<Modules>> GetModules();
        public Task<string> CreateModules(Modules model);
        public Task<string> UpdatesModules(Modules model);
        public string DeleteModules(int ID);
    }
}
