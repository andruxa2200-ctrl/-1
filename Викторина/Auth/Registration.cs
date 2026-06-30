using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;



namespace Викторина.Models
{
    public class Registration
    {
        [Key]
        public Guid Id { get; set; }

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

        [Required(ErrorMessage = "Логин обязателен!")]
        [MinLength(1, ErrorMessage = "Логин должно содержать минимум 2 символ!")]
        public string Login { get; set; } 

        public DateTime RegistrationDate { get; set; }
       
        public int Score { get; set; }
        public Registration() 
        {
            Id = Guid.NewGuid();
            FirstName = string.Empty;    
            LastName = string.Empty;     
            Email = string.Empty;        
            Password = string.Empty;     
            RegistrationDate = DateTime.Now;
            Login = string.Empty;
            Score = 0; // баллы 
        }
        
        public Registration(string firstName, string lastName, string email, string password,string login)
        {
            Id = Guid.NewGuid();
            FirstName = firstName ?? string.Empty;
            LastName = lastName ?? string.Empty;
            Email = email ?? string.Empty;
            Password = password ?? string.Empty;
            RegistrationDate = DateTime.Now;
            Login = login ?? string.Empty;
            Score = 0;
        }
    }
}
