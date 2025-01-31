namespace CS_Labs.Lab3;
using System;
using System.Text;

class PlayfairCipher
{
    private static string alphabet = "АБВГҐДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЫЭЮЯ";
    private static string[,] table = new string[5, 5];

    // Метод для удаления пробелов и перевода в верхний регистр
    private static string CleanInput(string input)
    {
        StringBuilder cleaned = new StringBuilder();
        foreach (char c in input.ToUpper())
        {
            if (alphabet.Contains(c.ToString()))
            {
                cleaned.Append(c);
            }
        }
        return cleaned.ToString();
    }

    // Метод для построения таблицы Плейфера из ключа
    private static void CreateTable(string key)
    {
        bool[] used = new bool[alphabet.Length];
        int index = 0;

        // Добавляем ключ в таблицу
        foreach (char c in CleanInput(key))
        {
            if (!used[alphabet.IndexOf(c)])
            {
                table[index / 5, index % 5] = c.ToString();
                used[alphabet.IndexOf(c)] = true;
                index++;
            }
        }

        // Добавляем оставшиеся буквы алфавита
        for (int i = 0; i < alphabet.Length; i++)
        {
            if (!used[i])
            {
                table[index / 5, index % 5] = alphabet[i].ToString();
                index++;
            }
        }
    }

    // Метод для поиска пары символов в таблице
    private static (int, int) FindPosition(char c)
    {
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                if (table[row, col] == c.ToString())
                {
                    return (row, col);
                }
            }
        }
        return (-1, -1);
    }

    // Метод для шифрования или дешифрования пары символов
    private static string ProcessPair(char first, char second, bool encrypt)
    {
        var (row1, col1) = FindPosition(first);
        var (row2, col2) = FindPosition(second);

        if (row1 == row2)  // Одни и те же строки
        {
            col1 = (col1 + (encrypt ? 1 : -1) + 5) % 5;
            col2 = (col2 + (encrypt ? 1 : -1) + 5) % 5;
        }
        else if (col1 == col2)  // Один и тот же столбец
        {
            row1 = (row1 + (encrypt ? 1 : -1) + 5) % 5;
            row2 = (row2 + (encrypt ? 1 : -1) + 5) % 5;
        }
        else  // Прямоугольник
        {
            int temp = col1;
            col1 = col2;
            col2 = temp;
        }

        return table[row1, col1] + table[row2, col2];
    }

    // Метод для шифрования сообщения
    public static string Encrypt(string message)
    {
        StringBuilder encrypted = new StringBuilder();
        message = CleanInput(message);
        
        if (message.Length % 2 != 0)
        {
            message += "X";  // Если нечётное количество символов, добавляем "X"
        }

        for (int i = 0; i < message.Length; i += 2)
        {
            encrypted.Append(ProcessPair(message[i], message[i + 1], true));
        }

        return encrypted.ToString();
    }

    // Метод для дешифрования
    public static string Decrypt(string message)
    {
        StringBuilder decrypted = new StringBuilder();
        message = CleanInput(message);

        for (int i = 0; i < message.Length; i += 2)
        {
            decrypted.Append(ProcessPair(message[i], message[i + 1], false));
        }

        return decrypted.ToString();
    }

    public static void Run()
    {
        Console.WriteLine("Введите ключ (не менее 7 символов): ");
        string key = Console.ReadLine();
        if (key.Length < 7)
        {
            Console.WriteLine("Ключ должен быть не менее 7 символов.");
            return;
        }

        CreateTable(key);

        Console.WriteLine("Выберите операцию:\n1. Шифрование\n2. Дешифрование");
        string operation = Console.ReadLine();

        Console.WriteLine("Введите сообщение или криптограмму: ");
        string message = Console.ReadLine();

        if (operation == "1")
        {
            string encryptedMessage = Encrypt(message);
            Console.WriteLine("Зашифрованное сообщение: " + encryptedMessage);
        }
        else if (operation == "2")
        {
            string decryptedMessage = Decrypt(message);
            Console.WriteLine("Расшифрованное сообщение: " + decryptedMessage);
        }
        else
        {
            Console.WriteLine("Некорректный выбор операции.");
        }
    }
}
