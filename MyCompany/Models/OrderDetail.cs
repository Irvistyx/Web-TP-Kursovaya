using MyCompany.Domain.Entities;
using System;

namespace MyCompany.Models
{
    public class OrderDetail
    {
        public long id { get; set; }
        public Guid OrderID { get; set; }
        public Guid ProductID{ get; set; }
        public uint Cost{ get; set; }
        public uint Count { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product{ get; set; }
    }
}
