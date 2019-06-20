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
    public class StoreJsonRepository : IStoreJsonRepository
    {
        private string Json = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/productjson.json"));
        public IEnumerable<StoreJSON> GetStore()
        {
            RootObject objlist = JsonConvert.DeserializeObject<RootObject>(Json);
            IEnumerable<StoreJSON> storelist = objlist.stores;

            return storelist;
        }

        public StoreJSON GetStore(int id)
        {
            RootObject objlist = JsonConvert.DeserializeObject<RootObject>(Json);
            var Store = (from p in objlist.stores
                           where p.id == id
                           select new StoreJSON()
                           {
                               id = p.id,
                               name = p.name,
                               country = p.country,
                               inventory =p.inventory
                           }).FirstOrDefault();
            return Store;
        }

        public IEnumerable<StoreJSON> GetStore(string country)
        {
            RootObject objlist = JsonConvert.DeserializeObject<RootObject>(Json);
            var Product = (from p in objlist.stores
                           where p.country.Contains(country)
                           select new StoreJSON()
                           {
                               id = p.id,
                               name = p.name,
                               country = p.country,
                               inventory = p.inventory


                           }); ;
            return Product;
        }

        public int PostStore(StoreJSON objStore)
        {
            RootObject objlist = JsonConvert.DeserializeObject<RootObject>(Json);
            int? storeid = objlist.stores.Max(prod => (int?)prod.id) + 1;
            if (storeid == null)
                storeid = 1;
            objStore.id = (int)storeid;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var jsonFile = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/productjson.json");
            var json = File.ReadAllText(jsonFile);
            var jsonObj = JObject.Parse(json);
            var experienceArrary = jsonObj.GetValue("stores") as JArray;
            var newproductarray = jss.Serialize(objStore);
            var newproduct = JObject.Parse(newproductarray);
            experienceArrary.Add(newproduct);

            jsonObj["stores"] = experienceArrary;
            string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj,
                                   Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFile, newJsonResult);
            return (int)storeid;
        }
    }
}
