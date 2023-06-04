using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.Enums
{
    public enum PriorityStatus
    {
        [Display(Name = "Düşük")]
        low =0,
        [Display(Name = "Orta")]
        middle = 1,
        [Display(Name = "Yüksek")]
        high = 2,
    }
}
