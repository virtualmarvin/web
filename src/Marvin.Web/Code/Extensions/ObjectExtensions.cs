using System.Diagnostics.CodeAnalysis;

namespace Marvin.Web.Code.Extensions;

/// <summary>
/// Useful object extensions
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// Returns boolean value whether T is null or not
    /// We also include some information for the compiler as we know from the result of this
    /// that a null check would not be required from the return value
    /// </summary>
    /// <param name="t"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns><see cref="bool"/></returns>
    public static bool IsNull<T>([NotNullWhen(returnValue: false)] this T? t)
        where T : class
    {
        return ReferenceEquals(t, null);
    }

    /// <summary>
    /// Returns a boolean value whether T is NOT null
    /// We also include some information for the compiler as we know from the result of this
    /// that a null check would not be required from the return value
    /// </summary>
    /// <param name="t"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns><see cref="bool"/></returns>
    public static bool IsNotNull<T>([NotNullWhen(returnValue: true)] this T? t)
        where T : class
    {
        return !ReferenceEquals(t, null);
    }

    /// <summary>
    /// Safely determine if two objects are equal
    /// </summary>
    /// <param name="t">Object under test</param>
    /// <param name="other">Object to test against</param>
    /// <typeparam name="T">The type of the object</typeparam>
    /// <returns></returns>
    public static bool SafeEquals<T>(this T t, T other)
    {
        return Equals(t, other);
    }

    /// <summary>
    /// Safely determine if two objects are not equal
    /// </summary>
    /// <param name="t">Object under test</param>
    /// <param name="other">Object to test against</param>
    /// <typeparam name="T">The type of object</typeparam>
    /// <returns></returns>
    public static bool SafeNotEquals<T>(this T t, T other)
    {
        return !t.SafeEquals(other);
    }
}