using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.Entities
{
    public class Modules : BaseEntitiy
    {
        [DisplayName("Modül Adı")]
        public string Name { get; set; }

        [DisplayName("Modül Açıklaması")]
        public string Description { get; set; }
        public string Key { get; set; }
    }
}
