using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatchingDemo
{
    public class Shape
    {

        public record Person(string FirstName, string LastName, Address Address);

        public record Address(string Street, string City);

        Person p = new Person("Roland", "Gujit", new("Single", "Amesterdam"));


        public static double ComputeArea(object shape)
        {
            if (shape is Square)
            {
                // test the variable in if statement, assign it on next line
                var s = shape as Square;
                return s.Side * s.Side;
            }
            else if (shape is Circle)
            {
                var c = shape as Circle;
                return c.Radius * c.Radius * Math.PI;
            }

            throw new ArgumentException(message: "shape is not a recognized shape", paramName: nameof(shape));
        }
        public static double ComputeAreaModernIs(object shape)
        {
            // test the variable and assign it in one line
            if (shape is Square s)
                return s.Side * s.Side;
            else if (shape is Circle c)
                return c.Radius * c.Radius * Math.PI;
            else if (shape is Rectangle r)
                //rectangle type is a struct
                // the new is expression works with value types as well as reference types
                return r.Height * r.Length;

            throw new ArgumentException(message: "shape is not a recognized shape",paramName: nameof(shape));
        }

        public static double ComputeArea_Version4(object? shape)
        {
            switch (shape)
            {
                // switch statements now have multiple possible matches
                case Square s when s.Side == 0:
                case Circle c when c.Radius == 0:
                case Triangle t when t.Base == 0 || t.Height == 0:
                case Rectangle r when r.Length == 0 || r.Height == 0:
                    return 0;

                //switch cases no longer need to be constant values
                case Square s:
                    return s.Side * s.Side;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                case Triangle t:
                    return t.Base * t.Height * 2;
                case Rectangle r:
                    return r.Length * r.Height;
                case null:
                    // we can now test null cases in switch statements
                    throw new ArgumentNullException(paramName: nameof(shape), message: "Shape must not be null");
                default:
                    throw new ArgumentException(message: "shape is not a recognized shape",paramName: nameof(shape));
            }
        }

        public static void Main(string[] args)
        {
            Square s = new Square(5);
            Console.WriteLine("The area of the square is: " + ComputeArea(s));
            Console.WriteLine("The area of the square is: " + ComputeAreaModernIs(s));

            Triangle t = new Triangle(5, 20);
            Console.WriteLine("The area of the rectangle is: " + ComputeArea_Version4(t));

            Rectangle r = new Rectangle(0, 0);
            Console.WriteLine("The area of the rectangle is: " + ComputeArea_Version4(r));

            Console.WriteLine("Trying to pass a null object " + ComputeArea_Version4(null));
        }
    }

    public class Square
    {
        public double Side { get; }

        public Square(double side)
        {
            Side = side;
        }
    }

    public class Circle
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }
    }

    public struct Rectangle
    {
        public double Length { get; }
        public double Height { get; }

        public Rectangle(double length, double height)
        {
            Length = length;
            Height = height;
        }
    }

    public struct Triangle
    {
        public double Base { get; }
        public double Height { get; }

        public Triangle(double length, double height)
        {
            Base = length;
            Height = height;
        }
    }

    
}