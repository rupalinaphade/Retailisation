using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retailisation.Model;
namespace Retailisation.DAL
{
   public  interface IStoreRepository
    {

        IEnumerable<StoreDTO> GetStore();
        Store GetStore(int id);
        IEnumerable<Store> GetStore(string country);
        int PostStore(Store objStore);
    }
}
