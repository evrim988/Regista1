using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.Dto.Entities.UserModel
{
    public class UserDetailDto
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
        public string Parola { get; set; }
        public string Email { get; set; }
    }
}
