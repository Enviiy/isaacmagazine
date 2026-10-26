using System.ComponentModel.DataAnnotations;

namespace isaacmagazine.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите логин")]
        [Display(Name = "Логин")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль")]
        [UIHint("password")]
        public string? Password { get; set; }
    }
}