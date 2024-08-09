using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.Clear();

        var numberWords = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            { "ноль", 0 }, { "один", 1 }, { "два", 2 }, { "три", 3 }, { "четыре", 4 },
            { "пять", 5 }, { "шесть", 6 }, { "семь", 7 }, { "восемь", 8 }, { "девять", 9 },
            { "десять", 10 }, { "одиннадцать", 11 }, { "двенадцать", 12 }, { "тринадцать", 13 },
            { "четырнадцать", 14 }, { "пятнадцать", 15 }, { "шестнадцать", 16 }, { "семнадцать", 17 },
            { "восемнадцать", 18 }, { "девятнадцать", 19 }, { "двадцать", 20 }, { "тридцать", 30 },
            { "сорок", 40 }, { "пятьдесят", 50 }, { "шестьдесят", 60 }, { "семьдесят", 70 },
            { "восемьдесят", 80 }, { "девяносто", 90 }, { "сто", 100 }, { "двести", 200 },
            { "триста", 300 }, { "четыреста", 400 }, { "пятьсот", 500 }, { "шестьсот", 600 },
            { "семьсот", 700 }, { "восемьсот", 800 }, { "девятьсот", 900 }, { "тысяча", 1000 },
            { "тысяч", 1000 }, { "миллион", 1000000 }, { "миллионов", 1000000 }
        };

        int firstNumber = GetNumberFromUser("Введите первое число (цифрой или словом): ", numberWords);
        Console.Clear();

        int secondNumber = GetNumberFromUser("Введите второе число (цифрой или словом): ", numberWords);
        Console.Clear();

        char operation = GetOperationFromUser();
        Console.Clear();

        if (operation == '5')
        {
            PrintRandomJoke();
        }
        else
        {
            double result = PerformOperation(firstNumber, secondNumber, operation);
            PrintWithTypingEffect($"Результат: {firstNumber} {operation} {secondNumber} = {result}\n");
        }
    }

    static int GetNumberFromUser(string message, Dictionary<string, int> numberWords)
    {
        while (true)
        {
            PrintWithTypingEffect(message);
            string input = Console.ReadLine().ToLower();

            if (int.TryParse(input, out int number))
            {
                return number;
            }
            else
            {
                int result = ConvertWordsToNumber(input, numberWords);
                if (result != -1)
                {
                    return result;
                }

                Console.Clear();
                PrintWithTypingEffect("Ошибка: Введите корректное число (цифрой или словом).\n");
            }
        }
    }

    static int ConvertWordsToNumber(string input, Dictionary<string, int> numberWords)
    {
        string correctedInput = CorrectSpelling(input, numberWords.Keys.ToList());
        if (correctedInput != null)
        {
            input = correctedInput;
        }

        string[] words = input.Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
        int total = 0;
        int current = 0;

        foreach (var word in words)
        {
            if (numberWords.TryGetValue(word, out int value))
            {
                if (value >= 1000)
                {
                    current = (current == 0 ? 1 : current) * value;
                    total += current;
                    current = 0;
                }
                else if (value >= 100)
                {
                    current = (current == 0 ? 1 : current) * value;
                }
                else
                {
                    current += value;
                }
            }
            else
            {
                return -1;
            }
        }

        return total + current;
    }

    static char GetOperationFromUser()
    {
        while (true)
        {
            PrintWithTypingEffect("Выберите операцию:\n");
            PrintWithTypingEffect("1. Сложение (+)\n");
            PrintWithTypingEffect("2. Вычитание (-)\n");
            PrintWithTypingEffect("3. Умножение (*)\n");
            PrintWithTypingEffect("4. Деление (/)\n");
            PrintWithTypingEffect("Введите номер операции (1-4): ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    return '+';
                case "2":
                    return '-';
                case "3":
                    return '*';
                case "4":
                    return '/';
                case "5":
                    return '5';
                default:
                    Console.Clear();
                    PrintWithTypingEffect("Ошибка: Введите корректный номер операции (1-4).\n");
                    break;
            }
        }
    }

    static double PerformOperation(int firstNumber, int secondNumber, char operation)
    {
        return operation switch
        {
            '+' => firstNumber + secondNumber,
            '-' => firstNumber - secondNumber,
            '*' => firstNumber * secondNumber,
            '/' when secondNumber != 0 => (double)firstNumber / secondNumber,
            '/' => throw new DivideByZeroException("Деление на ноль невозможно."),
            _ => throw new InvalidOperationException("Неподдерживаемая операция.")
        };
    }

    static void PrintRandomJoke()
    {
        var jokes = new List<string>
        {
            "— Почему программисты путают Хэллоуин и Рождество? — Потому что 31 октября = 25 декабря.",
            "Всё может быть произведено в Китае, кроме творчества.",
            "— Какой язык программистов самый короткий? — Язык SQL, потому что он «сел» и пишет запросы.",
            "Когда программисты говорят о своих проблемах, в разговоре всегда есть: ошибка, баг, баг-репорт и coffee.",
            "Как понять, что программист влюбился? — Он ищет ваш код в своем GitHub.",
            "В мире много кода, но я найду время, чтобы написать свой.",
            "— Сколько программистов нужно, чтобы поменять лампочку? — Ни одного, это проблема аппаратного обеспечения.",
            "Код без багов, как единорог: все говорят, но никто не видел.",
            "— Почему программистам так сложно общаться? — Потому что они говорят на разных языках программирования.",
            "Опытный программист знает, что неважно, сколько ты знаешь языков, важно, как быстро ты учишься новому."
        };

        Random rnd = new Random();
        string randomJoke = jokes[rnd.Next(jokes.Count)];
        PrintWithTypingEffect(randomJoke + "\n");
    }

    static string CorrectSpelling(string input, List<string> validWords)
    {
        string bestMatch = null;
        int bestDistance = int.MaxValue;

        foreach (var word in validWords)
        {
            int distance = LevenshteinDistance(input, word);
            if (distance < bestDistance)
            {
                bestDistance = distance;
                bestMatch = word;
            }
        }

        return bestDistance <= 2 ? bestMatch : null;
    }

    static int LevenshteinDistance(string source, string target)
    {
        int[,] d = new int[source.Length + 1, target.Length + 1];

        for (int i = 0; i <= source.Length; i++)
            d[i, 0] = i;

        for (int j = 0; j <= target.Length; j++)
            d[0, j] = j;

        for (int i = 1; i <= source.Length; i++)
        {
            for (int j = 1; j <= target.Length; j++)
            {
                int cost = (source[i - 1] == target[j - 1]) ? 0 : 1;
                d[i, j] = Math.Min(
                    Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                    d[i - 1, j - 1] + cost);
            }
        }

        return d[source.Length, target.Length];
    }

    // Метод для вывода текста с эффектом печати
    static void PrintWithTypingEffect(string message, int typingSpeed = 30)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(typingSpeed);
        }
    }
}
