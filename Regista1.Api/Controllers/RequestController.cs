using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Regista.Application.Repositories;
using Regista.Application.Services.SecurityServices;
using Regista.Domain.Dto.Entities.RequestModel;
using Regista.Domain.Dto.SecurityModels;
using Regista.Domain.Entities;
using Regista.Domain.Enums;
using Regista1.Api.Filters;

namespace Regista1.Api.Controllers
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
                    RequestName = model.RequestName,
                    Description = model.Description,
                    CustomerID = model.CustomerID, 
                    CustomerName = model.CustomerName,
                    ProjectID = projectSession.ID,
                    CategoryStatus = CategoryStatus.NewFunction
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
