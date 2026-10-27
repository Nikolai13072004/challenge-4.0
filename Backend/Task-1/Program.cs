using System;

const string AllowedSpecialSymbols = "!@#$%^&*()-_=+?";

Console.WriteLine("=== ВРАТА ЗАМКА ===");
Console.WriteLine();
Console.Write("Введите код доступа: ");
string code = Console.ReadLine();

Console.WriteLine();
Console.WriteLine("Проверка кода...");
Console.WriteLine();

string[] violations = new string[8];
int violationCount = 0;

if (!HasCorrectLength(code))
{
    violations[violationCount] = "Длина кода должна составлять от 8 до 16 символов.";
    violationCount++;
}

if (!HasUppercaseLetter(code))
{
    violations[violationCount] = "Нет заглавной латинской буквы.";
    violationCount++;
}

if (!HasLowercaseLetter(code))
{
    violations[violationCount] = "Нет строчной латинской буквы.";
    violationCount++;
}

if (!HasDigit(code))
{
    violations[violationCount] = "Нет цифры.";
    violationCount++;
}

if (HasSpace(code))
{
    violations[violationCount] = "Код не должен содержать пробелы.";
    violationCount++;
}

if (HasThreeIdenticalCharacters(code))
{
    violations[violationCount] = "Обнаружены три одинаковых символа подряд.";
    violationCount++;
}

if (!StartsWithLetter(code))
{
    violations[violationCount] = "Первый символ кода должен быть буквой.";
    violationCount++;
}

if (!HasCorrectLastCharacter(code, AllowedSpecialSymbols))
{
    violations[violationCount] = "Последний символ должен быть цифрой или разрешённым специальным символом.";
    violationCount++;
}

if (violationCount == 0)
{
    Console.WriteLine("Код принят.");
    Console.WriteLine();
    Console.WriteLine("Ворота открываются. Багги может пройти!");
}
else
{
    Console.WriteLine("Код отклонён.");
    Console.WriteLine();
    Console.WriteLine("Нарушения:");
    Console.WriteLine();

    for (int i = 0; i < violationCount; i++)
    {
        Console.WriteLine("- " + violations[i]);
    }
}

bool HasCorrectLength(string value)
{
    return value.Length >= 8 && value.Length <= 16;
}

bool HasUppercaseLetter(string value)
{
    for (int i = 0; i < value.Length; i++)
    {
        if (value[i] >= 'A' && value[i] <= 'Z')
        {
            return true;
        }
    }

    return false;
}

bool HasLowercaseLetter(string value)
{
    for (int i = 0; i < value.Length; i++)
    {
        if (value[i] >= 'a' && value[i] <= 'z')
        {
            return true;
        }
    }

    return false;
}

bool HasDigit(string value)
{
    for (int i = 0; i < value.Length; i++)
    {
        if (value[i] >= '0' && value[i] <= '9')
        {
            return true;
        }
    }

    return false;
}

bool HasSpace(string value)
{
    for (int i = 0; i < value.Length; i++)
    {
        if (value[i] == ' ')
        {
            return true;
        }
    }

    return false;
}

bool HasThreeIdenticalCharacters(string value)
{
    for (int i = 0; i < value.Length - 2; i++)
    {
        if (value[i] == value[i + 1] && value[i] == value[i + 2])
        {
            return true;
        }
    }

    return false;
}

bool StartsWithLetter(string value)
{
    if (value.Length == 0)
    {
        return false;
    }

    char firstCharacter = value[0];

    return (firstCharacter >= 'A' && firstCharacter <= 'Z')
        || (firstCharacter >= 'a' && firstCharacter <= 'z');
}

bool HasCorrectLastCharacter(string value, string allowedSpecialSymbols)
{
    if (value.Length == 0)
    {
        return false;
    }

    char lastCharacter = value[value.Length - 1];

    if (lastCharacter >= '0' && lastCharacter <= '9')
    {
        return true;
    }

    for (int i = 0; i < allowedSpecialSymbols.Length; i++)
    {
        if (lastCharacter == allowedSpecialSymbols[i])
        {
            return true;
        }
    }

    return false;
}
