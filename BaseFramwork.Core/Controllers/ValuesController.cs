using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseFramwork.IServices;
using BaseFramwork.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseFramwork.Core.Controllers
{
    /// <summary>
    /// 测试类
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// Get方法
        /// </summary>
        /// <returns></returns>
        // GET api/values
        //[Authorize(Roles ="Admin")]


        readonly IAdvertisementServices _advertisementServices;


        public ValuesController(IAdvertisementServices advertisementServices)
        {
            this._advertisementServices = advertisementServices;
        }



        [HttpGet]
        [Route("Test1")]
        //[Authorize(Roles ="Admin2")]
        public string Get()
        {
            //return new string[] { "value1", "value2" };
            return  _advertisementServices.Query(d => d.Id ==1).Id.ToString();
        }


        /// <summary>
        /// GET方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// POST测试方法
        /// </summary>
        /// <param name="love"></param>
        [HttpPost]
        [Route("api/post")]
        public void Post1(Love love)
        {

        }

        /// <summary>
        /// POST方法
        /// </summary>
        /// <param name="value"></param>
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// PUT方法
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// Delete方法
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
