using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retailisation.Model;
namespace Retailisation.DAL
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private RetailisationdbEntities db = new RetailisationdbEntities();
        private readonly IEnumerable<Product> _product;
        public ProductRepository()
        {
            _product = db.Products;
        }
        public IEnumerable<ProductDTO> GetProduct()
        {
            var Product = from p in db.Products
                        select new ProductDTO()
                        {
                            id = p.id,
                            name = p.name,
                            description = p.description
                        };

            return Product;
           
        }

        public ProductDTO GetProduct(int id)
        {
            var Product = (from p in db.Products
                          where p.id == id
                          select new ProductDTO()
                          {
                              id = p.id,
                              name = p.name,
                              description = p.description
                          }).FirstOrDefault();

            return Product;
        }

        public IEnumerable<ProductDTO> GetProduct(string desc)
        {

            var Product = (from p in db.Products
                           where p.description.Contains(desc)
                           select new ProductDTO()
                           {
                               id = p.id,
                               name = p.name,
                               description = p.description
                           });

            return Product;

            
        }

        public int PostProduct(Product objProduct)
        {
            int? productid = _product.Max(prod => (int?)prod.id)+1;
            if (productid == null)
                productid = 1;
            objProduct.id = (int)productid;
            db.Products.Add(objProduct);
            db.SaveChanges();

            return (int)productid;


        }
    }
}
