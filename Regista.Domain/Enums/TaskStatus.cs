using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Regista.Domain.Enums
{
    public enum TaskStatus
    {

        [Display(Name = "Başlamadı")]
        NotStart = 0,

        [Display(Name = "Başladı")]
        Start = 1,

        [Display(Name = "Devam Ediyor")]
        Continued = 2,

        [Display(Name = "İptal/Reddedildi")]
        Cancel = 3,
    }
}
