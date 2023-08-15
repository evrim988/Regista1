﻿using Regista.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.Entities
{
    public class Action : BaseEntitiy
    {
        [DisplayName("Aksiyon Açıklaması")]
        public string ActionDescription { get; set; }

        [DisplayName("Sorumlu")]
        public int ResponsibleID { get; set; }

        [DisplayName("Açılma Tarihi")]
        public DateTime OpeningDate { get; set; }

        [DisplayName("Son Tarih")]
        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        [DisplayName("Durum")]
        public ActionStatus ActionStatus { get; set; }
        public int RequestID { get; set; }
        public Request Request { get; set; }
    }
}