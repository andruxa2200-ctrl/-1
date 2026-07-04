using Xunit;
using Викторина.Data;
using System;

namespace Викторина.Tests
{
    public class SecurityAndDataTests
    {
        [Theory]
        [InlineData("../secret")]
        [InlineData("C:/Windows")]
        [InlineData("test/..")]
        [InlineData("topic.json")]
        public void GetRandomQuestions_ShouldThrowException_OnInvalidTopicKey(string invalidKey)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => QuizDataManager.GetRandomQuestions(invalidKey, 10));
        }

        [Fact]
        public void GetRandomQuestions_ShouldReturnRequestedCount()
        {
            // Arrange
            string topic = "History";
            int requestedCount = 5;

            // Act
            var questions = QuizDataManager.GetRandomQuestions(topic, requestedCount);

            // Assert
            // Если файл существует, должно быть 5. Если нет, создастся 20 и вернется 5.
            Assert.Equal(requestedCount, questions.Count);
        }
    }
}
