using System;
using System.Collections.Generic;
using System.Linq;

class PlayfairCipher
{
    private const string Alphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
    private char[,] matrix;

    public PlayfairCipher(string key)
    {
        if (key.Length < 7) throw new ArgumentException("Ключ должен содержать не менее 7 символов.");
        matrix = GenerateMatrix(key);
    }

    private char[,] GenerateMatrix(string key)
    {
        string fullKey = new string((key.ToUpper() + Alphabet).Distinct().ToArray());
        char[,] mat = new char[4, 8]; // Матрица 4 строки, 8 столбцов
        int index = 0;
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 8; j++)
                if (index < fullKey.Length)
                    mat[i, j] = fullKey[index++];
        return mat;
    }

    public void PrintMatrix()
    {
        Console.WriteLine("Матрица шифра Плейфера:");
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    private (int, int) FindPosition(char c)
    {
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 8; j++)
                if (matrix[i, j] == c) return (i, j);
        throw new Exception("Символ не найден в матрице.");
    }

    private string PrepareText(string text)
    {
        text = text.ToUpper().Replace("Ё", "Е");
        List<char> formatted = new List<char>();

        // Пропускаем пробелы и проверяем, что только буквы русского алфавита
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == ' ') continue;  // Игнорируем пробелы
            if (!Alphabet.Contains(text[i]))
                throw new ArgumentException("Допустимы только буквы русского алфавита.");

            formatted.Add(text[i]);

            // Если подряд два одинаковых символа, вставляем 'Х'
            if (i < text.Length - 1 && text[i] == text[i + 1])
                formatted.Add('Х');
        }

        // Если длина текста нечетная, добавляем 'Х'
        if (formatted.Count % 2 != 0) formatted.Add('Х');

        return new string(formatted.ToArray());
    }

    private string Process(string text, int shift)
    {
        text = PrepareText(text); // Подготовка текста
        string result = "";
    
        // Перебираем текст по парам
        for (int i = 0; i < text.Length; i += 2)
        {
            var (x1, y1) = FindPosition(text[i]);  // Находим позицию первого символа
            var (x2, y2) = FindPosition(text[i + 1]);  // Находим позицию второго символа
        
            if (x1 == x2) // Если символы в одной строке
            {
                result += matrix[x1, (y1 + shift + 8) % 8];
                result += matrix[x2, (y2 + shift + 8) % 8];
            }
            else if (y1 == y2) // Если символы в одном столбце
            {
                result += matrix[(x1 + shift + 4) % 4, y1];
                result += matrix[(x2 + shift + 4) % 4, y2];
            }
            else // Если символы образуют прямоугольник
            {
                result += matrix[x1, y2];
                result += matrix[x2, y1];
            }
        }
        return result;
    }

    public string Encrypt(string plaintext) => Process(plaintext, 1);
    public string Decrypt(string ciphertext) => Process(ciphertext, -1);
public static void Run()
    {
        Console.Write("Введите ключ (не менее 7 символов): ");
        string key = Console.ReadLine().ToUpper();

        PlayfairCipher cipher = new PlayfairCipher(key);
        cipher.PrintMatrix();
        
        int choice;
        do
        {
            Console.Write("Выберите операцию (1 - шифрование, 2 - дешифрование): ");
        } while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2));

        Console.Write("Введите текст: ");
        string input = Console.ReadLine().ToUpper();

        string output = choice == 1 ? cipher.Encrypt(input) : cipher.Decrypt(input);
        Console.WriteLine($"Результат: {output}");
    }
}
