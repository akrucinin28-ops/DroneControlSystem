using DroneControlSystem;
Console.WriteLine("=== Система управления БПЛА (версия 1.0) ===\n");
// Создание объекта дрона с помощью конструктора
drone myDrone = new drone("DJI Mini 3", 85);
drone[] drones = new drone[]
{
new drone("DJI Mini 3", 85),
new drone("Autel EVO Lite", 45),
new drone("Parrot Anafi", 15)
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
