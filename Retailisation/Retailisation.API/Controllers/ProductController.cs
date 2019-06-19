using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Retailisation.Model;
using Retailisation.Business;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace Retailisation.API.Controllers
{
    public class ProductController : ApiController
    {
        private IProductBL _productBl;

        public ProductController(IProductBL productBl)
        {
            _productBl = productBl;
        }

        [HttpGet]
        public HttpResponseMessage GetProducts()
        {
            IEnumerable<ProductDTO> Products = _productBl.GetProduct();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, Products);
            return response;
        }
        [HttpGet]
        public HttpResponseMessage GetProducts(int id)
        {
           ProductDTO objProduct = _productBl.GetProduct(id);
            HttpResponseMessage response;
            if (objProduct == null)
            {
                objProduct = new ProductDTO();
                response = Request.CreateResponse(HttpStatusCode.NotFound, objProduct);
                
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, objProduct);
            }
            return response;
        }
        [HttpGet]
        [Route("api/Product/desc={desc}")]
        public HttpResponseMessage GetProducts(string desc)
        {
            IEnumerable<ProductDTO> productlist = _productBl.GetProduct(desc);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, productlist);
            return response;
        }

        
        public HttpResponseMessage PostProduct(Product objProduct)
        {
            int newprodid = 0;
            if (ModelState.IsValid)
            {
                newprodid = _productBl.PostProduct(objProduct);
            }
            HttpResponseMessage response;
            if(newprodid == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "New Product is created");

            }
            return response;
            
        }

    }
}
