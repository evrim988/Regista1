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
        [DisplayName("TalepAdı")]
        public string RequestName { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }
        public int TaskID { get; set; }
        public Task Task { get; set; }
    }
}
