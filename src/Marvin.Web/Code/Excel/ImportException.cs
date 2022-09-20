namespace Marvin.Web
{
    public class ImportException : Exception
    {
        public ImportException(string? message, Exception? ex)
            : base(message, ex)
        {
        }
    }
}
