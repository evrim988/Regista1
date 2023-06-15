using Regista.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatus = Regista.Domain.Enums.TaskStatus;

namespace Regista.Domain.Entities
{
    public class Task:BaseEntitiy
    {

        [DisplayName("Planlanan Başlangıç Tarihi")]
        public DateTime PlanedStart { get; set; }

        [DisplayName("Planlanan Bitiş Tarihi")]
        public DateTime PlanedEnd { get; set; }

        [DisplayName("Resim/Ekran Görüntüsü")]
        public string? Image { get; set; }

        [DisplayName("Konu/Başlık")]
        public string title { get; set; }

        [DisplayName("Açıklama")]
        public string description { get; set; }

        [DisplayName("Sorumlu")]
        public int ResponsibleID { get; set; }

        [DisplayName("Durum")]
        public TaskStatus TaskStatus { get; set; }

        [DisplayName("Öncelik")]
        public PriorityStatus PriorityStatus { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
