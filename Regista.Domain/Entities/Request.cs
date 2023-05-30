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
    }
}
