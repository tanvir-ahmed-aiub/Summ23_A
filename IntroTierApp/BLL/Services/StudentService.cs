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
        public static dynamic GetAll() {
             return StudentRepo.GetAll();
        }
        public static dynamic GetByName() {
            var data = from s in StudentRepo.GetAll()
                       where s.Name.Equals("Tanvir")
                       select s;
            return data;
        
        }
    }
}
