﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Post
    {
        public int Id { get; set; }
        public  string Title { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public Post() {
            Comments = new List<Comment>();
        }
    }
}
