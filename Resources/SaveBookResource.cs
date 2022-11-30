using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_rest.Resources
{
    public class SaveBookResource
    {
        [Required]
        [MaxLength(300)]
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public short Pages { get; set; }
        public double Rating { get; set; }
        public int Count { get; set; }
    }
}
