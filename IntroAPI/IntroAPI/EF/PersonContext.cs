using IntroAPI.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IntroAPI.EF
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}