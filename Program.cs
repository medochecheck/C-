using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите первое число: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите второе число: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double sum = num1 + num2;
        double difference = num1 - num2;
        double product = num1 * num2;

        string division = num2 != 0 ? (num1 / num2).ToString() : "Ошибка: деление на ноль невозможно";

        Console.WriteLine("\nРезультаты операций:");
        Console.WriteLine("Сложение: " + sum);
        Console.WriteLine("Вычитание: " + difference);
        Console.WriteLine("Умножение: " + product);
        Console.WriteLine("Деление: " + division);
    }
}
