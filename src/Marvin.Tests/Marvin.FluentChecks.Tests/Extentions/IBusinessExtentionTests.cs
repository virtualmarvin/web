using Marvin.FluentChecks.Exceptions;
using Marvin.FluentChecks.Extensions;

namespace Marvin.FluentChecks.Tests.Extentions
{
    public class IBusinessExtentionTests
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

    }
}
