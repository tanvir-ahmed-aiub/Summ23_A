using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NewsService
    {
        public static List<NewsDTO> Get() {
            var data = DataAccessFactory.NewsDataAccess().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<NewsDTO>>(data);
            return cnvrt;
        }
        public static NewsDTO Get(int id) {
            var data = DataAccessFactory.NewsDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<NewsDTO>(data);
            return cnvrt;
        }
        public static List<NewsDTO> Get(DateTime date) {
            var data = (from n in DataAccessFactory.NewsDataAccess().Get()
                        where n.Date == date
                        select n).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<NewsDTO>>(data);
            return cnvrt;
        }
        public static NewsCategoryDTO GetWithCat(int id) {
            var data = DataAccessFactory.NewsDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<News, NewsCategoryDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<NewsCategoryDTO>(data);
            return cnvrt;
        }
        public static List<NewsDTO> GetByCatName(string name) {
            var data = (from n in DataAccessFactory.NewsDataAccess().Get()
                       where n.Category.Name.ToLower().Contains(name.ToLower())
                       select n).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<NewsDTO>>(data);
            return cnvrt;
        }
        public static List<NewsDTO> GetByCatDate(string cat, DateTime date) {
            var data = (from n in DataAccessFactory.NewsDataAccess().Get()
                        where n.Category.Name.ToLower().Contains(cat.ToLower())
                        && n.Date == date
                        select n).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<NewsDTO>>(data);
            return cnvrt;
        }
    }
}
