namespace Marvin.FluentChecks.Tests
{
    public sealed class TestClass
    {
        public int IntProperty { get; set; } = 42;
        public string StringProperty { get; set; } = Guid.NewGuid().ToString();
    }
}
