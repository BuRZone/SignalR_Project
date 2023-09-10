using System.ComponentModel.DataAnnotations;

namespace ServiceHub
{
    public class User
    {
        [Required(ErrorMessage = "Введите Имя")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "имя должно быть не менее 3-х и не более 15 символов")]
        public string Name { get; set; }
        public string connectionId { get; set; }
    }
}
