using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Retailisation.Model;

namespace Retailisation.DAL
{
    public class ProductJsonRepository : IProductJsonRepository
    {

        private string Json = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/productjson.json"));
        public IEnumerable<ProductJSON> GetProduct()
        {
            
            RootObject objlist = JsonConvert.DeserializeObject<RootObject>(Json);
            IEnumerable<ProductJSON> productlist = objlist.products;

            return productlist;

        }

        public ProductJSON GetProduct(int id)
        {
           
            RootObject objlist = JsonConvert.DeserializeObject<RootObject>(Json);
            
            var Product = (from p in objlist.products
                           where p.id == id
                           select new ProductJSON()
                           {
                               id = p.id,
                               name = p.name,
                               description = p.description
                           }).FirstOrDefault();
            return Product;
        }

        public IEnumerable<ProductJSON> GetProduct(string desc)
        {
            
            RootObject objlist = JsonConvert.DeserializeObject<RootObject>(Json);
            var Product = (from p in objlist.products
                           where p.description.Contains(desc)
                           select new ProductJSON()
                           {
                               id = p.id,
                               name = p.name,
                               description = p.description
                           });
            return Product;
        }
       

        public int PostProduct( ProductJSON objProduct)
        {
            RootObject objlist = JsonConvert.DeserializeObject<RootObject>(Json);
            int? productid = objlist.products.Max(prod => (int?)prod.id) + 1;
            if (productid == null)
                productid = 1;
            objProduct.id = (int)productid;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var jsonFile = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/productjson.json"); 
            var json = File.ReadAllText(jsonFile);
            var jsonObj = JObject.Parse(json);
            var experienceArrary = jsonObj.GetValue("products") as JArray;
            var newproductarray = jss.Serialize(objProduct);
            var newproduct = JObject.Parse(newproductarray);
            experienceArrary.Add(newproduct);

            jsonObj["products"] = experienceArrary;
            string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj,
                                   Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFile, newJsonResult);
            return (int)productid;
            //throw new NotImplementedException();
        }
    }
}
