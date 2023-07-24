using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class NewsController : ApiController
    {
        [HttpGet]
        [Route("api/news/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = NewsService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            { 
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex.Message);
            }

        }
        [HttpGet]
        [Route("api/news/get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = NewsService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/news/date/{date}")]
        public HttpResponseMessage GetByDate(DateTime date) {
            try
            {
                var data = NewsService.Get(date);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/news/{id}/category")]
        public HttpResponseMessage GetByCat(int id)
        {
            try
            {
                var data = NewsService.GetWithCat(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/news/category/{name}")]
        public HttpResponseMessage GetByCatName(string name)
        {
            try
            {
                var data = NewsService.GetByCatName(name);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/news/category/{cat}/date/{date}")]
        public HttpResponseMessage GetByCatDate(string cat,DateTime date) {
            try
            {
                var data = NewsService.GetByCatDate(cat,date);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
