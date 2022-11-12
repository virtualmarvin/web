namespace Marvin.FluentChecks.Errors
{
    public record ValidationError
    {
        public ValidationError(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; } = string.Empty;

        public string Message { get; } = string.Empty;
    }
}
