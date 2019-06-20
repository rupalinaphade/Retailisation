using System;
using System.Collections.Generic;
using Retailisation.Model;

namespace Retailisation.Business
{
    public interface IProductJsonBl
    {
        
        IEnumerable<ProductJSON> GetProduct();
        ProductJSON GetProduct(int id);

        IEnumerable<ProductJSON> GetProduct(string desc);
        int PostProduct(ProductJSON objProduct);
    }
}
