using Marvin.Web.Code.Exceptions;
using Marvin.Web.Code.Validators;

namespace Marvin.Web.Tests.Code.Validators
{
    public class ValidationTests
    {
        private readonly IFixture _fixture = new Fixture();

        [Fact]
        public void ArgumentNullCheck_With2NullArguments_ThrowsMultiExceptionWith2Results()
        {
            // Arrange
            TestClass? arument1 = null;
            TestClass? arument2 = null;

            // Act
            Action action = () => Validation.Begin()
                .ArgumentNullCheck(arument1, nameof(arument1))
                .ArgumentNullCheck(arument2, nameof(arument2))
                .Check();

            // Assert
            action.Should().Throw<ValidationException>()
                .WithInnerExceptionExactly<MultiException>()
                .And.InnerExceptions.Should().HaveCount(2);
        }

        [Fact]
        public void ArgumentNullCheck_With2Arguments_ChecksOk()
        {
            // Arrange
            TestClass? arument1 = _fixture.Create<TestClass>();
            TestClass? arument2 = _fixture.Create<TestClass>();

            // Act

            // Assert
            Validation.Begin()
                .ArgumentNullCheck(arument1, nameof(arument1))
                .ArgumentNullCheck(arument2, nameof(arument2))
                .Check().Should().BeTrue();
        }

        public class TestClass
        {
            public int IntProperty { get; set; } = 42;
            public string StringProperty { get; set; } = Guid.NewGuid().ToString();
        }
    }
}
