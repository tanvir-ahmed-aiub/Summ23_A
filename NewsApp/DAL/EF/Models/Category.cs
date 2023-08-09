using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Category 
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<News> News { get; set; }
        public Category() {
            News = new List<News>();
        }
    }
}
