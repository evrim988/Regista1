using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.Enums
{
    public enum ActionStatus
    {
        [Display(Name = "Tamamlanmadı")]
        notCompleted = 0,

        [Display(Name ="Devam Ediyor")]
        Contiuned = 1,

        [Display(Name ="Tamamlandı")]
        Completed = 2,

        [Display(Name = "İptal/Reddedildi")]
        Cancel = 3
    }
}
