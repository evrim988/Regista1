using Microsoft.AspNetCore.Mvc;
using Regista.Application.Repositories;
using Regista.Domain.Dto.Entities.CustomerModel;
using Regista.Domain.Entities;
using Regista.Persistance.Db;

namespace Regista1.Api.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly RegistaContext _context;
        public CustomerController(IUnitOfWork uow,RegistaContext context)
        {
            _uow = uow;
            _context = context; 
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerDTO model)
        {
            try
            {
                var customer = new Customer()
                {
                    Name = model.Name,
                    Surname=model.Surname,
                    FirmaAdı=model.FirmaAdı,
                    Adress=model.Adress,
                    EMail=model.Email
                };

                if (_context.Customers.Any(t => t.Name == model.Name))
                    return Ok("Müşteri Mevcut");
                
                await _uow.customerRepository.CustomerAdd(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
