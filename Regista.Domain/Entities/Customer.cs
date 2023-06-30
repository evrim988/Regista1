using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.Entities
{
    public class Customer : BaseEntitiy
    {
        [DisplayName("Name")]
        [StringLength(150)]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
        [MaxLength(150, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        public string Name { get; set; }

        [DisplayName("Surname")]
        [StringLength(150)]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
        [MaxLength(150, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        public string Surname { get; set; }

        [DisplayName("Adress")]
        [StringLength(600)]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
        [MaxLength(600, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        public string? Adress { get; set; }

        public string? ContectEmail { get; set; }

        public string? EmailHost { get; set; }

        public string? EmailPort { get; set; }

        public bool EnableSsl { get; set; }

        public string? EmailPassword { get; set; }

        [DisplayName("FirmaAdı")]
        public string FirmaAdı { get; set; }

        [DisplayName("EMail")]
        public string EMail { get; set; }
        
        public int ProjectNoteID { get; set; }
        public ProjectNote ProjectNote { get; set; }
    }
}
