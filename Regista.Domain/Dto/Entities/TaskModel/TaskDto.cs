﻿using Regista.Domain.Entities;
using Regista.Domain.Enums;
using Regista.Domain.Dto.ResponsibleHelperModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatus = Regista.Domain.Enums.TaskStatus;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [DisplayName("Bildirim Açıklama")]
        public string TicketContent { get; set; }

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
        public int RequestID { get; set; }
        public string base64 { get; set; }
        public List<SelectListItem> ResponsiblehelperModelList { get; set; }
        public List<SelectListItem> RequestModelList { get; set; }
    }
}
