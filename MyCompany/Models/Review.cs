using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Models
{
    public class Review
    {
        public int id { get; set; }
        public Guid UsertID { get; set; }
        public Guid OrdertID { get; set; }
        public string review { get; set; }
    }
}
