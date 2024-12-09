using System;

// Интерфейс ICar
interface ICar
{
    int Capacity { get; set; } // Вместимость 

    void Start();              // Запуск автомобиля
    void Stop();               // Остановка автомобиля
    void Honk();               // Подать сигнал (гудок)
    void Refuel(double amount); // Заправить автомобиль
    string GetStatus();        // Получить текущий статус автомобиля
}

// Интерфейс Imovement
interface Imovement
{
    void MoveForward();  // Движение вперед
    void MoveBackward(); // Движение назад
    void MoveLeft();     // Движение влево
    void MoveRight();    // Движение вправо
}

// Абстрактный класс ACar
abstract class ACar : ICar
{
    public int Capacity { get; set; } 
    public Imovement Movement { get; set; } 

    public abstract void Start();
    public abstract void Stop();  

    public abstract void Honk(); 
    public abstract void Refuel(double amount); 
    public abstract string GetStatus(); 
}

// Класс ElectricMovement
class ElectricMovement : Imovement
{
    public void MoveForward()
    {
        Console.WriteLine("Электромобиль едет вперед.");
    }

    public void MoveBackward()
    {
        Console.WriteLine("Электромобиль едет назад.");
    }

    public void MoveLeft()
    {
        Console.WriteLine("Электромобиль поворачивает налево.");
    }

    public void MoveRight()
    {
        Console.WriteLine("Электромобиль поворачивает направо.");
    }
}

// Конкретный класс ElectricCar
class ElectricCar : ACar
{
    private double batteryLevel; // Уровень заряда батареи

    public ElectricCar()
    {
        Movement = new ElectricMovement(); // Установка движения типа ElectricMovement
        batteryLevel = 100; // Полный заряд
    }

    public override void Start()
    {
        Console.WriteLine("Электромобиль запускается.");
    }

    public override void Stop()
    {
        Console.WriteLine("Электромобиль останавливается.");
    }

    public override void Honk()
    {
        Console.WriteLine("Бип-бип! Электромобиль подает сигнал.");
    }

    public override void Refuel(double amount)
    {
        batteryLevel += amount;
        if (batteryLevel > 100)
            batteryLevel = 100; // Максимальный заряд 100%
        Console.WriteLine($"Электромобиль заряжен на {batteryLevel}%.");
    }

    public override string GetStatus()
    {
        return $"Электромобиль включен. Уровень заряда: {batteryLevel}%.";
    }
}

// Точка входа в программу
class Program
{
    static void Main(string[] args)
    {
        // Создание экземпляра ElectricCar
        ElectricCar myCar = new ElectricCar();
        myCar.Capacity = 4; // Задание вместимости

        myCar.Start();      // Запуск машины
        myCar.Honk();       // Подача сигнала
        Console.WriteLine(myCar.GetStatus()); // Получение статуса
        myCar.Refuel(20);   // Зарядка машины
        Console.WriteLine(myCar.GetStatus()); // Проверка статуса после зарядки
        myCar.Movement.MoveRight(); // Машина едет направо
        myCar.Stop();       // Остановка машины
    }
}