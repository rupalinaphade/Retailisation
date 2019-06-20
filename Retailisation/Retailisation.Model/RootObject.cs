using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retailisation.Model
{
    public class RootObject
    {
        public List<ProductJSON> products { get; set; }
        public List<StoreJSON> stores { get; set; }
    }
    public class StoreJSON
    {
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        [Required]
        [StringLength(50)]
        public string country { get; set; }
        public List<InventoryJSON> inventory { get; set; }
    }
    public class ProductJSON
    {

        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        public string description { get; set; }
    }
    public class InventoryJSON
    {
        public int product_id { get; set; }
        public int quantity { get; set; }
    }

}
