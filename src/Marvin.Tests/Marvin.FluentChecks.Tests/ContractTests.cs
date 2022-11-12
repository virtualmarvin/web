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
    }
}
