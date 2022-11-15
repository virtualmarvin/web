using Marvin.Web.Code.Exceptions;

namespace Marvin.Web.Tests.Code.Exceptions
{
    public class MultiExceptionTests
    {
        private readonly IFixture _fixture = new Fixture();

        [Fact]
        public void Constructor_WithNoParamater_Instanciates()
        {
            // Arrange

            // Act
            var exception = new MultiException();

            // Assert
            exception.Should().NotBeNull();
            exception.InnerException.Should().BeNull();
            exception.InnerExceptions.Should().NotBeNull()
                .And.HaveCount(0);
        }

        [Fact]
        public void Constructor_WithMessageParamater_Instanciates()
        {
            // Arrange
            var message = _fixture.Create<string>();

            // Act
            var exception = new MultiException(message);

            // Assert
            exception.Should().NotBeNull();
            exception.Message.Should().Be(message);
            exception.InnerException.Should().BeNull();
            exception.InnerExceptions.Should().NotBeNull()
                .And.HaveCount(0);
        }

        [Fact]
        public void Constructor_WithMessageAndInnerExceptionParamater_Instanciates()
        {
            // Arrange
            var message = _fixture.Create<string>();
            var inner = _fixture.Create<ArgumentException>();

            // Act
            var exception = new MultiException(message, inner);

            // Assert
            exception.Should().NotBeNull();
            exception.Message.Should().Be(message);
            exception.InnerException.Should().NotBeNull()
                .And.Be(inner);
            exception.InnerExceptions.Should().NotBeNull()
                .And.HaveCount(1);
        }

        [Fact]
        public void Constructor_WithExceptionEnumerableParamater_Instanciates()
        {
            // Arrange
            var exceptions = _fixture.CreateMany<Exception>();

            // Act
            var exception = new MultiException(exceptions);

            // Assert
            exception.Should().NotBeNull();
            exception.InnerExceptions.Should().NotBeNull()
                .And.HaveCount(exceptions.Count());
        }

        [Fact]
        public void Constructor_WithExceptionArrayParamater_Instanciates()
        {
            // Arrange
            var exceptions = _fixture.CreateMany<Exception>().ToArray();

            // Act
            var exception = new MultiException(exceptions);

            // Assert
            exception.Should().NotBeNull();
            exception.InnerExceptions.Should().NotBeNull()
                .And.HaveCount(exceptions.Length);
        }

        [Fact]
        public void Constructor_WithMessageAndExceptionArrayParamater_Instanciates()
        {
            // Arrange
            var message = _fixture.Create<string>();
            var exceptions = _fixture.CreateMany<Exception>().ToArray();

            // Act
            var exception = new MultiException(message, exceptions);

            // Assert
            exception.Should().NotBeNull();
            exception.Message.Should().Be(message);
            exception.InnerExceptions.Should().NotBeNull()
                .And.HaveCount(exceptions.Length);
        }

        [Fact]
        public void Constructor_WithMessageAndExceptionEnumerableParamater_Instanciates()
        {
            // Arrange
            var message = _fixture.Create<string>();
            var exceptions = _fixture.CreateMany<Exception>();

            // Act
            var exception = new MultiException(message, exceptions);

            // Assert
            exception.Should().NotBeNull();
            exception.Message.Should().Be(message);
            exception.InnerExceptions.Should().NotBeNull()
                .And.HaveCount(exceptions.Count());
        }
    }
}
