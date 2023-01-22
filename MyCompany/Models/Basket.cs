using MyCompany.Domain.Entities;

namespace MyCompany.Models
{
    public class Basket
    {
        public int id { get; set; }
        public Product product { get; set; }
        public ushort cost { get; set; }
        public ushort count { get; set; }
        public string BasketInside { get; set; }
    }
}