using Marvin.FluentChecks.Errors;

namespace Marvin.FluentChecks.Tests.Errors
{
    public class ValidationErrorTests
    {
        private readonly IFixture _fixture = new Fixture();

        [Fact]
        public void Constructor_WithNoParamater_Instanciates()
        {
            // Arrange
            var code = _fixture.Create<string>();
            var message = _fixture.Create<string>();

            // Act
            var record = new ValidationError(code, message);

            // Assert
            record.Should().NotBeNull();
            record.Message.Should().Be(message);
            record.Code.Should().Be(code);
        }
    }
}
