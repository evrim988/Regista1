using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.Enums
{
    public enum DatabaseChangeStatus
    {
        [Display(Name = "Evet")]
        yes = 0,

        [Display(Name = "Hayır")]
        no = 1, 
    }
}
