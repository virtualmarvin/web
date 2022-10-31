using Marvin.FluentChecks.Exceptions;

namespace Marvin.FluentChecks.Tests.Exceptions
{
    public class ExceptionTests
    {
        private readonly IFixture _fixture = new Fixture();

        [Theory]
        [InlineData(typeof(MultiException))]
        [InlineData(typeof(ValidationException))]
        public void Constructor_WithNoParamater_Instanciates(Type exceptionType)
        {
            // Arrange
            var exception = (Exception)Activator.CreateInstance(exceptionType);

            // Act

            // Assert
            exception.Should().NotBeNull();
            exception.InnerException.Should().BeNull();
        }

        [Theory]
        [InlineData(typeof(MultiException))]
        [InlineData(typeof(ValidationException))]
        public void Constructor_WithMessageParamater_Instanciates(Type exceptionType)
        {
            // Arrange
            var message = _fixture.Create<string>();

            // Act
            var exception = (Exception)Activator.CreateInstance(exceptionType, message);

            // Assert
            exception.Should().NotBeNull();
            exception.Message.Should().Be(message);
            exception.InnerException.Should().BeNull();
        }

        [Theory]
        [InlineData(typeof(MultiException))]
        [InlineData(typeof(ValidationException))]
        public void Constructor_WithMessageAndInnerExceptionParamater_Instanciates(Type exceptionType)
        {
            // Arrange
            var message = _fixture.Create<string>();
            var inner = _fixture.Create<ArgumentException>();

            // Act
            var exception = (Exception)Activator.CreateInstance(exceptionType, message, inner);

            // Assert
            exception.Should().NotBeNull();
            exception.Message.Should().Be(message);
            exception.InnerException.Should().NotBeNull()
                .And.Be(inner);
        }

        [Theory]
        [InlineData(typeof(ValidationException))]
        public void Constructor_WithMessageAndNullInnerExceptionParamater_Instanciates(Type exceptionType)
        {
            // Arrange
            var message = _fixture.Create<string>();
            ArgumentException? inner = null;

            // Act
            var exception = (Exception)Activator.CreateInstance(exceptionType, message, inner);

            // Assert
            exception.Should().NotBeNull();
            exception.Message.Should().Be(message);
            exception.InnerException.Should().BeNull();
        }

    }
}
