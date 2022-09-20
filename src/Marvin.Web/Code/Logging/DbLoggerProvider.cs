using Marvin.Web.Domain;

namespace Marvin.Web
{
    public class DbLoggerProvider : ILoggerProvider
    {
        private readonly Func<string, LogLevel, bool> _filter;

        public DbLoggerProvider(Func<string, LogLevel, bool> filter)
        {
            _filter = filter;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new DbLogger<Error>(categoryName, _filter);
        }

        public void Dispose()
        {
        }
    }
}
