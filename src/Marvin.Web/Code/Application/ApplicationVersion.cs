using System.Reflection;

namespace Marvin.Web.Code.Application;

#region Interface
/// <summary>
/// Service providing the version of the application
/// </summary>
public interface IAppVersionService
{
    /// <summary>
    /// Current version of the application.
    /// </summary>
    string Version { get; }
}
#endregion

/// <inheritdoc />
public class ApplicationVersion : IAppVersionService
{
    /// <summary>
    /// Gets the current version of the application
    /// </summary>
    public string Version => Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
}
