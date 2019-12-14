using Microsoft.Azure.Search;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Search.Models;
using KMT.API.DAL;
using System;

namespace KMT.API.Controllers
{
    public class SearchController : ApiController
    {
        private SearchRepository searchRepo = new SearchRepository();
        // GET: api/Search
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, searchRepo.Search().Results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
                return response;
            }

            return response;
        }

        // GET: api/Search/5
        public HttpResponseMessage Get(string filter)
        {
            HttpResponseMessage response;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, searchRepo.Search(filter).Results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
                return response;
            }

            return response;
        }
    }
}
