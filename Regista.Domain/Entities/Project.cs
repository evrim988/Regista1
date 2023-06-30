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
        public Project()
        {
            ProjectGuid = Guid.NewGuid();
        }

        [DisplayName("Proje Adı")]
        public string ProjectName { get; set; }

        [DisplayName("Proje Açıklaması")]
        public string ProjectDescription { get; set; }
        public Guid ProjectGuid { get; set; }
        public int RequestID { get; set; }
        public Request Request { get; set; }
        public int TaskID { get; set; }
        public Task Task { get; set; }  
    }
}
