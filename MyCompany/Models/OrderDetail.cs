using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Models
{
    public class OrderDetail
    {
        public long Id { get; set; }
        public Guid OrderID { get; set; }
        public Guid ProductID{ get; set; }
        public uint Cost{ get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product{ get; set; }

    }
}
