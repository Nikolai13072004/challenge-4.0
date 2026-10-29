using System;

int trustLevel = 0;
string choice = "";

while (choice != "0")
{
    ShowMenu(trustLevel);
    Console.Write("Выберите действие: ");
    choice = Console.ReadLine();
    Console.WriteLine();

    if (choice == "1")
    {
        trustLevel = ChangeTrust(trustLevel, 20);
        Console.WriteLine("Вы представились Хранителю и объяснили цель визита.");
        ShowTrustLevel(trustLevel);
    }
    else if (choice == "2")
    {
        trustLevel = ChangeTrust(trustLevel, 30);
        Console.WriteLine("Вы предложили помощь в защите замка.");
        ShowTrustLevel(trustLevel);
    }
    else if (choice == "3")
    {
        trustLevel = ChangeTrust(trustLevel, -20);
        Console.WriteLine("Вы пригрозили Хранителю.");
        ShowTrustLevel(trustLevel);
    }
    else if (choice == "4")
    {
        CheckAccess(trustLevel);
        ShowTrustLevel(trustLevel);
    }
    else if (choice == "0")
    {
        Console.WriteLine("Программа завершена.");
    }
    else
    {
        Console.WriteLine("Неизвестная команда. Выберите пункт от 0 до 4.");
        ShowTrustLevel(trustLevel);
    }

    Console.WriteLine();
}

void ShowMenu(int trust)
{
    Console.WriteLine("=== ХРАНИТЕЛЬ ===");
    Console.WriteLine("Уровень доверия: " + trust);
    Console.WriteLine();
    Console.WriteLine("1. Представиться и объяснить цель визита");
    Console.WriteLine("2. Предложить помощь в защите замка");
    Console.WriteLine("3. Пригрозить Хранителю");
    Console.WriteLine("4. Проверить доступ");
    Console.WriteLine("0. Выход");
    Console.WriteLine();
}

int ChangeTrust(int trust, int change)
{
    trust = trust + change;

    if (trust < 0)
    {
        trust = 0;
    }
    else if (trust > 100)
    {
        trust = 100;
    }

    return trust;
}

void CheckAccess(int trust)
{
    if (trust >= 50)
    {
        Console.WriteLine("Хранитель разрешает проход!");
    }
    else
    {
        Console.WriteLine("Хранитель отказывает в проходе.");
    }
}

void ShowTrustLevel(int trust)
{
    Console.WriteLine("Уровень доверия: " + trust);
}
