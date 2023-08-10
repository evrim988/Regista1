using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Regista.Application.Repositories;
using Regista.Domain.Dto.Entities.RequestModel;
using Regista.Domain.Dto.Entities.TaskModel;
using Regista.Domain.Entities;

namespace Regista1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public RequestController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpPost("AddRequest")]
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
                    ProjectID = model.ProjectID,
                    CategoryStatus = Regista.Domain.Enums.CategoryStatus.NewFunction,
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
