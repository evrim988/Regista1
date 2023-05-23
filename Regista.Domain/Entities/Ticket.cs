using Regista.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.Entities
{
    public class Ticket:BaseEntitiy
    {
        public int UserID { get; set; }
        public virtual User User { get; set; }

        [DisplayName("Durum")]
        public TicketStatus TicketStatus { get; set; }

        [DisplayName("Açıklama/Not")]
        public string? Desc { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
