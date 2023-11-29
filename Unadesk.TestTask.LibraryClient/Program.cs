using System.Globalization;
using Unadesk.TestTask.Library;

Console.WriteLine(".:Triangle king checker:.");
Console.WriteLine("_________________________");
Console.WriteLine();
Console.WriteLine("Please, enter triangular sides as rational values:");
Console.WriteLine("(Invariant culture)");
Console.WriteLine();

Console.Write("Side A: ");

var side1String = Console.ReadLine();

var side1 = double.Parse(side1String!, CultureInfo.InvariantCulture);

Console.Write("Side B: ");

var side2String = Console.ReadLine();

var side2 = double.Parse(side2String!, CultureInfo.InvariantCulture);

Console.Write("Side C: ");

var side3String = Console.ReadLine();

var side3 = double.Parse(side3String!, CultureInfo.InvariantCulture);

var triangleKind = TriangleOperations.GetTriangleKind(side1, side2, side3, 1E-3);

Console.WriteLine();
Console.WriteLine($"Triangular kind is {triangleKind} (with precision 0.001 used).");