using Regista.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.Dto.Entities.RequestModel
{
    public class RequestDTO
    {
        public string RequestName { get; set; }
        public string Description { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int ProjectID { get; set; }
        public CategoryStatus CategoryStatus { get; set; }

    }
}
