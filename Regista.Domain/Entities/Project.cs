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
        [DisplayName("ProjeAdı")]
        public string ProjectName { get; set; }
       
        [DisplayName("ProjeAçıklaması")]
        public string ProjectDescription { get; set; }
    }
}
