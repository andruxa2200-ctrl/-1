﻿﻿﻿﻿﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Викторина.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Имя обязательно!")]
        [MinLength(1, ErrorMessage = "Имя должно содержать минимум 1 символ!")]
        [System.Text.Json.Serialization.JsonInclude]
        public string FirstName { get; private set; }

        [Required(ErrorMessage = "Фамилия обязательна!")]
        [MinLength(1, ErrorMessage = "Фамилия должна содержать минимум 1 символ!")]
        [System.Text.Json.Serialization.JsonInclude]
        public string LastName { get; private set; }

        [Required(ErrorMessage = "Email обязателен!")]
        [EmailAddress(ErrorMessage = "Введите корректный email!")]
        [System.Text.Json.Serialization.JsonInclude]
        public string Email { get; private set; }

        [Required(ErrorMessage = "Пароль обязателен!")]
        [MinLength(4, ErrorMessage = "Пароль слишком короткий (минимум 4 символа)! ")]
        [System.Text.Json.Serialization.JsonInclude]
        public string Password { get; private set; }

        [Required(ErrorMessage = "Логин обязателен!")]
        [MinLength(1, ErrorMessage = "Логин должен содержать минимум 2 символа!")]
        [System.Text.Json.Serialization.JsonInclude]
        public string Login { get; private set; }

        [System.Text.Json.Serialization.JsonInclude]
        public DateTime RegistrationDate { get; private set; }

        [System.Text.Json.Serialization.JsonInclude]
        public List<QuizResult> Results { get; private set; } = new List<QuizResult>();

        public int Score { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Login = string.Empty;
            RegistrationDate = DateTime.Now;
            Results = new List<QuizResult>();
        }

        public void UpdateProfile(string firstName, string lastName)
        {
            if (!string.IsNullOrWhiteSpace(firstName)) FirstName = firstName;
            if (!string.IsNullOrWhiteSpace(lastName)) LastName = lastName;
        }

        public void ChangePassword(string newPassword)
        {
            if (newPassword.Length >= 4) Password = newPassword;
        }

        public void SetRegistrationData(string firstName, string lastName, string email, string login, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Login = login;
            Password = password;
            RegistrationDate = DateTime.Now;
        }
    }
}

