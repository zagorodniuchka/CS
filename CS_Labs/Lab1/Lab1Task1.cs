using System;

class Lab1Task1
{
    public static void Run()
    {
        Console.WriteLine("Running Lab 1 Task 1: Caesar Cipher with 1 Key");

        Console.WriteLine("Choose an operation: 1 - Encrypt, 2 - Decrypt");
        string operation = Console.ReadLine();

        if (operation != "1" && operation != "2")
        {
            Console.WriteLine("Invalid operation. Please choose 1 for encryption or 2 for decryption.");
            return;
        }

        Console.WriteLine("Enter the key (1-25):");
        int key;
        while (!int.TryParse(Console.ReadLine(), out key) || key < 1 || key > 25)
        {
            Console.WriteLine("Invalid key. Please enter a number between 1 and 25.");
        }

        Console.WriteLine("Enter the message (A-Z or a-z only):");
        string message = Console.ReadLine();

        message = ProcessMessage(message);

        if (message == null)
        {
            Console.WriteLine("Invalid message. Only A-Z and a-z characters are allowed.");
            return;
        }

        string result = operation == "1" ? Encrypt(message, key) : Decrypt(message, key);

        Console.WriteLine($"Result: {result}");
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

    static string Encrypt(string message, int key)
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string result = "";

        foreach (char c in message)
        {
            int originalPos = FindPosition(alphabet, c);
            int newPos = (originalPos + key) % 26; // Caesar shift
            result += alphabet[newPos];
        }

        return result;
    }

    static string Decrypt(string message, int key)
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string result = "";

        foreach (char c in message)
        {
            int originalPos = FindPosition(alphabet, c);
            int newPos = (originalPos - key + 26) % 26; // Caesar shift backwards
            result += alphabet[newPos];
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
