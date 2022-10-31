using Marvin.FluentChecks.Extensions;

namespace Marvin.FluentChecks.Tests.Extentions
{
    public class ObjectExtensionsTests
    {
        private readonly IFixture _fixture = new Fixture();

        public static readonly IEnumerable<object[]> IsNullData = new List<object[]>
        {
            new object[] {null, true },
            new object[] {new TestClass(), false }
        };

        public static readonly IEnumerable<object[]> IsNotNullData = new List<object[]>
        {
            new object[] {null, false },
            new object[] {new TestClass(), true }
        };

        [Theory]
        [MemberData(nameof(IsNullData))]
        public void IsNull_WhenCalled_ReturnsExpected(TestClass? @class, bool expected)
        {
            // Arrange

            // Act

            // Assert
            @class.IsNull().Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(IsNotNullData))]
        public void IsNotNull_WhenCalled_ReturnsExpected(TestClass? @class, bool expected)
        {
            // Arrange

            // Act

            // Assert
            @class.IsNotNull().Should().Be(expected);
        }

        [Fact]
        public void SafeEquals_WithSameObject_ReturnsTrue()
        {
            // Arrange
            var obj = _fixture.Create<TestClass>();
            // Act

            // Assert
            obj.SafeEquals(obj).Should().BeTrue();
        }

        [Fact]
        public void SafeEquals_WithDifferentObjects_ReturnsFalse()
        {
            // Arrange
            var obj1 = _fixture.Create<TestClass>();
            var obj2 = _fixture.Create<TestClass>();
            // Act

            // Assert
            obj1.SafeEquals(obj2).Should().BeFalse();
        }

        [Fact]
        public void SafeNotEquals_WithSameObject_ReturnsTrue()
        {
            // Arrange
            var obj = _fixture.Create<TestClass>();
            // Act

            // Assert
            obj.SafeNotEquals(obj).Should().BeFalse();
        }

        [Fact]
        public void SafeNotEquals_WithDifferentObjects_ReturnsFalse()
        {
            // Arrange
            var obj1 = _fixture.Create<TestClass>();
            var obj2 = _fixture.Create<TestClass>();
            // Act

            // Assert
            obj1.SafeNotEquals(obj2).Should().BeTrue();
        }
    }
}