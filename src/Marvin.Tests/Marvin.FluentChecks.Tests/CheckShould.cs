using Marvin.FluentChecks.Extensions;

namespace Marvin.FluentChecks.Tests
{
    public class CheckShould
    {
        [Fact]
        public void Instanciates_OnStart()
        {
            // Arrange

            // Act
            Action action = () => _ = Check.Start();

            // Assert
            action.Should().NotThrow();
        }

        [Fact]
        public void Instanciate_WithoutNullProperties()
        {
            // Arrange

            // Act
            var check = Check.Start();

            // Assert
            check.Passed.Should().BeTrue();
            check.Errors.Should().NotBeNull();
            check.Exceptions.Should().NotBeNull();
        }

        [Theory, AutoData]
        public void AddError(string error)
        {
            // Arrange
            var check = Check.Start();

            // Act
            check.AddError(error);

            // Assert
            check.Errors.Should().HaveCount(1);
            check.Errors.Should().Contain(error);
        }

        [Theory, AutoData]
        public void AddException(Exception exception)
        {
            // Arrange
            var check = Check.Start();

            // Act
            check.AddException(exception);

            // Assert
            check.Exceptions.Should().HaveCount(1);
            check.Exceptions.Should().Contain(exception);
        }

        [Theory]
        [MemberData(nameof(TestData.PassAsExpectedData), MemberType = typeof(TestData))]
        public void Pass_AsExpected(string error, Exception exception, bool expected)
        {
            // Arrange
            var check = Check.Start();

            // Act
            check.AddError(error);
            check.AddException(exception);

            // Assert
            check.Passed.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.ContractWorksAsExpectedData), MemberType = typeof(TestData))]
        public void Contract_WorksAsExpected(Func<bool> func, Exception exception, bool expected)
        {
            // Arrange
            var check = Check.Start();

            // Act
            check.ContractRule(func, exception);

            // Assert
            check.Passed.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.BusinessWorksAsExpectedData), MemberType = typeof(TestData))]
        public void Business_WorksAsExpected(Func<bool> func, string error, bool expected)
        {
            // Arrange
            var check = Check.Start();

            // Act
            check.BusinessRule(func, error);

            // Assert
            check.Passed.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.ContractWorksAsExpectedData), MemberType = typeof(TestData))]
        public void Contract_ReturnsAsExpected(Func<bool> func, Exception exception, bool expected)
        {
            // Arrange

            // Act
            var check = Check.Contract(func, exception);

            // Assert
            check.Passed.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.BusinessWorksAsExpectedData), MemberType = typeof(TestData))]
        public void Business_ReturnsAsExpected(Func<bool> func, string error, bool expected)
        {
            // Arrange

            // Act
            var check = Check.Business(func, error);

            // Assert
            check.Passed.Should().Be(expected);
        }

        [Theory, AutoData]
        public void ArgNullContract_PassesWithNonNullArument(string option)
        {
            // Arrange

            // Act
            var check = Check.ArgNullContract(() => option);

            // Assert
            check.Passed.Should().BeTrue();
        }

        [Fact]
        public void ArgNullContract_AddsArumentNullExceptionWhenArgIsNull()
        {
            // Arrange
            string option = null;

            // Act
            var check = Check.ArgNullContract(() => option);

            // Assert
            check.Passed.Should().BeFalse();
            check.Exceptions.Should().HaveCount(1);
            check.Exceptions.First().As<ArgumentNullException>().ParamName.Should().Be(nameof(option));
        }
    }
}
