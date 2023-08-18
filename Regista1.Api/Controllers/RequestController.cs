using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Regista.Application.Repositories;
using Regista.Application.Services.SecurityServices;
using Regista.Domain.Dto.Entities.RequestModel;
using Regista.Domain.Dto.SecurityModels;
using Regista.Domain.Entities;
using Regista.Domain.Enums;
using Regista.Api.Filters;

namespace Regista.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RequestController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ProjectSessionModel projectSession;

        public RequestController(IUnitOfWork uow, ISessionService sessionService)
        {
            _uow = uow;
            projectSession = sessionService.GetProject();
        }
        [HttpPost("AddRequest")]
        [Auth]
        public async Task<IActionResult> AddRequest(RequestDTO model)
        {
            try
            {
                var request = new Request()
                {
                    RequestSubject = model.RequestName,
                    Description = model.Description,
                    CustomerID = model.CustomerID,
                    ProjectID = projectSession.ID,
                    Category = "Sınıflandırılmamış"
                };

                await _uow.requestRepository.RequestAdd(request);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
