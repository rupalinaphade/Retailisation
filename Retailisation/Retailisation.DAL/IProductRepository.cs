using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retailisation.Model;

namespace Retailisation.DAL
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<ProductDTO> GetProduct();

        ProductDTO GetProduct(int id);
        IEnumerable<ProductDTO> GetProduct(string desc);
        int PostProduct(Product objProduct);
    }
}
