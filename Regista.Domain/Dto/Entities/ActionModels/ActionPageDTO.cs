using Regista.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.Dto.Entities.ActionModels
{
    public class ActionPageDTO
    {
        public int ID { get; set; }
        public string Reponsible { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public ActionStatus ActionStatus { get; set; }
        public int RequestID { get; set; }
    }
}
