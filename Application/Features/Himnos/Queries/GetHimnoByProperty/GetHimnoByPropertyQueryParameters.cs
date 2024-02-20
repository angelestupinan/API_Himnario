using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Himnos.Queries.GetHimnoByProperty
{
    public class GetHimnoByPropertyQueryParameters : RequestParameter
    {
        public int Number { get; set; }

        public string? Name { get; set; }

        public string? Lyrics { get; set; }

        public string? Type { get; set; }

        public string? Clasification { get; set; }

        public string? Status { get; set; }
    }
}
