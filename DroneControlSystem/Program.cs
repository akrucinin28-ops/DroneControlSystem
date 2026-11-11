using DroneControlSystem;
Console.WriteLine("=== Система управления БПЛА (версия 2.0) ===");
// Создание объекта дрона с помощью конструктора
Console.Write("Введите команду (1 — взлёт, 2 — расчёт времени, 0 — выход): ");
string input = Console.ReadLine();
if (!int.TryParse(input, out int command))
{
    Console.WriteLine("Ошибка: введите число.");
}
drone myDrone = new drone("DJI Mini 3", 85);
drone[] drones = new drone[]
{
new drone("DJI Mini 3", 85),
new drone("Autel EVO Lite", 45),
new drone("Parrot Anafi", 15),
new drone("DJI Air 3")
};

foreach (drone drone in drones)
{
    drone.PrintInfo();

    if (drone.BatteryLevel < 20)
    {
        Console.WriteLine("Внимание низкий заряд баттери");
    }

    Console.WriteLine();


    Console.WriteLine("Проверка завершена.");

    foreach (drone d in drones)
    {
        if (d.BatteryLevel < 50)
        {
            Console.WriteLine($"Дрон {d.Model}: заряд {d.BatteryLevel}%");
            Console.WriteLine("Подзарядить? (да/нет): ");

            string answer = Console.ReadLine();

            if (answer == "да")
            {
                d.ChargeBattery(30);
            }
        }
    }
}
