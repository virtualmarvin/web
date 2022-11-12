using Marvin.FluentChecks.Exceptions;
using Marvin.FluentChecks.Extensions;

namespace Marvin.FluentChecks.Tests
{
    public class ContractTests
    {
        [Fact]
        public void Contract_Begin_CreatesClass()
        {
            // Arrange

            // Act
            var contract = Contract.Begin();

            // Assert
            contract.Should().NotBeNull();
            contract.Should().BeAssignableTo<IContract>();
        }

        [Theory]
        [InlineData(null, 1)]
        [InlineData("", 0)]
        [InlineData("Data", 0)]
        public void Contract_ArgNull_ValidatesAsExpected(string? option, int expected)
        {
            // Arrange
            var contract = Contract.Begin();

            // Act
            contract.ArgNull(() => option);

            // Assert
            contract.Exceptions.Should().HaveCount(expected);
        }

        [Fact]
        public void Contract_ArgNull_HasArgNullException()
        {
            // Arrange
            var contract = Contract.Begin();
            string? option = null;

            // Act
            contract.ArgNull(() => option);

            // Assert
            contract.Exceptions.First().Should().BeAssignableTo<ArgumentNullException>();
            contract.Exceptions.First().As<ArgumentNullException>()
                .ParamName.Should().Be(nameof(option));
        }

        [Fact]
        public void Contract_CheckWithException_ThrowsException()
        {
            // Arrange
            string? option = null;
            var contract = Contract.Begin().ArgNull(() => option);

            // Act
            Action action = () => contract.Check();

            // Assert
            action.Should().ThrowExactly<ValidationException>()
                .WithInnerException<ArgumentNullException>();
            contract.Validated.Should().BeTrue();
        }

        [Fact]
        public void Contract_CheckWithMultipuleExceptions_ThrowsException()
        {
            // Arrange
            string? option1 = null;
            string? option2 = null;
            var contract = Contract.Begin().ArgNull(() => option1).ArgNull(() => option2);

            // Act
            Action action = () => contract.Check();

            // Assert
            action.Should().ThrowExactly<ValidationException>()
                .WithInnerException<MultiException>();
            contract.Validated.Should().BeTrue();
        }

        [Fact]
        public void Contract_CheckWithoutException_ReturnsAsExpected()
        {
            // Arrange
            var option = Guid.NewGuid().ToString();
            var contract = Contract.Begin().ArgNull(() => option);

            // Act
            Action action = () => contract.Check();

            // Assert
            action.Should().NotThrow();
            contract.Validated.Should().BeTrue();
        }
    }
}
