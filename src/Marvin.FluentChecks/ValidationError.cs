namespace Marvin.FluentChecks
{
    public record ValidationError
    {
        public string Code { get; } = string.Empty;

        public string Message { get; } = string.Empty;
    }
}
