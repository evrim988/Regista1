using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Regista.Application.Repositories;
using Regista.Domain.Dto.Entities.CustomerModel;
using Regista.Domain.Entities;
using Regista.Persistance.Db;

namespace Regista1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly RegistaContext _context;
        public CustomerController(IUnitOfWork uow, RegistaContext context)
        {
            _uow = uow;
            _context = context;
        }

        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(_uow.customerRepository.GetList());
        }
        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomer(int ID)
        {
            try
            {
                var currentCustomer = await _uow.customerRepository.GetById<Customer>(ID);

                var model = new CustomerDTO();
                model.Name = currentCustomer.Name;
                model.Surname = currentCustomer.Surname;
                model.Email = currentCustomer.EMail;
                model.Adress = currentCustomer.Adress;
                model.FirmaAdı = currentCustomer.FirmaAdı;
                if (currentCustomer == null)
                    return BadRequest();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
           
        }
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerDTO model)
        {
            try
            {
                var customer = new Customer()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    FirmaAdı = model.FirmaAdı,
                    Adress = model.Adress,
                    EMail = model.Email
                };
                await _uow.customerRepository.CustomerAdd(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult>DeleteCustomer(int ID)
        {
            var currentCustomer = await _uow.customerRepository.Delete<Customer>(ID);

            if(currentCustomer == null)
                return BadRequest("Kullanıcı bulunamadı");
            return Ok();
        }
        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult>UpdateCustomer(int ID)
        {

            return Ok();
        }


    }
}
