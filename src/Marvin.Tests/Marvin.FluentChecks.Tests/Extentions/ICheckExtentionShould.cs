using Marvin.FluentChecks.Exceptions;
using Marvin.FluentChecks.Extensions;

namespace Marvin.FluentChecks.Tests.Extentions
{
    public class ICheckExtentionShould
    {
        private readonly IFixture _fixture = new Fixture();

        [Theory]
        [MemberData(nameof(TestData.ContractWorksAsExpectedData), MemberType = typeof(TestData))]
        public void Contract_ReturnsAsExpected(Func<bool> func, Exception exception, bool expected)
        {
            // Arrange
            var check = Check.Start();

            // Act
            check.Contract(func, exception);

            // Assert
            check.Passed.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.BusinessWorksAsExpectedData), MemberType = typeof(TestData))]
        public void Business_ReturnsAsExpected(Func<bool> func, string error, bool expected)
        {
            // Arrange
            var check = Check.Start();

            // Act
            check.Business(func, error);

            // Assert
            check.Passed.Should().Be(expected);
        }

        [Theory, AutoData]
        public void ArgNullContract_PassesWithNonNullArument(string option)
        {
            // Arrange
            var check = Check.Start();

            // Act
            check.ArgNullContract(() => option);

            // Assert
            check.Passed.Should().BeTrue();
        }

        [Fact]
        public void ArgNullContract_AddsArumentNullExceptionWhenArgIsNull()
        {
            // Arrange
            var check = Check.Start();
            string option = null;

            // Act
            check.ArgNullContract(() => option);

            // Assert
            check.Passed.Should().BeFalse();
            check.Exceptions.Should().HaveCount(1);
            check.Exceptions.First().As<ArgumentNullException>().ParamName.Should().Be(nameof(option));
        }

        [Fact]
        public void Validate_With2Exceptions_ThrowsMultiExceptionWith2Results()
        {
            // Arrange
            var check = Check.Start();
            var ex1 = _fixture.Create<Exception>();
            var ex2 = _fixture.Create<Exception>();
            check.AddException(ex1);
            check.AddException(ex2);

            // Act
            Action action = () => check.Validate();

            // Assert
            action.Should().Throw<ValidationException>()
                .WithInnerExceptionExactly<MultiException>()
                .And.InnerExceptions.Should().HaveCount(2);
        }

        [Fact]
        public void Validate_With1Exception_ThrowsValidationException()
        {
            // Arrange
            var check = Check.Start();
            var ex1 = _fixture.Create<ArgumentNullException>();
            check.AddException(ex1);

            // Act
            Action action = () => check.Validate();

            // Assert
            action.Should().Throw<ValidationException>()
                .WithInnerExceptionExactly<ArgumentNullException>();
        }

        [Fact]
        public void Validate_WithNoException_ReturnsAsExpected()
        {
            // Arrange
            var check = Check.Start();

            // Act
            Action action = () => check.Validate();

            // Assert
            action.Should().NotThrow<ValidationException>();
        }
    }
}
