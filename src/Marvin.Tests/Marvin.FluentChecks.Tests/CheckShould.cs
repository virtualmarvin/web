

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

        public static readonly IEnumerable<object[]> PassAsExpectedData = new List<object[]>
        {
            new object[] {(string)null, (Exception)null, true },
            new object[] {"String", (Exception)null, false },
            new object[] {(string)null, new Exception(), false },
            new object[] {"String", new Exception(), false },
        };

        [Theory]
        [MemberData(nameof(PassAsExpectedData))]
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


        public static readonly IEnumerable<object[]> ContractWorksAsExpectedData = new List<object[]>
        {
            new object[] { () => true, new Exception(), false },
            new object[] { () => false, new Exception(), true },
        };

        [Theory]
        [MemberData(nameof(ContractWorksAsExpectedData))]
        public void Contract_WorksAsExpected(Func<bool> func, Exception exception, bool expected)
        {
            // Arrange
            var check = Check.Start();

            // Act
            check.Contract(func, exception);

            // Assert
            check.Passed.Should().Be(expected);
        }

        public static readonly IEnumerable<object[]> BusinessWorksAsExpectedData = new List<object[]>
        {
            new object[] { () => true, "String", false },
            new object[] { () => false, "String", true },
        };

        [Theory]
        [MemberData(nameof(BusinessWorksAsExpectedData))]
        public void Business_WorksAsExpected(Func<bool> func, string error, bool expected)
        {
            // Arrange
            var check = Check.Start();

            // Act
            check.Business(func, error);

            // Assert
            check.Passed.Should().Be(expected);
        }
    }
}
