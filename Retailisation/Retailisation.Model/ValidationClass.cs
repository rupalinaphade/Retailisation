using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Retailisation.Model
{
    public class ProductMetadata
    {
        [Required]
        [StringLength(50)]
        public string name { get; set; }
    }

    public class StoreMetadata
    {
        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string country { get; set; }

    }
}

