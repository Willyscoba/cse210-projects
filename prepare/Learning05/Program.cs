using System;

class Program
{
    static void Main(string[] args)
    {
       List<Shape> shapes = new List<Shape>();

       Square square = new Square("Red", 5);
       shapes.Add(square);
        
       Rectangle rectangle = new Rectangle("Blue", 4, 6);
       shapes.Add(rectangle);

        
       Circle circle = new Circle("Green", 3);
       shapes.Add(circle);

        // Iterate through the list of shapes
       foreach (Shape s in shapes)
        {
            string color = s.GetColor();
            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}