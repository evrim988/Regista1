using Regista.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Domain.ResponseEntities
{
    public class BaseResponse<T>
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public ResultStatus ResultStatus { get; set; }
        public T ResultObject { get; set; }
        public ICollection<T> ResultObjects { get; set; }
        public string Url { get; set; }
    }
}

