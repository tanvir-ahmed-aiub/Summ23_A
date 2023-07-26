using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<News,int,bool> NewsDataAccess() {
            return new NewsRepoV2();
        }
        public static IRepo<Category, int, bool> CategoryDataAccess() {
            return new CategoryRepo();
        }
    }
}
