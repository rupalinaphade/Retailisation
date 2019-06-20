using System;
using System.Collections.Generic;
using Retailisation.Model;

namespace Retailisation.DAL
{
    public interface IStoreJsonRepository
    {
        IEnumerable<StoreJSON> GetStore();
        StoreJSON GetStore(int id);
        IEnumerable<StoreJSON> GetStore(string country);
        int PostStore(StoreJSON objStore);
    }
}
