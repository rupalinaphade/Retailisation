using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retailisation.Model;
namespace Retailisation.Business
{
    public interface IStoreBL
    {
        IEnumerable<StoreDTO> GetStore();

        Store GetStore(int id);

        IEnumerable<Store> GetStore(string desc);
        int PostStore(Store objStore);
    }
}
