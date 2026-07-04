using Xunit;
using Викторина.Models;
using Викторина.Data;
using System;
using System.Collections.Generic;

namespace Core.Tests
{
    public class CoreLogicTests
    {
        [Fact]
        public void User_Encapsulation_Test()
        {
            // Arrange
            var user = new User();
            
            // Act
            user.SetRegistrationData("Test", "User", "test@test.com", "login", "password");
            user.UpdateProfile("NewName", "NewLast");
            user.ChangePassword("newpassword");

            // Assert
            Assert.Equal("NewName", user.FirstName);
            Assert.Equal("NewLast", user.LastName);
            Assert.Equal("newpassword", user.Password);
        }

        [Fact]
        public void QuizDataManager_PathSecurity_Test()
        {
            // Assert Path Traversal protection
            Assert.Throws<ArgumentException>(() => QuizDataManager.GetRandomQuestions("../illegal", 10));
            Assert.Throws<ArgumentException>(() => QuizDataManager.GetRandomQuestions("C:/Windows", 10));
        }

        [Fact]
        public void QuizDataManager_Randomization_Test()
        {
            // Act
            var questions = QuizDataManager.GetRandomQuestions("Science", 5);

            // Assert
            Assert.Equal(5, questions.Count);
        }

        [Fact]
        public void DefaultData_Generation_Test()
        {
            // Act
            var questions = Test.GetDefaultQuestions("History");

            // Assert
            Assert.Equal(20, questions.Count);
            Assert.All(questions, q => Assert.NotEmpty(q.Text));
            Assert.All(questions, q => Assert.Equal(4, q.Options.Count));
        }
    }
}
