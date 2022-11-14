using Marvin.FluentChecks.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvin.FluentChecks.Tests.Extentions
{
    public class CheckContractShould
    {

        [Theory]
        [InlineData(null, null, 2)]
        [InlineData(1, null, 1)]
        [InlineData(null, "", 1)]
        [InlineData(1, "", 0)]
        public void ArgNull_WithOptions_ReturnsAsExpected(int? option1, string? option2, int expected)
        {
            // Assemble
            var contract = Contract
                .Begin()
                .ArgNull(() => option1)
                .ArgNull(() => option2);

            // Act

            //Assert
            contract.ExceptionCount.Should().Be(expected);
        }
    }
}
