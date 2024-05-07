using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(6);
        Fraction f3 = new Fraction(6, 7);
        Fraction f4 = new Fraction(7, 9);


        Console.WriteLine($"F1: {f1.GetTop()}/{f1.GetBottom()}");
        Console.WriteLine($"F2: {f2.GetTop()}/{f2.GetBottom()}");
        Console.WriteLine($"F3: {f3.GetTop()}/{f3.GetBottom()}");
        Console.WriteLine($"F4: {f4.GetTop()}/{f4.GetBottom()}");

        f1.SetTOp(3);
        f1.SetBottomn(4);

        Console.WriteLine($"F1: {f1.GetTop()}/{f1.GetBottom()}");

        Console.WriteLine($"F1 as string: {f1.GetFractionString()}");
        Console.WriteLine($"F1 as decimal: {f1.GetDecimalValue()}");
    }
}