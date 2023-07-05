using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirstUMS.EF.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [ForeignKey("Dept")]
        public int DeptId { get; set; }
        public virtual Department Dept{ get; set; }
        public virtual ICollection<CourseStudent> Courses { get; set; }
        public Student() {
            Courses = new List<CourseStudent>();
        }
    }
}