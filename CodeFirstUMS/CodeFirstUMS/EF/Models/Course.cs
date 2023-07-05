using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirstUMS.EF.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [ForeignKey("Department")]
        public int OfferedBy { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<CourseStudent> Students { get; set; }
        public Course() { 
            Students = new List<CourseStudent>();
        }
    }
}