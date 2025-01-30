using System;
using CS_Labs.Lab2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the lab and task number (e.g., lab1 t1 for Lab 1 Task 1):");
        string input = Console.ReadLine();

        switch (input.ToLower())
        {
            case "lab1 t1":
                Lab1Task1.Run();
                break;
            case "lab1 t2":
                Lab1Task2.Run();
                break;
            case "lab2":
                Lab2.Run();
                break;
            default:
                Console.WriteLine("Invalid lab/task selection.");
                break;
        }
    }
}