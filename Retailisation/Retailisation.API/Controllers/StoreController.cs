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
using Retailisation.Business;
using Retailisation.Model;

namespace Retailisation.API.Controllers
{
    public class StoreController : ApiController
    {
        private IStoreBL _storeBl;

        public StoreController(IStoreBL storeBl)
        {
            _storeBl = storeBl;
        }
        // GET: api/Store
        [HttpGet]
        public HttpResponseMessage  GetStore()
        {
            IEnumerable<StoreDTO> Stores= _storeBl.GetStore();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, Stores);
            return response;
         
        }
        [HttpGet]
        public HttpResponseMessage GetStore(int id)
        {
            Store Objstore = _storeBl.GetStore(id);
            HttpResponseMessage response;
            if (Objstore == null)
            {
                Objstore = new Store();
                response = Request.CreateResponse(HttpStatusCode.NotFound, Objstore);

            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, Objstore);
            }
            return response;
           
        }
        [HttpGet]
        [Route("api/Store/country={country}")]
        public HttpResponseMessage  GetStore(string country)
        {
            IEnumerable<Store> storelist = _storeBl.GetStore(country);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, storelist);
            return response;

        }


        public HttpResponseMessage PostStore(Store objStore)
        {
            int newstoreid = 0;
            if (ModelState.IsValid)
            {
                newstoreid = _storeBl.PostStore(objStore); 
            }
            HttpResponseMessage response;
            if (newstoreid == 0)
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