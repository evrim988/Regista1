using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.Dto.EmailModels
{
    public class EmailSendDto
    {
        public string Name { get; set; }

        public string To { get; set; }

        public List<string> CCes { get; set; }

        public string Body { get; set; }

        public string Subject { get; set; }

        public string AttachmentUrl { get; set; }
    }
}
