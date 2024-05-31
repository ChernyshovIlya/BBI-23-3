using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Thread task1Thread = new Thread(Task1);
        Thread task2Thread = new Thread(Task2);
        Thread task3Thread = new Thread(Task3);

        task1Thread.Start();
        task2Thread.Start();
        task3Thread.Start();

        task1Thread.Join();
        task2Thread.Join();
        task3Thread.Join();

        Console.WriteLine("Все сделано!");
    }

    static void Task1()
    {
        string inputText = "Раз два три четыре пять с детства с рифмой я дружу. Иногда я в вуз хожу. На глаголы не рифмую никогда в жизни";
        string shortestSentence = FindShortestSentence(inputText);
        Console.WriteLine("Самое короткое предложение: " + shortestSentence);
    }

    static string FindShortestSentence(string text)
    {
        int currentShortestLength = int.MaxValue;
        string shortestSentence = "";
        string currentSentence = "";

        foreach (char c in text)
        {
            if (c != '.' && c != '?' && c != '!')
            {
                currentSentence += c;
            }
            else
            {
                currentSentence = currentSentence.Trim();
                if (currentSentence.Length > 0 && currentSentence.Length < currentShortestLength)
                {
                    currentShortestLength = currentSentence.Length;
                    shortestSentence = currentSentence;
                }
                currentSentence = "";
            }
        }

        return shortestSentence;
    }

    static void Task2()
    {
        string input = "Один два, три! 4етыре пять-шесть семь восемь_девять десять";
        string[] words = input.Split(' ');
        string result = "";

        for (int i = 0; i < words.Length; i++)
        {
            bool isValidWord = true;
            for (int j = 0; j < words[i].Length; j++)
            {
                if (!Char.IsLetter(words[i][j]))
                {
                    isValidWord = false;
                    break;
                }
            }
            if (i == 0 || isValidWord)
            {
                result += words[i] + " ";
            }
        }
        Console.WriteLine(result.TrimEnd());
    }

    static void Task3()
    {
        string desktopPath = @"C:\Users\m2307205\Desktop";
        string folderName = "Fourth task";
        string file1Name = "string_1.json";
        string file2Name = "string_2.json";

        string folderPath = Path.Combine(desktopPath, folderName);
        string file1Path = Path.Combine(folderPath, file1Name);
        string file2Path = Path.Combine(folderPath, file2Name);

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        if (!File.Exists(file1Path))
        {
            File.Create(file1Path).Dispose();
        }

        if (!File.Exists(file2Path))
        {
            File.Create(file2Path).Dispose();
        }

        Console.WriteLine("Папка и файлы созданы на рабочем столе.");
    }
}
