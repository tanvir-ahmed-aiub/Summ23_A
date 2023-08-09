using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Proto
    {
        public int? Created_by { get; set; }
        public int? Updated_by { get; set; }
        public int? Deleted_by { get; set; }
    }
}
