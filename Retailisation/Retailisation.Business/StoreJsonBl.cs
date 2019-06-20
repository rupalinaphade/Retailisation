using System;
using System.Collections.Generic;
using Retailisation.DAL;
using Retailisation.Model;
namespace Retailisation.Business
{
    public class StoreJsonBl : IStoreJsonBl
    {
        IStoreJsonRepository _storeRepository;
        public StoreJsonBl(IStoreJsonRepository storeRepository)
        {
            _storeRepository = storeRepository;

        }
        public IEnumerable<StoreJSON> GetStore()
        {
            IEnumerable<StoreJSON> storelist;
            storelist = _storeRepository.GetStore();
            return storelist;

        }

        public StoreJSON GetStore(int id)
        {
            StoreJSON ObjStore;
            ObjStore = _storeRepository.GetStore(id);
            if (ObjStore == null)
            {
                ObjStore = new StoreJSON();
            }
            return ObjStore;
        }

        public IEnumerable<StoreJSON> GetStore(string country)
        {
            IEnumerable<StoreJSON> storelist;
            storelist = _storeRepository.GetStore(country);
            return storelist;
        }

        public int PostStore(StoreJSON objStore)
        {
            int storeid;
            storeid = _storeRepository.PostStore(objStore);
            return storeid;
        }
    }
}
