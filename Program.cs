using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    abstract class Geometric_figure
    {
        public string Type { get; set; }
        public abstract double Area();
        public override string ToString() //переопределение Object
        {
            return " Площадь " + this.Type + " " + this.Area().ToString();
        }
    }
    interface IPrint
    {
        void Print();
    }
    class Rectangle : Geometric_figure, IPrint  
    {
        public double Height { get; set; } 
        public double Width { get; set; } 
        public Rectangle(double a, double b) //конструктор 
        {
            this.Height = a;
            this.Width = b;
            this.Type = "Прямоугольника";
        }
        public override double Area()

        {
            double Result = this.Width * this.Height;
            return Result;
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
    class Square : Rectangle, IPrint
    {
        public Square(double size) : base(size, size)
        {
            this.Type = "Квадрата";
        }
    }
    class Circle : Geometric_figure, IPrint
    {
        public double Radius { get; set; }
        public Circle(double r)
        {
            this.Radius = r;
            this.Type = "Круга";
        }
        public override double Area()
        {
            double Result = Math.PI * this.Radius * this.Radius;
            return Result;
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
    class programm
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(5, 4);
            Square square = new Square(5);
            Circle circle = new Circle(5);

            rect.Print();
            square.Print();
            circle.Print();
            Console.ReadLine();
        }
    }
}
