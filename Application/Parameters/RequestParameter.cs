using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Parameters
{
    public class RequestParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public RequestParameter()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public RequestParameter(int pagenumber, int pagesize)
        {
            this.PageNumber = pagenumber < 1 ? 1: pagenumber;
            this.PageSize = pagesize > 10 ? 10 : pagesize;
        }
    }
}
