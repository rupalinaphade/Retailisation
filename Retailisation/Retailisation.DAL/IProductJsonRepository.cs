using System;
using System.Collections.Generic;
using Retailisation.Model;

namespace Retailisation.DAL
{
    public interface IProductJsonRepository
    {

        IEnumerable<ProductJSON> GetProduct();

        ProductJSON GetProduct(int id);
        IEnumerable<ProductJSON> GetProduct(string desc);
        int PostProduct(ProductJSON objProduct);
    }
}
