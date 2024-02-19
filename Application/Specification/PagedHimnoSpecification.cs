using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specification
{
    public class PagedHimnoSpecification : Specification<Himnos>
    {
        public PagedHimnoSpecification(int pagenumber, int pagesize)
        {
            Query.Skip((pagenumber - 1) * pagesize)
                .Take(pagesize);
        }
    }
}
