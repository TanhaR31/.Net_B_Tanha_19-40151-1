using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEL;
using AutoMapper;
using DAL;

namespace BLL
{
    public class AdminService
    {
        public static List<NewsVM> GetAllNews()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Newss, NewsVM>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsVM>>(DataAccessFactory.NewsDataAccess().Get());
            return data;
        }
        public static NewsVM GetNewsById(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Newss, NewsVM>());
            var mapper = new Mapper(config);
            var data = mapper.Map<NewsVM>(DataAccessFactory.NewsDataAccess().Get(id));
            return data;
        }
        public static void PostNews(NewsVM n)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsVM, Newss>());
            var mapper = new Mapper(config);
            var data = mapper.Map<Newss>(n);
            DataAccessFactory.NewsDataAccess().Add(data);
        }
    }
}
