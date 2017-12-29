using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lab6_1
{
    class Program
    {
        public delegate float roots(float p1, int p2);

        static roots discr = (float p1, int p2) =>
        {
            return p1 * p1 - 4 * p2;

        };
        static Func<float, int, float> discr1 = (float p1, int p2) =>
        {
            return p1 * p1 - 4 * p2;

        };
        static float Findroot(float p1, int p2)
        {
            return p1 / (2 * p2);
        }



        static void equation(int a, int b, int c, roots discr, roots root)
        {
            if (discr(b, a * c) > 0)
            {
                Console.WriteLine("1 корень: " + root(-b + discr(b, a * c), a));
                Console.WriteLine("2 корень: " + root(-b - discr(b, a * c), a));
            }
            else
                if (discr(b, a * c) == 0)
                Console.WriteLine("Корень: " + root(-b, a));

            else
                if (discr(b, a * c) < 0)
                Console.WriteLine("Нет корней");
        }

        static void equation1(int a, int b, int c, Func<float, int, float> discr, Func<float, int, float> root)
        {
            if (discr(b, a * c) > 0)
            {
                Console.WriteLine("1 корень: " + root(-b + discr(b, a * c), a));
                Console.WriteLine("2 корень: " + root(-b - discr(b, a * c), a));
            }
            else
                if (discr(b, a * c) == 0)
                Console.WriteLine("Корень: " + root(-b, a));

            else
                if (discr(b, a * c) < 0)
                Console.WriteLine("Нет корней");
        }

        static void Main(string[] args)
        {
            int a, b, c;
            Console.WriteLine("Введите a, b, c");
            Console.Write("a: ");
            a = Int32.Parse(Console.ReadLine());
            Console.Write("b: ");
            b = Int32.Parse(Console.ReadLine());
            Console.Write("c: ");
            c = Int32.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Поиск корней с использованием делегатов и выражения лямбда:");
            equation(a, b, c, discr, Findroot);

            Console.WriteLine();
            Console.WriteLine("Нахождение корней с помощью функции:");
            equation1(a, b, c, discr1, Findroot);

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.Read();
        }
    }
}