using System;
using DroneControlSystem;
using System.IO;
using System.Text.Json;


drone[] drones =
{
    new drone("DJI Mini 3", 85),
    new drone("Autel EVO Lite", 45),
    new drone("Parrot Anafi", 15),
    new drone("DJI Air 3")
};

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== Система управления БПЛА (версия 3.0) ===");
    Console.WriteLine("1. Показать информацию о всех дронах");
    Console.WriteLine("2. Взлёт выбранного дрона");
    Console.WriteLine("3. Подзарядка выбранного дрона");
    Console.WriteLine("4. Расчёт времени полёта");
    Console.WriteLine("5. Сохранить состояние в файл");
    Console.WriteLine("6. Загрузить состояние из файла");
    Console.WriteLine("0. Выход");
    Console.Write("Выберите действие: ");

    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("Ошибка! Введите число.");
        continue;
    }

    if (choice == 0)
    {
        Console.WriteLine("Выход из программы.");
        break;
    }

    if (choice == 5)
    {
        SaveDrones(drones, "drones.json");
        continue;
    }

    if (choice == 6)
    {
        drones = LoadDrones("drones.json");
        Console.WriteLine("Загрузка завершена!");
        continue;
    }

    if (choice == 1)
    {
        foreach (drone d in drones)
        {
            d.PrintInfo();
        }
        continue;
    }

    if (choice == 5 || choice == 6)
    {
        Console.WriteLine("Эту функцию добавим в задании 2.");
        continue;
    }

    if (choice < 2 || choice > 4)
    {
        Console.WriteLine("Такого пункта меню нет.");
        continue;
    }

    Console.WriteLine();
    Console.WriteLine("Список дронов:");

    for (int i = 0; i < drones.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {drones[i].Model}");
    }

    Console.Write("Выберите номер дрона: ");

    if (!int.TryParse(Console.ReadLine(), out int number) ||
        number < 1 || number > drones.Length)
    {
        Console.WriteLine("Неверный номер дрона!");
        continue;
    }

    drone selectedDrone = drones[number - 1];

    try
    {
        switch (choice)
        {
            case 2:
                selectedDrone.TakeOff();
                break;

            case 3:
                Console.Write("Сколько процентов зарядить? ");

                if (int.TryParse(Console.ReadLine(), out int amount)
                    && amount > 0 && amount <= 100)
                {
                    selectedDrone.ChargeBattery(amount);
                    selectedDrone.PrintInfo();
                }
                else
                {
                    Console.WriteLine("Введите число от 1 до 100.");
                }
                break;

            case 4:
                selectedDrone.CalculateFlightTime();
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ошибка: " + ex.Message);
    }
}

static void SaveDrones(drone[] drones, string fileName)
{
    var options = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    string json = JsonSerializer.Serialize(drones, options);
    File.WriteAllText(fileName, json);

    Console.WriteLine("Состояние дронов сохранено!");
}

static drone[] LoadDrones(string fileName)
{
    if (!File.Exists(fileName))
    {
        Console.WriteLine("Файл не найден!");
        return Array.Empty<drone>();
    }

    string json = File.ReadAllText(fileName);

    return JsonSerializer.Deserialize<drone[]>(json)
           ?? Array.Empty<drone>();
}