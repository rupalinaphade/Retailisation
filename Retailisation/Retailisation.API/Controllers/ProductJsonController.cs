using Retailisation.Business;
using Retailisation.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Retailisation.API.Controllers
{
    public class ProductJsonController : ApiController
    {
        private IProductJsonBl _productBl;
       
        public ProductJsonController(IProductJsonBl productBl)
        {
            _productBl = productBl;
        }
        [HttpGet]
        public JsonResult<IEnumerable<ProductJSON>> GetProducts()
        {
            
            IEnumerable<ProductJSON> Products = _productBl.GetProduct();
            
           
            return Json(Products);
        }
        [HttpGet]
        public JsonResult<ProductJSON> GetProducts(int id)
        {
            ProductJSON objProduct = _productBl.GetProduct(id);
            if(objProduct == null)
            {
                objProduct = new ProductJSON();
            }
            return Json(objProduct);
        }
        [HttpGet]
        //[Route("api/ProductJson/desc={desc}")]
        public JsonResult<IEnumerable<ProductJSON>> GetProducts(string description)
        {
            IEnumerable<ProductJSON> productlist = _productBl.GetProduct(description);
            
            return Json(productlist);
        }
        public HttpResponseMessage PostProduct([FromBody] ProductJSON objProduct)
        {
            int newprodid = 0;
            if (ModelState.IsValid)
            {
                newprodid = _productBl.PostProduct(objProduct);
            }
            HttpResponseMessage response;
            if (newprodid == 0)
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
