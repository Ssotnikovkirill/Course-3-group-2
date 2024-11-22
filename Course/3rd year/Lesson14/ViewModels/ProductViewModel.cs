using System.ComponentModel.DataAnnotations;

namespace ProductViewModel.ViewModels
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "Имя продукта обязательно.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Цена продукта обязательна.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть больше нуля.")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "Количество на складе обязательно.")]
        [Range(0, int.MaxValue, ErrorMessage = "Количество не может быть отрицательным")]
        public int Stock { get; set; }
    }
}