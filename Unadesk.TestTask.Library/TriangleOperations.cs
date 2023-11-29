using Unadesk.TestTask.Library.Enumerations;
using Unadesk.TestTask.Library.Helpers;

namespace Unadesk.TestTask.Library;

/// <summary>
/// Common triangle operations containing class.
/// </summary>
/// <remarks>
/// KISS approach finally used.<br />
/// DRY is not used for optimization purposes.
/// </remarks>
public static class TriangleOperations
{
    /// <summary>
    /// Get triangle kind method.
    /// </summary>
    /// <param name="side1">First triangle side length value.</param>
    /// <param name="side2">Second triangle side length value.</param>
    /// <param name="side3">Third triangle side length value.</param>
    /// <param name="precision">Floating point values comparison precision.</param>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if any of specified arguments is less than 0.</exception>
    /// <exception cref="InvalidOperationException">Throws, if a specified triangle is the non-existent one.</exception>
    /// <returns><see cref="TriangleKind">TriangleKind</see> value.</returns>
    public static TriangleKind GetTriangleKind(
        double side1,
        double side2,
        double side3,
        double precision
    ) {
        const double maxPrecision = 0.0;

        ThrowHelper.ThrowsArgumentOutOfRangeExceptionIfArgumentIsLessThanOrEqualsValue(precision, maxPrecision, nameof(precision));
        ThrowHelper.ThrowsArgumentOutOfRangeExceptionIfArgumentIsLessThanOrEqualsValue(side1, maxPrecision, nameof(side1));
        ThrowHelper.ThrowsArgumentOutOfRangeExceptionIfArgumentIsLessThanOrEqualsValue(side2, maxPrecision, nameof(side2));
        ThrowHelper.ThrowsArgumentOutOfRangeExceptionIfArgumentIsLessThanOrEqualsValue(side3, maxPrecision, nameof(side3));

        var negativePrecision = -precision;

        ThrowHelper.ThrowsInvalidArgumentExceptionIfTriangleInequalityIsNotMatched(side1, side2, side3, 0.0);

        var side1Square = side1 * side1;
        var side2Square = side2 * side2;
        var side3Square = side3 * side3;

        var condition1 = side1Square + side2Square - side3Square;
        var condition2 = side1Square + side3Square - side2Square;
        var condition3 = side2Square + side3Square - side1Square;

        if (condition1 >= negativePrecision && condition1 <= precision ||
            condition2 >= negativePrecision && condition2 <= precision ||
            condition3 >= negativePrecision && condition3 <= precision
        ) {
            return TriangleKind.Right;
        }

        if (condition1 < negativePrecision ||
            condition2 < negativePrecision ||
            condition3 < negativePrecision
        ) {
            return TriangleKind.Obtuse;
        }

        return TriangleKind.Acute;
    }

    /// <summary>
    /// Get triangle kind method.
    /// </summary>
    /// <param name="side1">First triangle side length value.</param>
    /// <param name="side2">Second triangle side length value.</param>
    /// <param name="side3">Third triangle side length value.</param>
    /// <param name="precision">Floating point values comparison precision.</param>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if any of specified arguments is less than 0.</exception>
    /// <exception cref="InvalidOperationException">Throws, if a specified triangle is the non-existent one.</exception>
    /// <returns><see cref="TriangleKind">TriangleKind</see> value.</returns>
    public static TriangleKind GetTriangleKind(
        decimal side1,
        decimal side2,
        decimal side3,
        decimal precision
    ) {
        const decimal maxPrecision = 0m;

        ThrowHelper.ThrowsArgumentOutOfRangeExceptionIfArgumentIsLessThanOrEqualsValue(precision, maxPrecision, nameof(precision));
        ThrowHelper.ThrowsArgumentOutOfRangeExceptionIfArgumentIsLessThanOrEqualsValue(side1, maxPrecision, nameof(side1));
        ThrowHelper.ThrowsArgumentOutOfRangeExceptionIfArgumentIsLessThanOrEqualsValue(side2, maxPrecision, nameof(side2));
        ThrowHelper.ThrowsArgumentOutOfRangeExceptionIfArgumentIsLessThanOrEqualsValue(side3, maxPrecision, nameof(side3));

        var negativePrecision = -precision;

        ThrowHelper.ThrowsInvalidArgumentExceptionIfTriangleInequalityIsNotMatched(side1, side2, side3, 0m);

        var side1Square = side1 * side1;
        var side2Square = side2 * side2;
        var side3Square = side3 * side3;

        var condition1 = side1Square + side2Square - side3Square;
        var condition2 = side1Square + side3Square - side2Square;
        var condition3 = side2Square + side3Square - side1Square;

        if (condition1 >= negativePrecision && condition1 <= precision ||
            condition2 >= negativePrecision && condition2 <= precision ||
            condition3 >= negativePrecision && condition3 <= precision
        ) {
            return TriangleKind.Right;
        }

        if (condition1 < negativePrecision ||
            condition2 < negativePrecision ||
            condition3 < negativePrecision
        ) {
            return TriangleKind.Obtuse;
        }

        return TriangleKind.Acute;
    }

    /// <summary>
    /// Get triangle kind method.
    /// </summary>
    /// <param name="side1">First triangle side length value.</param>
    /// <param name="side2">Second triangle side length value.</param>
    /// <param name="side3">Third triangle side length value.</param>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if any of specified arguments is less than 0.</exception>
    /// <exception cref="InvalidOperationException">Throws, if a specified triangle is the non-existent one.</exception>
    /// <returns><see cref="TriangleKind">TriangleKind</see> value.</returns>
    public static TriangleKind GetTriangleKind(
        int side1,
        int side2,
        int side3
    ) {
        const int zero = 0;

        ThrowHelper.ThrowsArgumentOutOfRangeExceptionIfArgumentIsLessThanOrEqualsValue(side1, zero, nameof(side1));
        ThrowHelper.ThrowsArgumentOutOfRangeExceptionIfArgumentIsLessThanOrEqualsValue(side2, zero, nameof(side2));
        ThrowHelper.ThrowsArgumentOutOfRangeExceptionIfArgumentIsLessThanOrEqualsValue(side3, zero, nameof(side3));

        ThrowHelper.ThrowsInvalidArgumentExceptionIfTriangleInequalityIsNotMatched(side1, side2, side3);

        var side1Square = side1 * side1;
        var side2Square = side2 * side2;
        var side3Square = side3 * side3;

        var condition1 = side1Square + side2Square - side3Square;
        var condition2 = side1Square + side3Square - side2Square;
        var condition3 = side2Square + side3Square - side1Square;

        if (condition1 == zero ||
            condition2 == zero ||
            condition3 == zero
        ) {
            return TriangleKind.Right;
        }

        if (condition1 < zero ||
            condition2 < zero ||
            condition3 < zero
        ) {
            return TriangleKind.Obtuse;
        }

        return TriangleKind.Acute;
    }
}