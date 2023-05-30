using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.Entities
{
    public class ProjectNote : BaseEntitiy
    {
        [DisplayName("Tarih")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [DisplayName("Tür")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        [DataType(DataType.Text)]
        public string NoteType { get; set; }

        [DisplayName("Açıklama")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [DisplayName("NotEkleyenKullanıcı")]
        public string AddUserNote { get; set; }

        public int CustomerID { get; set; }
    }
}
