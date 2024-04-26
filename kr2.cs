using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Дай мне 2 слова через пробел:");
        string input = Console.ReadLine();
        string[] words = input.Split(' ');
        if (words.Length != 2)
        {
            Console.WriteLine("Ну ты че 2 слова сказал");
            return;
        }
        string result = RemoveLetters(words[0], words[1]);
        Console.WriteLine("Итого:");
        Console.WriteLine(result + " " + words[1]);
    }
    static string RemoveLetters(string firstWord, string secondWord)
    {
        string result = "";
        foreach (char c in firstWord)
        {
            if (!secondWord.Contains(c))
            {
                result += c;
            }
        }
        return result;
    }
}

/*
using system;

class mainclass
{
    public static void main(string[] args)
    {
        console.writeline("дай мне текст:");
        string input = console.readline();
        char[] chars = input.tochararray();
        string output = "";

        for (int i = 0; i < chars.length; i++)
        {
            if (char.isletter(chars[i]))
            {
                if (i % 2 == 0)
                {
                    output += char.toupper(chars[i]);
                }
                else
                {
                    output += char.tolower(chars[i]);
                }
            }
            else
            {
                output += chars[i];
            }
        }
        console.writeline(output);
    }
}
*/