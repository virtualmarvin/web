using Marvin.FluentChecks.Exceptions;
using Marvin.FluentChecks.Extensions;

namespace Marvin.FluentChecks.Tests
{
    public class IBusinessExtentionTests
    {
        private readonly IFixture _fixture = new Fixture();

        [Fact]
        public void Check_WithNoError_ReturnsSuccess()
        {
            // Arrange
            var business = Business.Begin();

            // Act
            business.Check();

            // Assert
            business.Success.Should().BeTrue();
        }
    }
}
