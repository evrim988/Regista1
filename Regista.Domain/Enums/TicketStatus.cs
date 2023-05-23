using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Regista.Domain.Enums
{
    public enum TicketStatus
    {

        [Display(Name = "Değerlendiriliyor")]
        Evaluation = 0,

        [Display(Name = "Başlamadı")]
        NotStart = 1,

        [Display(Name = "Devam Ediyor")]
        Continued = 2,

        [Display(Name = "Tamamlandı")]
        Completed = 3,

        [Display(Name = "İptal")]
        Cancel = 4,
    }
}
