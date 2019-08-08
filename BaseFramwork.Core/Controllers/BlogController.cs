using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseFramwork.Common;
using BaseFramwork.Common.Helper;
using BaseFramwork.Common;
using BaseFramwork.IServices;
using BaseFramwork.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseFramwork.Core.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(Policy = "SystemOrAdmin")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        readonly IAdvertisementServices _advertisementServices;
        readonly IRedisCacheManager _redisCacheManager;

        public BlogController(IAdvertisementServices advertisementServices,IRedisCacheManager redisCacheManager)
        {
            this._advertisementServices = advertisementServices;
            this._redisCacheManager = redisCacheManager;
        }

        // GET: api/Blog
        [HttpGet]
        [Route("ByBlog")]
        public async Task<List<Advertisement>> Get(int id)
        {
            return await _advertisementServices.Query(d=>d.Id==id);
        }


        [HttpGet("GetBlogs")]
        public async Task<List<Advertisement>> GetBlogs()
        {
            //var connect = Appsettings.app(new string[] { "AppSettings", "RedisCaching", "ConnectionString" });//按照层级的顺序，依次写出来

            List<Advertisement> blogArticleList = new List<Advertisement>();

            if (_redisCacheManager.Get<object>("Redis.Blog") != null)
            {
                blogArticleList = _redisCacheManager.Get<List<Advertisement>>("Redis.Blog");
            }
            else
            {
                blogArticleList = await _advertisementServices.Query(d => d.Id == 1);
                _redisCacheManager.Set("Redis.Blog", blogArticleList, TimeSpan.FromHours(2));//缓存2小时
            }


            return await _advertisementServices.GetBlogs();
        }




        // GET: api/Blog/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Blog
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Blog/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}