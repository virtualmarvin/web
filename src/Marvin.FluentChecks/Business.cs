namespace Marvin.FluentChecks
{
    /// <summary>
    /// Business logic reports an error, usually denoting errors entered by a user
    /// Also known as shit they did wrong
    /// </summary>
    public interface IBusiness
    {
        bool Success { get; }
    }

    public sealed class Business : IBusiness
    {
        private Business() { }

        public bool Success => true;

        public static IBusiness Begin() => new Business();
    }
}
