using System.ComponentModel.DataAnnotations;

namespace MyCompany.Domain.Entities
{
    public class Product: EntityBase
    {
        [Display(Name = "Стоимость товара за единицу")]
        public ushort cost { get; set; }
        [Display(Name = "Вывести на главный экран для пользователей?")]
        public bool isFavorites { get; set; }
        [Display(Name = "Доступно в данный момент?")]
        public bool available { get; set; }

        [Required(ErrorMessage = "Заполните название услуги")]
        [Display(Name = "Название товара")]
        public override string Title { get; set; }

        [Display(Name = "Краткое описание товара")]
        public override string Subtitle { get; set; }

        [Display(Name = "Полное описание товара")]
        public override string Text { get; set; }

    }
}
