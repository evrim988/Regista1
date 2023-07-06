using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.Dto.Entities.CustomerModel
{
    public class CustomerDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FirmaAdı { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
    }
}
