using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Models
{
    public class Category: EntityBase
    {
        public int id { get; set; }
        public string CategoryName { get; set; }
        public string desc { get; set; }
        public List<Product> products { get; set; }
    }
}
