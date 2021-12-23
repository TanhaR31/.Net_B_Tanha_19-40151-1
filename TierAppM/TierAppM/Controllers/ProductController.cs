using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using BEL;
using System.Web.Http.Cors;

namespace TierAppM.Controllers
{
    [EnableCors("*", "*", "*")] //"kon kon domain theke req accpt korbe", "ki ki header pathate parbe", "ki ki method accpt korbe" 
    public class ProductController : ApiController
    {
        [Route("api/Product/All")]
        [HttpGet]
        public List<ProductVM> GetAll()
        {
            return ProductService.GetAll();
        }

        [Route("api/Product/Names")]
        [HttpGet]
        public List<string> Names()
        {
            return ProductService.GetNames();
        }

        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}