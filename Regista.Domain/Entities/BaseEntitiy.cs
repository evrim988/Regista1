using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Regista.Domain.Enums;

namespace Regista.Domain.Entities
{
    public class BaseEntitiy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public DateTime LastModifedBy { get; set; }
        public DateTime LastModifedOn { get; set; }

        [DisplayName("Silindi Bilgisi")]
        public ObjectStatus ObjectStatus { get; set; }

        [DisplayName("Durum")]
        [DefaultValue(1)]
        public status Status { get; set; }
    }
}
