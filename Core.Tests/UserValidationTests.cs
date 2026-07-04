using Xunit;
using Викторина.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Викторина.Tests
{
    public class UserTests
    {
        [Fact]
        public void SetRegistrationData_ShouldAssignFieldsCorrectly()
        {
            // Arrange
            var user = new User();
            string firstName = "Иван";
            string lastName = "Иванов";
            string email = "test@mail.com";
            string login = "admin";
            string password = "12345";

            // Act
            user.SetRegistrationData(firstName, lastName, email, login, password);

            // Assert
            Assert.Equal(firstName, user.FirstName);
            Assert.Equal(lastName, user.LastName);
            Assert.Equal(email, user.Email);
            Assert.Equal(login, user.Login);
            Assert.Equal(password, user.Password);
            Assert.True((DateTime.Now - user.RegistrationDate).TotalSeconds < 5);
        }

        [Fact]
        public void ChangePassword_ShouldUpdatePassword_WhenLengthIsValid()
        {
            // Arrange
            var user = new User();
            user.SetRegistrationData("A", "B", "c@d.com", "login", "oldPass");

            // Act
            user.ChangePassword("newSecurePass");

            // Assert
            Assert.Equal("newSecurePass", user.Password);
        }

        [Fact]
        public void ChangePassword_ShouldNotUpdatePassword_WhenTooShort()
        {
            // Arrange
            var user = new User();
            user.SetRegistrationData("A", "B", "c@d.com", "login", "oldPass");

            // Act
            user.ChangePassword("123"); // Слишком короткий

            // Assert
            Assert.Equal("oldPass", user.Password);
        }

        [Fact]
        public void UpdateProfile_ShouldChangeNameAndLastName()
        {
            // Arrange
            var user = new User();
            user.SetRegistrationData("OldName", "OldLast", "e@m.com", "l", "p");

            // Act
            user.UpdateProfile("NewName", "NewLast");

            // Assert
            Assert.Equal("NewName", user.FirstName);
            Assert.Equal("NewLast", user.LastName);
        }
    }
}

