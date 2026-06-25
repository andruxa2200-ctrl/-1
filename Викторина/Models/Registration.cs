using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Викторина.Models;

namespace Викторина.Models
{
    public class Registration
    {
        [Required(ErrorMessage = "Имя обязательно!")]
        [MinLength(1, ErrorMessage = "Имя должно содержать минимум 1 символ!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилия обязателенo!")]
        [MinLength(1, ErrorMessage = "Фамилия должно содержать минимум 1 символ!")]
        public string LastName { get; set; } 

        [Required(ErrorMessage = "Email обязателен!")]
        [EmailAddress(ErrorMessage = "Введите корректный email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль обязателен!")]
        [MinLength(4, ErrorMessage = "Пароль слишком короткий (минимум 4 символа)!")]
        public string Password { get; set; }

        public int Score { get; set; }

        public DateTime RegistrationDate { get; set; }

        public Registration()
        {
            RegistrationDate = DateTime.Now;
        }
    }
}
