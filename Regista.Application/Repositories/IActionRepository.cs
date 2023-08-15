using Microsoft.AspNetCore.Mvc.Rendering;
using Regista.Domain.Dto.ActionModels;
using Regista.Domain.Dto.Entities.ActionModels;
using Regista.Domain.Dto.ResponsibleHelperModels;
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

        public Task<string> AddActions(Domain.Entities.Action model);
        
        public Task<string> ActionsUpdate(Domain.Entities.Action model);

        public string Delete(int ID);

        public Task<List<SelectListItem>> ResponsiblehelperModelList();

        Task<List<ResponsibleDevextremeSelectListHelper>> GetRequest();
        Task<ActionPageDTO> GetAction(int ID);
    }
}
