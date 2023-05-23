using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.Entities
{
    public class Project : BaseEntitiy
    {
        [DisplayName("ProjectName")]
        public string ProjeAdı { get; set; }

        [DisplayName("ProjectDescription")]
        public string ProjeAçıklaması { get; set; }
    }
}
