namespace Unadesk.TestTask.Library.Enumerations;

/// <summary>
/// Triangle kind enumeration.
/// </summary>
/// <remarks>
/// Richter said: any enumeration values will be inlined during compilation.<br />
/// So, suppose no any another triangle types exist.
/// </remarks>
public enum TriangleKind : short
{
    /// <summary>
    /// All triangle angles are less than 90 degrees ones.
    /// </summary>
    Acute = -1,

    /// <summary>
    /// One of triangle angles are 90 degrees one.
    /// </summary>
    Right = 0,

    /// <summary>
    /// One of triangle angles are greater than 90 degrees one.
    /// </summary>
    Obtuse = 1
}