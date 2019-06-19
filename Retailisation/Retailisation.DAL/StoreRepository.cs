using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retailisation.Model;

namespace Retailisation.DAL
{
    public class StoreRepository:IStoreRepository
    {
        private RetailisationdbEntities db = new RetailisationdbEntities();
        private readonly IEnumerable<Store> _store;
        public StoreRepository()
        {
            _store = db.Stores;
        }
        public IEnumerable<StoreDTO> GetStore()
        {
            var Storelist = from s in db.Stores
                          select new StoreDTO()
                          {
                              id = s.id,
                              name = s.name,
                              
                              country = s.country
                          };

            return Storelist;

        }

        public Store GetStore(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Stores.Include("Inventories").Where(i => i.id == id).FirstOrDefault();
        }

        public IEnumerable<Store> GetStore(string desc)
        {
            var storeinventory = db.Stores.Include("Inventories").Where(x => x.country.Contains(desc)).ToList();
            //return db.Stores.Include("Inventories").Where(x => x.country.Contains(desc)).ToList();
            return storeinventory
              .Select(c => new Store
              {
                  id = c.id,
                  name = c.name,
                  country = c.country,
                  Inventories = c.Inventories
                                              .Select(r => new Inventory
                                              {
                                                  product_id = r.product_id,
                                                  store_id = r.store_id,
                                                  quantity = r.quantity,
                                                  // other props exclude the 
                                                  // tblCustomerBooking 
                                              }).ToList()
              }
                     ).ToList();
            //var ObjStore = (from s in db.Stores
            //               where s.country.Contains(desc)
            //               select new StoreDTO()
            //               {
            //                   id = s.id,
            //                   name = s.name,
            //                   country = s.country
            //               });

            //return ObjStore;


        }

        public int PostStore(Store objStore)
        {
            int? storeid = _store.Max(storeobj => (int?)storeobj.id) + 1;
            
            if (objStore != null && objStore.name != null)
            {
                objStore.id = (int)storeid;
                db.Stores.Add(objStore);
                db.SaveChanges();
            }
            else
            {
                storeid = 0;
            }

            return (int)storeid;


        }

    }
}
