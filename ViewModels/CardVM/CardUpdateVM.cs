using System.ComponentModel.DataAnnotations;

namespace ExamMVC.ViewModels.CardVM
{
    public class CardUpdateVM
    {
        [Required, MaxLength(32), MinLength(3)]
        public string Name { get; set; }
        [Required, MaxLength(64), MinLength(3)]
        public string Description { get; set; }
        [Required, MaxLength(32), MinLength(3)]
        public string Text { get; set; }
        public IFormFile Image { get; set; }
    }
}
