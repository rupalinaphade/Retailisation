using System;
using System.Collections.Generic;
using Retailisation.Model;

namespace Retailisation.Business
{
    public interface IStoreJsonBl
    {
        IEnumerable<StoreJSON> GetStore();

        StoreJSON GetStore(int id);

        IEnumerable<StoreJSON> GetStore(string desc);
        int PostStore(StoreJSON objStore);
    }
}
