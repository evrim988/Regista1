using Regista.Domain.Entities;
using Regista.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatus = Regista.Domain.Enums.TaskStatus;

namespace Regista.Domain.Dto.Entities.TaskModel
{
    public class TaskDto
    {
        public int UserID { get; set; }

        [DisplayName("Planlanan Başlangıç Tarihi")]
        public DateTime PlanedStart { get; set; }

        [DisplayName("Planlanan Bitiş Tarihi")]
        public DateTime PlanedEnd { get; set; }

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

        [DisplayName("Görüntü")]
        public string img { get; set; }
        public int CustomerID { get; set; }
    }
}
