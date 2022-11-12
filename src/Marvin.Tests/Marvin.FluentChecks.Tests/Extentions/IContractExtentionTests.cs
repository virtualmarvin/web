using Marvin.FluentChecks.Exceptions;
using Marvin.FluentChecks.Extensions;

namespace Marvin.FluentChecks.Tests.Extentions
{
    public class IContractExtentionTests
    {
        private readonly IFixture _fixture = new Fixture();

        [Theory]
        [InlineData(null, null, 2)]
        [InlineData(1, null, 1)]
        [InlineData(null, "", 1)]
        [InlineData(1, "", 0)]
        public void ArgNull_WithOptions_ReturnsAsExpected(int? option1, string? option2, int expected)
        {
            var contract = Contract
                .Begin()
                .ArgNull(() => option1)
                .ArgNull(() => option2);

            contract.ExceptionCount.Should().Be(expected);
        }

        [Fact]
        public void ArgNull_WithOption_ReturnsAsExpectedWithName()
        {
            int? option1 = null;

            var contract = Contract
                .Begin()
                .ArgNull(() => option1);

            contract.ExceptionCount.Should().Be(1);
            contract.Exceptions.First().Message.Should().Contain(nameof(option1));
        }

        [Fact]
        public void Check_With2Exceptions_ThrowsMultiExceptionWith2Results()
        {
            // Arrange
            var contract = Contract.Begin();
            var ex1 = _fixture.Create<Exception>();
            var ex2 = _fixture.Create<Exception>();
            contract.AddException(ex1);
            contract.AddException(ex2);

            // Act
            Action action = () => contract.Check();

            // Assert
            action.Should().Throw<ValidationException>()
                .WithInnerExceptionExactly<MultiException>()
                .And.InnerExceptions.Should().HaveCount(2);
            contract.Validated.Should().BeTrue();
        }

        [Fact]
        public void Check_With1Exception_ThrowsValidationException()
        {
            // Arrange
            var contract = Contract.Begin();
            var ex1 = _fixture.Create<ArgumentNullException>();
            contract.AddException(ex1);

            // Act
            Action action = () => contract.Check();

            // Assert
            action.Should().Throw<ValidationException>()
                .WithInnerExceptionExactly<ArgumentNullException>();
            contract.Validated.Should().BeTrue();
        }

        [Fact]
        public void Check_WithNoExceptions_ChecksOk()
        {
            // Arrange

            // Act
            var contract = Contract.Begin();

            // Assert
            contract.Check().Should().BeTrue();
            contract.Validated.Should().BeTrue();
        }
    }
}
