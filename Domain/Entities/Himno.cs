using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Himno
    {

        public int Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public string Lyrics { get; set; }

        public string Type { get; set; }

        public string Clasification { get; set; }

        public string Status { get; set; }

    }
}
