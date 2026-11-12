namespace DroneControlSystem;

public class drone
{
    // Поля класса (примитивные типы)
    public string Model { get; set; }
    public int BatteryLevel { get; set; } // заряд от 0 до 100
    public double Altitude { get; set; }   // высота в метрах
    public bool IsEngineOn { get; set; }
    // Конструктор
    public drone()
    {
        Model = "";
        BatteryLevel = 100;
        Altitude = 0;
        IsEngineOn = false;
    }
    public drone(string model, int batteryLevel)
    {
        Model = model;
        BatteryLevel = batteryLevel;
        Altitude = 0;
        IsEngineOn = false;
    }
    public drone(string model) : this(model, 100)
    {
    }
    // Метод для вывода информации о дроне
    public void PrintInfo()
    {
        Console.WriteLine($"Модель: {Model}");
        Console.WriteLine($"Заряд батареи: {BatteryLevel}%");
        Console.WriteLine($"Высота: {Altitude:F1} м");
        Console.WriteLine($"Двигатель: {(IsEngineOn ? "включён" : "выключен")}");
    }
    // Метод для взлёта (простая логика с условием)
    public void TakeOff()
    {
        if (BatteryLevel < 20)
        {
            Console.WriteLine("Недостаточно заряда для взлёта (нужно минимум 20%).");
            return;
        }
        IsEngineOn = true;
        Altitude = 10.0;
        BatteryLevel -= 5;
        Console.WriteLine($"{Model} взлетел на высоту 10 м. Заряд: {BatteryLevel}%");
    }

public void ChargeBattery(int amount)
    {
        BatteryLevel += amount;
        if (BatteryLevel > 100)
        {
            BatteryLevel = 100;
        }
        Console.WriteLine($"Заряд после подзарядки: {BatteryLevel}%");
    }
    public void CalculateFlightTime()
    {
        double flightTime = BatteryLevel * 0.3;

        Console.WriteLine(
            $"Дрон {Model}: примерное время полёта {flightTime:F1} минут");
    }
}
