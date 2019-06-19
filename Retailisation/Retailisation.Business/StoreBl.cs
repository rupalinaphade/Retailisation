using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retailisation.DAL;
using Retailisation.Model;
namespace Retailisation.Business
{
    public class StoreBl:IStoreBL
    {
        IStoreRepository _storeRepository;
        public StoreBl(IStoreRepository productRepository)
        {
            _storeRepository = productRepository;

        }
        public IEnumerable<StoreDTO> GetStore()
        {
            IEnumerable<StoreDTO> storelist;
            storelist = _storeRepository.GetStore();
            return storelist;

        }

        public Store GetStore(int id)
        {
            Store ObjStore;
            ObjStore = _storeRepository.GetStore(id);
            if (ObjStore == null)
            {
                ObjStore = new Store();
            }
            return ObjStore;
        }

        public IEnumerable<Store> GetStore(string country)
        {
            IEnumerable<Store> storelist;
            storelist = _storeRepository.GetStore(country);
            return storelist;
        }

        public int PostStore(Store objStore)
        {
            int storeid;
            storeid = _storeRepository.PostStore(objStore);
            return storeid;
        }
    }
}
