using Microsoft.AspNetCore.Mvc.Rendering;
using Regista.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.Dto.ActionModels
{
    public class ActionDTO
    {
        public int ID { get; set; }
        public string ActionDescription { get; set; }
        public int ResponsibleID { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime EndDate { get; set; }
        public ActionStatus ActionStatus { get; set; }
        public string Description { get; set; }
        public string LastModifiedBy { get; set; }
        public List<SelectListItem> ResponsiblehelperModelList { get; set; }
    }
}
