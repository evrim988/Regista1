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
        public int ID { get; set; }

        [DisplayName("Oluşturulma Tarihi")]
        public DateTime? CreatedOn { get; set; }

        [DisplayName("Güncellenme Tarihi")]
        public DateTime? LastModifiedOn { get; set; }

        [DisplayName("Oluşturan Kullanıcı")]
        public int CreatedBy { get; set; }

        [DisplayName("Güncelleyen Kullanıcı")]
        public int LastModifiedBy { get; set; }

        [DisplayName("Silindi Bilgisi")]
        [DefaultValue(0)]
        public ObjectStatus ObjectStatus { get; set; }

        [DisplayName("Durum")]
        [DefaultValue(1)]
        public status Status { get; set; }
    }
}
