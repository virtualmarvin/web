namespace Marvin.FluentChecks.Tests
{
    public class TestData
    {
        public static readonly IEnumerable<object[]> ContractWorksAsExpectedData = new List<object[]>
        {
            new object[] { () => true, new Exception(), false },
            new object[] { () => false, new Exception(), true },
        };

        public static readonly IEnumerable<object[]> BusinessWorksAsExpectedData = new List<object[]>
        {
            new object[] { () => true, "String", false },
            new object[] { () => false, "String", true },
        };

        public static readonly IEnumerable<object[]> PassAsExpectedData = new List<object[]>
        {
            new object[] {(string)null, (Exception)null, true },
            new object[] {"String", (Exception)null, false },
            new object[] {(string)null, new Exception(), false },
            new object[] {"String", new Exception(), false },
        };
    }
}
