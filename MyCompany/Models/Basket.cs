using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Models
{
    public class Basket
    {
        public int id { get; set; }
        public Product product { get; set; }
        public ushort cost { get; set; }
        public ushort count { get; set; }
        public string BasketInside { get; set; }
       // public string idUser { get; set; }
    }
}
