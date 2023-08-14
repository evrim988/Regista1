using Microsoft.AspNetCore.Mvc.Rendering;
using Regista.Domain.Dto.ActionModels;
using Regista.Domain.Dto.ResponsibleHelperModels;
using Regista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Application.Repositories
{
    public interface IRequestRepository : IRepository
    {
        public Task<string> RequestAdd(Request request);
        public void Delete(int id);
        public Task<IQueryable<Request>> GetList();
        Task<List<ResponsibleDevextremeSelectListHelper>> GetProject();
        Task<List<ResponsibleDevextremeSelectListHelper>> GetCustomer();
        public Task<List<ResponsibleDevextremeSelectListHelper>> GetModuleSelect();
        Task<List<ActionDTO>> GetActionDetail(int RequestId);
        public Task<List<SelectListItem>> NotificationTypeSelectList();
        public Task<List<SelectListItem>> CategorySelectList();
    }
}
