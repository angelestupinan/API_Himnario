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
        //For the GetAllHimnos GeT method
        public PagedHimnoSpecification(int pagenumber, int pagesize)
        {
            Query.Skip((pagenumber - 1) * pagesize)
                .Take(pagesize);
        }

        //For the GetHimnoByProperty GET method
        public PagedHimnoSpecification(int number, string name, string lyrics, string type, string clasification, string status)
        {               
            if (!string.IsNullOrEmpty(number.ToString()))
            {
                Query.Search(x => x.Number.ToString(), number.ToString());
            }

            if (!string.IsNullOrEmpty(name))
            {
                Query.Search(x => x.Name, name);
            }

            if (!string.IsNullOrEmpty(lyrics))
            {
                Query.Search(x => x.Lyrics, lyrics);
            }

            if (!string.IsNullOrEmpty(type))
            {
                Query.Search(x => x.Type, type);
            }

            if (!string.IsNullOrEmpty(clasification))
            {
                Query.Search(x => x.Clasification, clasification);
            }

            if (!string.IsNullOrEmpty(status))
            {
                Query.Search(x => x.Status, status);
            }
        }
    }
}
