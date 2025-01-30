using System;
class Lab1Task2
{
    public static void Run()
    {
        Console.WriteLine("Running Lab 1 Task 2: Caesar Cipher with 2 Key");
        Console.WriteLine("Enter the first key (1-25):");
        int key1;
        while (!int.TryParse(Console.ReadLine(), out key1) || key1 < 1 || key1 > 25)
        {
            Console.WriteLine("Invalid key. Please enter a number between 1 and 25.");
        }

        Console.WriteLine("Enter the second key (minimum length 7, Latin letters only):");
        string key2;
        while (true)
        {
            key2 = Console.ReadLine().ToUpper().Replace(" ", "");
            if (IsValidKey2(key2)) break;
            Console.WriteLine("Invalid key. It must be at least 7 Latin letters.");
        }

        Console.WriteLine("Enter the message (A-Z or a-z only):");
        string message = Console.ReadLine();
        
        message = ProcessMessage(message);
        if (message == null)
        {
            Console.WriteLine("Invalid message. Only A-Z and a-z characters are allowed.");
            return;
        }

        string encryptedMessage = Encrypt(message, key1, key2);
        Console.WriteLine($"Encrypted Message: {encryptedMessage}");
    }

    static bool IsValidKey2(string key)
    {
        if (key.Length < 7) return false;
        foreach (char c in key)
        {
            if (c < 'A' || c > 'Z') return false;
        }
        return true;
    }

    static string ProcessMessage(string message)
    {
        message = message.ToUpper().Replace(" ", "");
        foreach (char c in message)
        {
            if (c < 'A' || c > 'Z') return null;
        }
        return message;
    }

    static string Encrypt(string message, int key1, string key2)
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string result = "";
        int key2Index = 0;

        foreach (char c in message)
        {
            int originalPos = FindPosition(alphabet, c);
            
            // Apply both keys: shift by key1 and the current letter from key2
            int key2Shift = FindPosition(alphabet, key2[key2Index]);
            int newPos = (originalPos + key1 + key2Shift) % 26;

            result += alphabet[newPos];

            key2Index = (key2Index + 1) % key2.Length;
        }

        return result;
    }

    static int FindPosition(string alphabet, char letter)
    {
        for (int i = 0; i < alphabet.Length; i++)
        {
            if (alphabet[i] == letter)
            {
                return i;
            }
        }
        return -1;
    }
}