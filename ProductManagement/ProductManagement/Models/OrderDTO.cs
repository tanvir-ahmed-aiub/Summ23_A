using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public System.DateTime Date { get; set; }
        public string Status { get; set; }
    }
}