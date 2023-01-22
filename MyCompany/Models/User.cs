using Microsoft.AspNetCore.Identity;
namespace MyCompany.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Adress { get; set; }
    }
}