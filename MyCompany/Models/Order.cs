using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Models
{
    public class Order
    {
        [BindNever]
        public Guid Id { get; set; }
        [Display(Name = "Введите имя")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина имени не менее 3 символов")]
        public string Name { get; set; }
        [Display(Name = "Введите фамилию")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина фамилии не менее 5 символов")]
        public string Surname { get; set; }
        [Display(Name = "Введите адрес")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина адреса не менее 15 символов")]
        public string Adress { get; set; }
        [Display(Name = "Введите свой телефон")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [Required(ErrorMessage = "Длина имени не менее 10 символов")]
        public string Phone { get; set; }
        [Display(Name = "Введите емаил")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина имени не менее 5 символов")]
        public string Email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        [BindNever]
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
