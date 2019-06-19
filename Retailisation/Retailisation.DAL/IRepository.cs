using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retailisation.Model;
namespace Retailisation.DAL
{
    public interface IRepository<T> where T : DomainObject
    {
        IEnumerable<T> GetAll();

        

        void Save(T element);
    }
    
}
