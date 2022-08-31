using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Service.Dtos
{
    public class ResponsePage<T>
    {
        public IEnumerable<T> Result { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }

    }
}
