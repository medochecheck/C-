using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        double num1, num2;

        // Только целые числа

        /*
        Console.Write("Введите первое число: ");
        while (!double.TryParse(Console.ReadLine(), out num1))
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
            Console.Write("Введите первое число: ");
        }

        // Ввод второго числа с проверкой
        Console.Write("Введите второе число: ");
        while (!double.TryParse(Console.ReadLine(), out num2))
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
            Console.Write("Введите второе число: ");
        }
        */


        // С учетом обработки десятичных дробей

        Console.Write("Введите первое число (дробная часть отделяется точкой или запятой): ");
        while (!TryParseDouble(Console.ReadLine(), out num1))
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
            Console.Write("Введите первое число: ");
        }


        // Ввод второго числа с проверкой

        Console.Write("Введите второе число (дробная часть отделяется точкой или запятой): ");
        while (!TryParseDouble(Console.ReadLine(), out num2))
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
            Console.Write("Введите второе число: ");
        }


        // Выполнение операций через отдельные функции

        double sum = Add(num1, num2);
        double difference = Subtract(num1, num2);
        double product = Multiply(num1, num2);
        string division = Divide(num1, num2);


        // Функция сложения

        double Add(double a, double b) { return a + b; }

        // Функция вычитания

        double Subtract(double a, double b) { return a - b; }

        // Функция умножения

        double Multiply(double a, double b) { return a * b; }

        // Функция деления с проверкой на ноль

        string Divide(double a, double b)
        { return b != 0 ? (a / b).ToString(CultureInfo.InvariantCulture) : "Ошибка: деление на ноль невозможно"; }


        Console.WriteLine("\nРезультаты операций:");
        Console.WriteLine("Сложение: " + sum.ToString(CultureInfo.InvariantCulture));
        Console.WriteLine("Вычитание: " + difference.ToString(CultureInfo.InvariantCulture));
        Console.WriteLine("Умножение: " + product.ToString(CultureInfo.InvariantCulture));
        Console.WriteLine("Деление: " + division);


        // Метод для обработки ввода с учетом разделителя точки и запятой

        bool TryParseDouble(string input, out double result)
        {
            if (double.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out result))
            {
                return true;
            }
            return double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }
    }
}
