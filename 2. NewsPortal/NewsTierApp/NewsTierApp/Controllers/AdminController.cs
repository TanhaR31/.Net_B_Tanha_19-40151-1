using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using BEL;

namespace NewsTierApp.Controllers
{
    public class AdminController : ApiController
    {
        [Route("api/admin/news/all")] //shows all news
        [HttpGet]
        public List<NewsVM> GetAllNews()
        {
            return AdminService.GetAllNews();
        }

        [Route("api/admin/news/{id}")] //shows news by id
        [HttpGet]
        public NewsVM GetNewsById(int id)
        {
            return AdminService.GetNewsById(id);
        }

        [Route("api/admin/news")]
        [HttpPost]
        public void PostNews(NewsVM n)
        {
            AdminService.PostNews(n);
        }
    }
}
