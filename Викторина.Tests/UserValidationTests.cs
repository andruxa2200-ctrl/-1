using Xunit;
using Викторина.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Викторина.Tests
{
    public class UserValidationTests
    {
        [Fact]
        public void ValidUser_ShouldPassValidation()
        {
            // Arrange
            var user = new User();
            user.SetRegistrationData("Иван", "Иванов", "test@example.com", "ivan123", "password123");

            // Act
            var context = new ValidationContext(user);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(user, context, results, true);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void UserWithEmptyFirstName_ShouldFailValidation()
        {
            // Arrange
            var user = new User();
            user.SetRegistrationData("", "Иванов", "test@example.com", "ivan123", "password123");

            // Act
            var context = new ValidationContext(user);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(user, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.MemberNames.Contains("FirstName"));
        }

        [Fact]
        public void UserWithInvalidEmail_ShouldFailValidation()
        {
            // Arrange
            var user = new User();
            user.SetRegistrationData("Иван", "Иванов", "invalid-email", "ivan123", "password123");

            // Act
            var context = new ValidationContext(user);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(user, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.MemberNames.Contains("Email"));
        }
    }
}
