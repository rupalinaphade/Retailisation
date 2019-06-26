using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using Retailisation.Business;
using Retailisation.Model;

namespace Retailisation.API.Controllers
{
    public class StoreJsonController : ApiController
    {
        private IStoreJsonBl _storeBl;
        public StoreJsonController(IStoreJsonBl storeBl)
        {
            _storeBl = storeBl;
        }
        // GET: api/Store
        [HttpGet]
        public JsonResult<IEnumerable<StoreJSON>> GetStore()
        {
            IEnumerable<StoreJSON> Stores = _storeBl.GetStore();
            return Json(Stores);
        }
        [HttpGet]
        public JsonResult<StoreJSON> GetStore(int id)
        {
            StoreJSON objStore = _storeBl.GetStore(id);

            return Json(objStore);
        }
        [HttpGet]
        //[Route("api/StoreJson/country={country}")]
        public JsonResult<IEnumerable<StoreJSON>> GetStore(string country)
        {
            IEnumerable<StoreJSON> productlist = _storeBl.GetStore(country);

            return Json(productlist);
        }
        public HttpResponseMessage PostStore(StoreJSON objStore)
        {
            int newprodid = 0;
            if (ModelState.IsValid)
            {
                newprodid = _storeBl.PostStore(objStore);
            }
            HttpResponseMessage response;
            if (newprodid == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "New Store is created");

            }
            return response;

        }
    }
}
