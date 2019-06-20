using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retailisation.Model;
using Retailisation.DAL;
namespace Retailisation.Business
{
    public class ProductJsonBl : IProductJsonBl
    {
        IProductJsonRepository _productRepository;
        public ProductJsonBl(IProductJsonRepository productRepository)
        {
            _productRepository = productRepository;

        }
        public ProductJSON GetProduct(int id)
        {
            ProductJSON ObjProduct;
            ObjProduct = _productRepository.GetProduct(id);

            return ObjProduct;
        }


        public IEnumerable<ProductJSON> GetProduct(string desc)
        {
            IEnumerable<ProductJSON> Prodlist;
            Prodlist = _productRepository.GetProduct(desc);
            return Prodlist;
        }
        public IEnumerable<ProductJSON> GetProduct()
        {
            IEnumerable<ProductJSON> productlist;
            productlist = _productRepository.GetProduct();
            return productlist;

        }
       

        public int PostProduct(ProductJSON objProduct)
        {
            int productid;
            productid = _productRepository.PostProduct(objProduct);
            return productid;
        }
    }
}
