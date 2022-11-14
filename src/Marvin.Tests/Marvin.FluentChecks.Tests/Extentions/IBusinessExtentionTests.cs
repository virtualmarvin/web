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
            business = business.Check();

            // Assert
            business.Success.Should().BeTrue();
        }

        [Theory]
        [InlineData(default(int), true)]
        [InlineData(4, false)]
        public void IsMatch_WithValue_ReturnsExpected(int value, bool expected)
        {
            // Arrange
            var business = Business.Begin();

            // Act
            business = business
                .Param(() => value)
                .IsGreaterThan(2)
                .And()
                .IsLessThan(10);

            // Assert
            business.HasErrors.Should().Be(expected);
        }
    }
}
