using Regista.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.Entities
{
    public class Task:BaseEntitiy
    {
        public int UserID { get; set; }
        public virtual User User { get; set; }

        [DisplayName("Planlanan Başlangıç Tarihi")]
        public DateTime PlanedStart { get; set; }

        [DisplayName("Planlanan Bitiş Tarihi")]
        public DateTime PlanedEnd { get; set; }

        [DisplayName("Konu/Başlık")]
        public string title { get; set; }

        [DisplayName("Açıklama")]
        public string description { get; set; }

        [DisplayName("Durum")]
        public Enums.TaskStatus TaskStatus { get; set; }

        [DisplayName("Öncelik")]
        public PriorityStatus PriorityStatus { get; set; }

        [DisplayName("Görüntü")]
        public string img { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
