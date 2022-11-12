namespace Marvin.FluentChecks.Tests
{
    public class BusinessTests
    {
        [Fact]
        public void Business_Begin_CreatesClass()
        {
            // Arrange

            // Act
            var business = Business.Begin();

            // Assert
            business.Should().NotBeNull();
            business.Should().BeAssignableTo<IBusiness>();
        }
    }
}
