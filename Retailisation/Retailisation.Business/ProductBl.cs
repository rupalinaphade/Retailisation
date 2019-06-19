using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retailisation.Model;
using Retailisation.DAL;

namespace Retailisation.Business
{
    public class ProductBl : IProductBL
    {
        IProductRepository _productRepository;
        public ProductBl(IProductRepository productRepository)
        {
            _productRepository = productRepository;
           
        }
        public IEnumerable<ProductDTO> GetProduct()
        {
            IEnumerable<ProductDTO> productlist;
            productlist = _productRepository.GetProduct();
            return productlist;

        }

        public ProductDTO GetProduct(int id)
        {
            ProductDTO ObjProduct;
            ObjProduct = _productRepository.GetProduct(id);
            
            return ObjProduct;
        }

        public IEnumerable<ProductDTO> GetProduct(string desc)
        {
            IEnumerable<ProductDTO> Prodlist;
            Prodlist = _productRepository.GetProduct(desc);
            return Prodlist;
        }

        public int PostProduct(Product objProduct)
        {
            int productid;
            productid = _productRepository.PostProduct(objProduct);
            return productid;
        }
    }
}
