using Regista.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.Entities
{
    public class Request : BaseEntitiy
    {
        [DisplayName("Talep Adı")]
        public string RequestName { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }

        [DisplayName("Kategori")]
        public CategoryStatus CategoryStatus { get; set; }

        [DisplayName("Müşteri Adı")]
        public string CustomerName { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public int ProjectID { get; set; }
        public Project Project { get; set; }   
        public ICollection<Task> Tasks { get; set; }
    }
}
