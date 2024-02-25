using System.ComponentModel.DataAnnotations;

namespace ExperimentTask.Models
{
    public class ExperimentResult
    {
        public int Id { get; set; } //унікальний ідентифікатор
        [Required(ErrorMessage = "Поле DeviceToken є обов'язковим.")]
        public string DeviceToken { get; set; } //унікальний ідентифікатор пристрою
        public string Value { get; set; } //буде зберігати значення результат експеременту
        public string ExperimentKey { get; set; } // буде зберігати значення button_color || price
    }
}
