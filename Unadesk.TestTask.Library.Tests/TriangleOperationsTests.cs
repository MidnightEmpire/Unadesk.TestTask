using System.Globalization;
using Unadesk.TestTask.Library.Enumerations;
using Xunit;

namespace Unadesk.TestTask.Library.Tests;

/// <summary>
/// <see cref="TriangleOperations">TriangleOperations</see> test fixture class.
/// </summary>
public class TriangleOperationsTests
{
    /// <summary>
    /// <see cref="TriangleOperations.GetTriangleKind(double, double, double, double)" />
    /// for incorrect sides and/or precision checking method.
    /// </summary>
    /// <param name="side1">Triangle first side length value.</param>
    /// <param name="side2">Triangle second side length value.</param>
    /// <param name="side3">Triangle third side length value.</param>
    /// <param name="precision">Triangle kind checking precision value.</param>
    [Theory]
    [InlineData(-0.5, 0.5, 0.5, 1E-4)]
    [InlineData(0.5, -0.5, 0.5, 1E-4)]
    [InlineData(0.5, 0.5, -0.5, 1E-4)]
    [InlineData(0.0, 0.0, 0.0, 1E-4)]
    [InlineData(100.0, 100.0, 0.0, 1E-4)]
    [InlineData(0.0, 100.0, 100.0, 1E-4)]
    [InlineData(100.0, 0.0, 100.0, 1E-4)]
    [InlineData(2.0, 2.0, 2.0, -1.0)]
    [InlineData(2.0, -2.0, 2.0, -1.0)]
    public void GetTriangleKind_Double_WhenTriangleSidesAndPrecisionAreIncorrectOnes_ThrowsArgumentOutOfRangeException(
        double side1,
        double side2,
        double side3,
        double precision
    ) {
        var exception = Record.Exception(
            () => TriangleOperations.GetTriangleKind(
                side1,
                side2,
                side3,
                precision
            )
        );

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    /// <summary>
    /// <see cref="TriangleOperations.GetTriangleKind(double, double, double, double)" />
    /// for non-matched triangle inequality sides checking method.
    /// </summary>
    /// <param name="side1">Triangle first side length value.</param>
    /// <param name="side2">Triangle second side length value.</param>
    /// <param name="side3">Triangle third side length value.</param>
    /// <param name="precision">Triangle kind checking precision value.</param>
    [Theory]
    [InlineData(15.5, 2.1, 1.9, 1E-4)]
    [InlineData(15.5, 1.9, 2.1, 1E-4)]
    [InlineData(1.9, 15.5, 2.1, 1E-4)]
    [InlineData(1.9, 2.1, 15.5, 1E-4)]
    [InlineData(2.1, 1.9, 15.5, 1E-4)]
    [InlineData(2.1, 15.5, 1.9, 1E-4)]
    public void GetTriangleKind_Double_WhenTriangleInequalityIsNotMatched_ThrowsInvalidOperationException(
        double side1,
        double side2,
        double side3,
        double precision
    ) {
        var exception = Record.Exception(
            () => TriangleOperations.GetTriangleKind(
                side1,
                side2,
                side3,
                precision
            )
        );

        Assert.IsType<InvalidOperationException>(exception);
    }

    /// <summary>
    /// <see cref="TriangleOperations.GetTriangleKind(double, double, double, double)" />
    /// for correct sides and precision checking method.
    /// </summary>
    /// <param name="side1">Triangle first side length value.</param>
    /// <param name="side2">Triangle second side length value.</param>
    /// <param name="side3">Triangle third side length value.</param>
    /// <param name="precision">Triangle kind checking precision value.</param>
    /// <param name="expectedKind">Triangle expected kind value.</param>
    [Theory]
    [InlineData(0.5, 0.5, 0.5, 1E-4, TriangleKind.Acute)]
    [InlineData(5.4, 5.4, 5.4, 1E-4, TriangleKind.Acute)]

    [InlineData(3.0, 4.0, 5.0, 1E-4, TriangleKind.Right)]
    [InlineData(3.0, 5.0, 4.0, 1E-4, TriangleKind.Right)]
    [InlineData(4.0, 3.0, 5.0, 1E-4, TriangleKind.Right)]
    [InlineData(4.0, 5.0, 3.0, 1E-4, TriangleKind.Right)]
    [InlineData(5.0, 4.0, 3.0, 1E-4, TriangleKind.Right)]
    [InlineData(5.0, 3.0, 4.0, 1E-4, TriangleKind.Right)]

    [InlineData(6.5, 6.5, 12.1, 1E-4, TriangleKind.Obtuse)]
    [InlineData(6.5, 12.1, 6.5, 1E-4, TriangleKind.Obtuse)]
    [InlineData(12.1, 6.5, 6.5, 1E-4, TriangleKind.Obtuse)]

    [InlineData(0.25, 0.5, 0.45, 1E-4, TriangleKind.Acute)]
    [InlineData(0.25, 0.45, 0.5, 1E-4, TriangleKind.Acute)]
    [InlineData(0.45, 0.25, 0.5, 1E-4, TriangleKind.Acute)]
    [InlineData(0.45, 0.5, 0.25, 1E-4, TriangleKind.Acute)]
    [InlineData(0.5, 0.45, 0.25, 1E-4, TriangleKind.Acute)]
    [InlineData(0.5, 0.25, 0.45, 1E-4, TriangleKind.Acute)]

    [InlineData(2.1, 0.95, 1.44, 1E-4, TriangleKind.Obtuse)]
    [InlineData(2.1, 1.44, 0.95, 1E-4, TriangleKind.Obtuse)]
    [InlineData(1.44, 2.1, 0.95, 1E-4, TriangleKind.Obtuse)]
    [InlineData(1.44, 0.95, 2.1, 1E-4, TriangleKind.Obtuse)]
    [InlineData(0.95, 1.44, 2.1, 1E-4, TriangleKind.Obtuse)]
    [InlineData(0.95, 2.1, 1.44, 1E-4, TriangleKind.Obtuse)]

    [InlineData(0.12, 0.13, 0.05, 1E-4, TriangleKind.Right)]
    [InlineData(0.12, 0.05, 0.13, 1E-4, TriangleKind.Right)]
    [InlineData(0.13, 0.05, 0.12, 1E-4, TriangleKind.Right)]
    [InlineData(0.13, 0.12, 0.05, 1E-4, TriangleKind.Right)]
    [InlineData(0.05, 0.13, 0.12, 1E-4, TriangleKind.Right)]
    [InlineData(0.05, 0.12, 0.13, 1E-4, TriangleKind.Right)]
    public void GetTriangleKind_Double_WhenTriangleSidesAndPrecisionAreCorrectOnes_ReturnCorrectKind(
        double side1,
        double side2,
        double side3,
        double precision,
        TriangleKind expectedKind
    ) {
        var actualKind = TriangleOperations.GetTriangleKind(
            side1,
            side2,
            side3,
            precision
        );

        Assert.Equal(expectedKind, actualKind);
    }

    /// <summary>
    /// <see cref="TriangleOperations.GetTriangleKind(decimal, decimal, decimal, decimal)" />
    /// for incorrect sides and/or precision checking method.
    /// </summary>
    /// <param name="side1String">Triangle first side length value.</param>
    /// <param name="side2String">Triangle second side length value.</param>
    /// <param name="side3String">Triangle third side length value.</param>
    /// <param name="precisionString">Triangle kind checking precision value.</param>
    [Theory]
    [InlineData("-0.5", "0.5", "0.5", "0.0001")]
    [InlineData("0.5", "-0.5", "0.5", "0.0001")]
    [InlineData("0.5", "0.5", "-0.5", "0.0001")]
    [InlineData("0.0", "0.0", "0.0", "0.0001")]
    [InlineData("100.0", "100.0", "0.0", "0.0001")]
    [InlineData("0.0", "100.0", "100.0", "0.0001")]
    [InlineData("100.0", "0.0", "100.0", "0.0001")]
    [InlineData("2.0", "2.0", "2.0", "-1.0")]
    [InlineData("2.0", "-2.0", "2.0", "-1.0")]
    public void GetTriangleKind_Decimal_WhenTriangleSidesAndPrecisionAreIncorrectOnes_ThrowsArgumentOutOfRangeException(
        string side1String,
        string side2String,
        string side3String,
        string precisionString
    ) {
        var side1 = Convert.ToDecimal(side1String, CultureInfo.InvariantCulture);
        var side2 = Convert.ToDecimal(side2String, CultureInfo.InvariantCulture);
        var side3 = Convert.ToDecimal(side3String, CultureInfo.InvariantCulture);
        var precision = Convert.ToDecimal(precisionString, CultureInfo.InvariantCulture);

        var exception = Record.Exception(
            () => TriangleOperations.GetTriangleKind(
                side1,
                side2,
                side3,
                precision
            )
        );

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    /// <summary>
    /// <see cref="TriangleOperations.GetTriangleKind(decimal, decimal, decimal, decimal)" />
    /// for non-matched triangle inequality sides checking method.
    /// </summary>
    /// <param name="side1String">Triangle first side length value.</param>
    /// <param name="side2String">Triangle second side length value.</param>
    /// <param name="side3String">Triangle third side length value.</param>
    /// <param name="precisionString">Triangle kind checking precision value.</param>
    [Theory]
    [InlineData("15.5", "2.1", "1.9", "0.0001")]
    [InlineData("15.5", "1.9", "2.1", "0.0001")]
    [InlineData("1.9", "15.5", "2.1", "0.0001")]
    [InlineData("1.9", "2.1", "15.5", "0.0001")]
    [InlineData("2.1", "1.9", "15.5", "0.0001")]
    [InlineData("2.1", "15.5", "1.9", "0.0001")]
    public void GetTriangleKind_Decimal_WhenTriangleInequalityIsNotMatched_ThrowsInvalidOperationException(
        string side1String,
        string side2String,
        string side3String,
        string precisionString
    ) {
        var side1 = Convert.ToDecimal(side1String, CultureInfo.InvariantCulture);
        var side2 = Convert.ToDecimal(side2String, CultureInfo.InvariantCulture);
        var side3 = Convert.ToDecimal(side3String, CultureInfo.InvariantCulture);
        var precision = Convert.ToDecimal(precisionString, CultureInfo.InvariantCulture);

        var exception = Record.Exception(
            () => TriangleOperations.GetTriangleKind(
                side1,
                side2,
                side3,
                precision
            )
        );

        Assert.IsType<InvalidOperationException>(exception);
    }

    /// <summary>
    /// <see cref="TriangleOperations.GetTriangleKind(decimal, decimal, decimal, decimal)" />
    /// for correct sides and precision checking method.
    /// </summary>
    /// <param name="side1String">Triangle first side length value.</param>
    /// <param name="side2String">Triangle second side length value.</param>
    /// <param name="side3String">Triangle third side length value.</param>
    /// <param name="precisionString">Triangle kind checking precision value.</param>
    /// <param name="expectedKind">Triangle expected kind value.</param>
    [Theory]
    [InlineData("0.5", "0.5", "0.5", "0.0001", TriangleKind.Acute)]
    [InlineData("5.4", "5.4", "5.4", "0.0001", TriangleKind.Acute)]

    [InlineData("3", "4", "5", "0.0001", TriangleKind.Right)]
    [InlineData("3", "5", "4", "0.0001", TriangleKind.Right)]
    [InlineData("4", "3", "5", "0.0001", TriangleKind.Right)]
    [InlineData("4", "5", "3", "0.0001", TriangleKind.Right)]
    [InlineData("5", "4", "3", "0.0001", TriangleKind.Right)]
    [InlineData("5", "3", "4", "0.0001", TriangleKind.Right)]

    [InlineData("6.5", "6.5", "12.1", "0.0001", TriangleKind.Obtuse)]
    [InlineData("6.5", "12.1", "6.5", "0.0001", TriangleKind.Obtuse)]
    [InlineData("12.1", "6.5", "6.5", "0.0001", TriangleKind.Obtuse)]

    [InlineData("0.25", "0.5", "0.45", "0.0001", TriangleKind.Acute)]
    [InlineData("0.25", "0.45", "0.5", "0.0001", TriangleKind.Acute)]
    [InlineData("0.45", "0.25", "0.5", "0.0001", TriangleKind.Acute)]
    [InlineData("0.45", "0.5", "0.25", "0.0001", TriangleKind.Acute)]
    [InlineData("0.5", "0.45", "0.25", "0.0001", TriangleKind.Acute)]
    [InlineData("0.5", "0.25", "0.45", "0.0001", TriangleKind.Acute)]

    [InlineData("2.1", "0.95", "1.44", "0.0001", TriangleKind.Obtuse)]
    [InlineData("2.1", "1.44", "0.95", "0.0001", TriangleKind.Obtuse)]
    [InlineData("1.44", "2.1", "0.95", "0.0001", TriangleKind.Obtuse)]
    [InlineData("1.44", "0.95", "2.1", "0.0001", TriangleKind.Obtuse)]
    [InlineData("0.95", "1.44", "2.1", "0.0001", TriangleKind.Obtuse)]
    [InlineData("0.95", "2.1", "1.44", "0.0001", TriangleKind.Obtuse)]

    [InlineData("0.12", "0.13", "0.05", "0.0001", TriangleKind.Right)]
    [InlineData("0.12", "0.05", "0.13", "0.0001", TriangleKind.Right)]
    [InlineData("0.13", "0.05", "0.12", "0.0001", TriangleKind.Right)]
    [InlineData("0.13", "0.12", "0.05", "0.0001", TriangleKind.Right)]
    [InlineData("0.05", "0.13", "0.12", "0.0001", TriangleKind.Right)]
    [InlineData("0.05", "0.12", "0.13", "0.0001", TriangleKind.Right)]
    public void GetTriangleKind_Decimal_WhenTriangleSidesAndPrecisionAreCorrectOnes_ReturnCorrectKind(
        string side1String,
        string side2String,
        string side3String,
        string precisionString,
        TriangleKind expectedKind
    ) {
        var side1 = Convert.ToDecimal(side1String, CultureInfo.InvariantCulture);
        var side2 = Convert.ToDecimal(side2String, CultureInfo.InvariantCulture);
        var side3 = Convert.ToDecimal(side3String, CultureInfo.InvariantCulture);

        var precision = Convert.ToDecimal(precisionString, CultureInfo.InvariantCulture);

        var actualKind = TriangleOperations.GetTriangleKind(
            side1,
            side2,
            side3,
            precision
        );

        Assert.Equal(expectedKind, actualKind);
    }

    /// <summary>
    /// <see cref="TriangleOperations.GetTriangleKind(int, int, int)" />
    /// for incorrect sides and/or precision checking method.
    /// </summary>
    /// <param name="side1">Triangle first side length value.</param>
    /// <param name="side2">Triangle second side length value.</param>
    /// <param name="side3">Triangle third side length value.</param>
    [Theory]
    [InlineData(-5, 5, 5)]
    [InlineData(5, -5, 5)]
    [InlineData(5, 5, -5)]
    [InlineData(0, 0, 0)]
    [InlineData(100, 100, 0)]
    [InlineData(0, 100, 100)]
    [InlineData(100, 0, 100)]
    public void GetTriangleKind_Integer_WhenTriangleSidesAndPrecisionAreIncorrectOnes_ThrowsArgumentOutOfRangeException(
        int side1,
        int side2,
        int side3
    ) {
        var exception = Record.Exception(
            () => TriangleOperations.GetTriangleKind(
                side1,
                side2,
                side3
            )
        );

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    /// <summary>
    /// <see cref="TriangleOperations.GetTriangleKind(int, int, int)" />
    /// for non-matched triangle inequality sides checking method.
    /// </summary>
    /// <param name="side1">Triangle first side length value.</param>
    /// <param name="side2">Triangle second side length value.</param>
    /// <param name="side3">Triangle third side length value.</param>
    [Theory]
    [InlineData(15, 2, 1)]
    [InlineData(15, 1, 2)]
    [InlineData(1, 15, 2)]
    [InlineData(1, 2, 15)]
    [InlineData(2, 1, 15)]
    [InlineData(2, 15, 1)]
    public void GetTriangleKind_Integer_WhenTriangleInequalityIsNotMatched_ThrowsInvalidOperationException(
        int side1,
        int side2,
        int side3
    ) {
        var exception = Record.Exception(
            () => TriangleOperations.GetTriangleKind(
                side1,
                side2,
                side3
            )
        );

        Assert.IsType<InvalidOperationException>(exception);
    }

    /// <summary>
    /// <see cref="TriangleOperations.GetTriangleKind(int, int, int)" />
    /// for correct sides and precision checking method.
    /// </summary>
    /// <param name="side1">Triangle first side length value.</param>
    /// <param name="side2">Triangle second side length value.</param>
    /// <param name="side3">Triangle third side length value.</param>
    /// <param name="expectedKind">Triangle expected kind value.</param>
    [Theory]
    [InlineData(1, 1, 1, TriangleKind.Acute)]
    [InlineData(5, 5, 5, TriangleKind.Acute)]

    [InlineData(3, 4, 5, TriangleKind.Right)]
    [InlineData(3, 5, 4, TriangleKind.Right)]
    [InlineData(4, 3, 5, TriangleKind.Right)]
    [InlineData(4, 5, 3, TriangleKind.Right)]
    [InlineData(5, 4, 3, TriangleKind.Right)]
    [InlineData(5, 3, 4, TriangleKind.Right)]

    [InlineData(7, 8, 12, TriangleKind.Obtuse)]
    [InlineData(7, 12, 8, TriangleKind.Obtuse)]
    [InlineData(12, 7, 8, TriangleKind.Obtuse)]
    [InlineData(12, 8, 7, TriangleKind.Obtuse)]
    [InlineData(8, 12, 7, TriangleKind.Obtuse)]
    [InlineData(8, 7, 12, TriangleKind.Obtuse)]

    [InlineData(12, 13, 5, TriangleKind.Right)]
    [InlineData(12, 5, 13, TriangleKind.Right)]
    [InlineData(13, 5, 12, TriangleKind.Right)]
    [InlineData(13, 12, 5, TriangleKind.Right)]
    [InlineData(5, 13, 12, TriangleKind.Right)]
    [InlineData(5, 12, 13, TriangleKind.Right)]
    public void GetTriangleKind_Integer_WhenTriangleSidesAndPrecisionAreCorrectOnes_ReturnCorrectKind(
        int side1,
        int side2,
        int side3,
        TriangleKind expectedKind
    ) {
        var actualKind = TriangleOperations.GetTriangleKind(
            side1,
            side2,
            side3
        );

        Assert.Equal(expectedKind, actualKind);
    }
}