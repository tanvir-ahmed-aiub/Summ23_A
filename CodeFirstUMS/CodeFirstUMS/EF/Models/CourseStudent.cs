using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirstUMS.EF.Models
{
    public class CourseStudent
    {
        public int Id { get; set; }
        [ForeignKey("Student")]
        public int SId { get; set; }
        [ForeignKey("Course")]
        public int CId { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }

    }

}