using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.Enums
{
    public enum CategoryStatus
    {
        [Display(Name = "Sınıflandırılmamış")]
        Unclassified = 0,

        [Display(Name = "Yeni Fonksiyon")]
        NewFunction = 1,

        [Display(Name = "Hata Giderme")]
        Troubleshooting = 2,

        [Display(Name = "Veri Düzenleme")]
        DataEditing = 3,

        [Display(Name = "Uyumluluk")]
        Compatibility = 4,
    }
}
