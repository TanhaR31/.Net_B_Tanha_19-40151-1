using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using BEL;

namespace TierAppM.Controllers
{
    public class CustomerController : ApiController
    {
        [Route("api/Customer/All")]
        [HttpGet]
        public List<CustomerVM> GetAll()
        {
            return CustomerService.GetAll();
        }
    }
}
