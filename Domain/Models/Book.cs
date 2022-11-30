using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_rest.Domain.Models
{
        public class Book
        {
            public long ISBN { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Genre { get; set; }
            public string Description { get; set; }
            public short Pages { get; set; }
            public double Rating { get; set; }
            public int Count { get; set; }
        }

}

