using System.Runtime.CompilerServices;

namespace Unadesk.TestTask.Library.Helpers;

/// <summary>
/// Exception throwing helper class.
/// </summary>
/// <remarks>
/// This one is some kind of helper class to reduce amount of boilerplate code in target usage places.<br />
/// KISS approach finally used.<br />
/// DRY is not used for optimization purposes.
/// </remarks>
internal static class ThrowHelper
{
    /// <summary>
    /// <see cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException</see> throwing method, if argument is less
    /// than or equals the specified value.
    /// </summary>
    /// <param name="argument">Argument value to check.</param>
    /// <param name="value">Argument specified value to check.</param>
    /// <param name="argumentName">Argument/parameter name to substitute.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Throws, if specified <paramref name="argument" /> is less than or equals the specified <paramref name="value" />.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowsArgumentOutOfRangeExceptionIfArgumentIsLessThanOrEqualsValue(
        double argument,
        double value,
        string argumentName
    ) {
        if (argument <= value)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }
    }

    /// <summary>
    /// <see cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException</see> throwing method, if argument is less
    /// than or equals the specified value.
    /// </summary>
    /// <param name="argument">Argument value to check.</param>
    /// <param name="value">Argument specified value to check.</param>
    /// <param name="argumentName">Argument/parameter name to substitute.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Throws, if specified <paramref name="argument" /> is less than or equals the specified <paramref name="value" />.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowsArgumentOutOfRangeExceptionIfArgumentIsLessThanOrEqualsValue(
        decimal argument,
        decimal value,
        string argumentName
    ) {
        if (argument <= value)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }
    }

    /// <summary>
    /// <see cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException</see> throwing method, if argument is less
    /// than or equals the specified value.
    /// </summary>
    /// <param name="argument">Argument value to check.</param>
    /// <param name="value">Argument specified value to check.</param>
    /// <param name="argumentName">Argument/parameter name to substitute.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Throws, if specified <paramref name="argument" /> is less than or equals the specified <paramref name="value" />.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowsArgumentOutOfRangeExceptionIfArgumentIsLessThanOrEqualsValue(
        int argument,
        int value,
        string argumentName
    ) {
        if (argument <= value)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }
    }

    /// <summary>
    /// <see cref="InvalidOperationException">InvalidOperationException</see> throwing method, if the triangle inequality for
    /// specified arguments (<paramref name="side1" />, <paramref name="side2" /> and <paramref name="side3" />) are not matched.
    /// </summary>
    /// <param name="side1">First triangle side value to check.</param>
    /// <param name="side2">Second triangle side value to check.</param>
    /// <param name="side3">Third triangle side value to check.</param>
    /// <param name="precision">Precision value to check.</param>
    /// <exception cref="InvalidOperationException">
    /// Throws, if specified <paramref name="side1" />, <paramref name="side2" /> and <paramref name="side3" />
    /// are not matched to the triangle inequality.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowsInvalidArgumentExceptionIfTriangleInequalityIsNotMatched(
        double side1,
        double side2,
        double side3,
        double precision
    ) {
        if (side1 + side2 - side3 <= precision ||
            side1 + side3 - side2 <= precision ||
            side2 + side3 - side1 <= precision
        ) {
            throw new InvalidOperationException();
        }
    }

    /// <summary>
    /// <see cref="InvalidOperationException">InvalidOperationException</see> throwing method, if the triangle inequality for
    /// specified arguments (<paramref name="side1" />, <paramref name="side2" /> and <paramref name="side3" />) are not matched.
    /// </summary>
    /// <param name="side1">First triangle side value to check.</param>
    /// <param name="side2">Second triangle side value to check.</param>
    /// <param name="side3">Third triangle side value to check.</param>
    /// <param name="precision">Precision value to check.</param>
    /// <exception cref="InvalidOperationException">
    /// Throws, if specified <paramref name="side1" />, <paramref name="side2" /> and <paramref name="side3" />
    /// are not matched to the triangle inequality.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowsInvalidArgumentExceptionIfTriangleInequalityIsNotMatched(
        decimal side1,
        decimal side2,
        decimal side3,
        decimal precision
    ) {
        if (side1 + side2 - side3 <= precision ||
            side1 + side3 - side2 <= precision ||
            side2 + side3 - side1 <= precision
        ) {
            throw new InvalidOperationException();
        }
    }

    /// <summary>
    /// <see cref="InvalidOperationException">InvalidOperationException</see> throwing method, if the triangle inequality for
    /// specified arguments (<paramref name="side1" />, <paramref name="side2" /> and <paramref name="side3" />) are not matched.
    /// </summary>
    /// <param name="side1">First triangle side value to check.</param>
    /// <param name="side2">Second triangle side value to check.</param>
    /// <param name="side3">Third triangle side value to check.</param>
    /// <exception cref="InvalidOperationException">
    /// Throws, if specified <paramref name="side1" />, <paramref name="side2" /> and <paramref name="side3" />
    /// are not matched to the triangle inequality.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowsInvalidArgumentExceptionIfTriangleInequalityIsNotMatched(
        int side1,
        int side2,
        int side3
    ) {
        if (side1 + side2 - side3 <= 0 ||
            side1 + side3 - side2 <= 0 ||
            side2 + side3 - side1 <= 0
        ) {
            throw new InvalidOperationException();
        }
    }
}