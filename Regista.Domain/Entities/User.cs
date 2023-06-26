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
        public string SurName { get; set; }

        [DisplayName("UserName")]
        public string UserName { get; set; }

        public string? Image { get; set; }

        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
        [MaxLength(256, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        [EmailAddress(ErrorMessage = "Geçerli mail Adresi giriniz")]
        public string EMail { get; set; }
        public string password { get; set; }
        public virtual Customer Customer { get; set; }
        public int CustomerID { get; set; }

    }
}
