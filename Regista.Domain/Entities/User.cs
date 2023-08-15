using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.Entities
{
    public class User : BaseEntitiy
    {
        [DisplayName("Name")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
        [MaxLength(150, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        public string Name { get; set; }

        [DisplayName("Surname")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
        [MaxLength(150, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        public string Surname { get; set; }

        [DisplayName("Username")]
        public string Username { get; set; }

        public string? Image { get; set; }

        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
        [MaxLength(256, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        [EmailAddress(ErrorMessage = "Geçerli Mail Adresi giriniz")]
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual Customer Customer { get; set; }
        public int CustomerID { get; set; }

    }
}
