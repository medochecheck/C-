using System;

namespace PointDistanceApp
{
    // Структура Point, представляющая трехмерную точку
    struct Point
    {
        public decimal X { get; }
        public decimal Y { get; }
        public decimal Z { get; }

        public Point(decimal x, decimal y, decimal z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    // Класс Informer
    class Informer
    {
        // Защищенный метод PrintToConsole, доступен только в производных классах
        protected void PrintToConsole(string data)
        {
            Console.WriteLine(data);
        }
    }

    // Класс Calculator, наследующий Informer
    class Calculator : Informer
    {
        // Метод для вычисления расстояния между двумя точками
        public void CalculateDistance(Point p1, Point p2)
        {
            decimal distance = (decimal)Math.Sqrt(
                (double)((p2.X - p1.X) * (p2.X - p1.X) +
                         (p2.Y - p1.Y) * (p2.Y - p1.Y) +
                         (p2.Z - p1.Z) * (p2.Z - p1.Z)));

            PrintToConsole($"Расстояние между точками: {distance:F2}");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите координаты для двух точек. Каждое значение вводится через Enter.");
            Console.WriteLine("Пример: для X, Y, Z точки 1 введите 1.2 (Enter), 3.4 (Enter), 5.6 (Enter).");

            // Ввод координат для первой точки
            Point point1 = ReadPointFromUser("первой");
            Point point2 = ReadPointFromUser("второй");

            // Создаем объект Calculator и вычисляем расстояние
            Calculator calculator = new Calculator();
            calculator.CalculateDistance(point1, point2);
        }

        // Метод для чтения точки от пользователя с проверкой корректности ввода
        static Point ReadPointFromUser(string pointName)
        {
            decimal x = ReadDecimal($"Введите координату X для {pointName} точки:");
            decimal y = ReadDecimal($"Введите координату Y для {pointName} точки:");
            decimal z = ReadDecimal($"Введите координату Z для {pointName} точки:");

            return new Point(x, y, z);
        }

        // Метод для чтения числа с проверкой
        static decimal ReadDecimal(string prompt)
        {
            decimal value;
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out value))
                    return value;
                Console.WriteLine("Ошибка: введите корректное число!");
            }
        }
    }
}
