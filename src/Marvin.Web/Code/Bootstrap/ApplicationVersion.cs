using System.Reflection;

namespace Marvin.Web.Code.Bootstrap;

/// <summary>
/// Service providing the version of the application
/// </summary>
public interface IAppVersionService 
{ 
    /// <summary>
    /// 
    /// </summary>
    string Version { get; }
}

/// <inheritdoc />
public class ApplicationVersion : IAppVersionService
{
    /// <summary>
    /// Gets the current version of the application
    /// </summary>
    public string Version => Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
}