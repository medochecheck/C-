using System;
using System.Text;
using System.Text.RegularExpressions;

public class User
{
    // Публичное поле ID
    public int Id { get; set; }

    // Метод для получения полного имени и ID
    public string GetFullNameAndId(string name, string surname)
    {
        // StringBuilder для формирования строки
        StringBuilder sb = new StringBuilder();
        sb.Append(name)
          .Append(" ")
          .Append(surname)
          .Append(" c ID=")
          .Append(Id);

        return sb.ToString();
    }
}

class Program
{
    static void Main(string[] args)
    {
        /*
        User user = new User
        {
            Id = 4 
        };
        string fullNameAndId = user.GetFullNameAndId("Иван", "Петров");
        Console.WriteLine(fullNameAndId); // Ожидаемый вывод: Иван Петров c ID=4
        */

        // Вывод правил для ввода
        Console.WriteLine("Пожалуйста, следуйте следующим правилам при вводе имени и фамилии:");
        Console.WriteLine("1. Имя и фамилия должны содержать только буквы.");
        Console.WriteLine("2. Имя и фамилия должны начинаться с заглавной буквы.");
        Console.WriteLine("3. Поля не могут быть пустыми.");
        Console.WriteLine();

        User user = new User();

        // Уникальный ID назначается автоматически
        Random random = new Random();
        user.Id = random.Next(1, 1000);

        string name, surname;

        // Ввод имени с проверкой
        do
        {
            Console.Write("Введите имя: ");
            name = Console.ReadLine();
        } while (!IsValidNameOrSurname(name));

        // Ввод фамилии с проверкой
        do
        {
            Console.Write("Введите фамилию: ");
            surname = Console.ReadLine();
        } while (!IsValidNameOrSurname(surname));

        // Получение полного имени и ID
        string fullNameAndId = user.GetFullNameAndId(name, surname);

        // Вывод результата
        Console.WriteLine(fullNameAndId);
    }

    // Метод проверки на валидность имени или фамилии 
    private static bool IsValidNameOrSurname(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Поле не может быть пустым. Попробуйте снова.");
            return false;
        }

        // Проверяем, что строка содержит только буквы (русские или латинские)
        Regex regex = new Regex(@"^[\p{L}]+$");
        if (!regex.IsMatch(input))
        {
            Console.WriteLine("Ошибка: допускаются только буквы. Попробуйте снова.");
            return false;
        }

        // Проверяем, что первая буква заглавная
        if (!char.IsUpper(input[0]))
        {
            Console.WriteLine("Ошибка: имя и фамилия должны начинаться с заглавной буквы. Попробуйте снова.");
            return false;
        }

        return true;
    }
}
