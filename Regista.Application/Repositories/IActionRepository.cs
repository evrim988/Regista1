using Microsoft.AspNetCore.Mvc.Rendering;
using Regista.Domain.Dto.ActionModels;
using Regista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Regista.Domain.Entities.Task;

namespace Regista.Application.Repositories
{
    public interface IActionRepository
    {
        IQueryable<ActionDTO> GetList();

        public Task<string> AddActions(Actions model);
        
        public Task<string> ActionsUpdate(Actions model);

        Task<string> Delete(int ID);

        public Task<List<SelectListItem>> ResponsiblehelperModelList();
    }
}
