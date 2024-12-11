using System;
using System.Collections.Generic;

interface ICar
{
    int Capacity {get; set;} 
    void Start();              
    void Stop();               
    void Honk();               
    void Refuel(double amount); 
    string GetStatus();        
}

interface Imovement
{
    void MoveForward();  
    void MoveBackward(); 
    void MoveLeft();    
    void MoveRight();   
}

abstract class ACar : ICar
{
    public int Capacity {get; set;}
    public Imovement Movement {get; set;}
    public abstract void Start();
    public abstract void Stop();
    public abstract void Honk();
    public abstract void Refuel(double amount);
    public abstract string GetStatus();
}

class ElectricMovement : Imovement
{
    public void MoveForward() {Console.WriteLine("Электромобиль едет вперед.");}
    public void MoveBackward() {Console.WriteLine("Электромобиль едет назад.");}
    public void MoveLeft() {Console.WriteLine("Электромобиль поворачивает налево.");}
    public void MoveRight() {Console.WriteLine("Электромобиль поворачивает направо.");}
}

class ElectricCar : ACar
{
    private double batteryLevel; 
    public string Model {get; set;}
    public int BatteryCapacity {get; set;}
    public int Weight {get; set;} 

    public ElectricCar()
    {
        Movement = new ElectricMovement(); 
        batteryLevel = 100; 
    }

    public override void Start() {Console.WriteLine("Электромобиль запускается.");}
    public override void Stop() {Console.WriteLine("Электромобиль останавливается.");}
    public override void Honk() {Console.WriteLine("Бип-бип! Электромобиль подает сигнал.");}

    public override void Refuel(double amount)
    {
        batteryLevel += amount;
        if (batteryLevel > 100)
            batteryLevel = 100; 
        Console.WriteLine($"Электромобиль заряжен на {batteryLevel}%.");
    }

    public override string GetStatus() {return ($"Электромобиль включен. Уровень заряда: {batteryLevel}%.");}

    public override bool Equals(object obj)
    {
        if (obj is ElectricCar other)
        {
            return Model == other.Model && BatteryCapacity == other.BatteryCapacity && Weight == other.Weight;
        }
        return false;
    }

    public override int GetHashCode() {return Model.GetHashCode() ^ BatteryCapacity.GetHashCode() ^ Weight.GetHashCode();}
}

// Класс Tesla (наследующий от ElectricCar)
class Tesla : ElectricCar
{
    public string AutopilotVersion {get; set;}

    public override bool Equals(object obj)
    {
        if (obj is Tesla other)
        {
            return base.Equals(other) && AutopilotVersion == other.AutopilotVersion;
        }
        return false;
    }
    public override int GetHashCode() {return base.GetHashCode() ^ AutopilotVersion.GetHashCode();}
}

// Класс CarData для хранения и генерации автомобилей
class CarData
{
    public static readonly List<string> Models = new List<string> {"Model S", "Model 3", "Model X", "Model Y", "Generic EV"};
    public static readonly List<int> BatteryCapacities = new List<int> {50, 75, 90, 100};
    public static readonly List<string> AutopilotVersions = new List<string> {"v1", "v2", "v3"};
    public static readonly List<int> Weights = new List<int> {1500, 2000, 2500, 3000};

    public static ElectricCar GetRandomElectricCar()
    {
        Random random = new Random();
        return new ElectricCar
        {
            Model = Models[random.Next(Models.Count)],
            BatteryCapacity = BatteryCapacities[random.Next(BatteryCapacities.Count)],
            Weight = Weights[random.Next(Weights.Count)]
        };
    }

    public static Tesla GetRandomTesla()
    {
        Random random = new Random();
        return new Tesla
        {
            Model = Models[random.Next(Models.Count)],
            BatteryCapacity = BatteryCapacities[random.Next(BatteryCapacities.Count)],
            Weight = Weights[random.Next(Weights.Count)],
            AutopilotVersion = AutopilotVersions[random.Next(AutopilotVersions.Count)]
        };
    }
}

// Синглтон для CarInsurance
class CarInsurance
{
    private static CarInsurance _instance;
    private CarInsurance() {}

    public static CarInsurance Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new CarInsurance();
            }
            return _instance;
        }
    }

    public static decimal CalculateInsurance(ElectricCar car)
    {
        decimal basePrice = 500;
        decimal batteryFactor = car.BatteryCapacity * 10;
        decimal weightFactor = car.Weight * 0.2m;

        if (car is Tesla) {basePrice += 300;}
        return basePrice + batteryFactor + weightFactor;
    }
}

class Program
{
    static void Main(string[] args)
    {   
        ElectricCar[] cars = new ElectricCar[5];
        Random random = new Random();

        for (int i = 0; i < cars.Length; i++)
        {
            // Вероятность 50% 
            cars[i] = random.Next(2) == 0
                ? CarData.GetRandomTesla()
                : CarData.GetRandomElectricCar();
        }

        Console.WriteLine("Автомобили:");
        foreach (var car in cars)
        {
            if (car is Tesla tesla)
            {
                Console.WriteLine($"Tesla: {tesla.Model}, Battery: {tesla.BatteryCapacity}, Weight: {tesla.Weight}, Autopilot: {tesla.AutopilotVersion}");
            }
            else
            {
                Console.WriteLine($"ElectricCar: {car.Model}, Battery: {car.BatteryCapacity}, Weight: {car.Weight}");
            }
        }

        // Сравнение автомобилей
        Console.WriteLine("\nСравнение случайных автомобилей:");
        for (int i = 0; i < cars.Length - 1; i++)
        {
            bool areEqual = cars[i].Equals(cars[i + 1]);
            Console.WriteLine($"Car {i} == Car {i + 1}? {areEqual}");
        }

        // Расчёт стоимости страховки
        Console.WriteLine("\nСтоимость страховки:");
        foreach (var car in cars)
        {
            decimal insuranceCost = CarInsurance.CalculateInsurance(car);
            Console.WriteLine($"Model: {car.Model}, Insurance: {insuranceCost:C}");
        }
    }
}