using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService
    {
        public static List<StudentDTO> GetAll() {
             var data= StudentRepo.GetAll();
             var config = new MapperConfiguration(cfg => {
                 cfg.CreateMap<Student, StudentDTO>();
             });
             var mapper = new Mapper(config);
             var convrtedd = mapper.Map<List<StudentDTO>>(data);
            return convrtedd;
        }
        public static StudentDTO GetByName() {
            var data = (from s in StudentRepo.GetAll()
                       where s.Name.Equals("Tanvir")
                       select s).SingleOrDefault();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentDTO>();
            });
            var mapper = new Mapper(config);
            var convrtedd = mapper.Map<StudentDTO>(data);
            return convrtedd;
        
        }
        public static bool Create(StudentDTO s) {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StudentDTO, Student>();
            });
            var mapper = new Mapper(config);
            var convrtedd = mapper.Map<Student>(s);
            var res =StudentRepo.Create(convrtedd);
            return res;

        }
    }
}
