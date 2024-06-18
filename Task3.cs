using System;
using System.Collections.Generic;
using System.Linq;


public class Task3
{
    public class Searcher
    {
        private string input;
        private List<string> output;

        public string Input
        {
            get { return input; }
        }

        public string[] Output
        {
            get { return output.ToArray(); }
        }

        public Searcher(string text)
        {
            input = text;
            output = new List<string>();
            FindPalindromes();
        }

        private void FindPalindromes()
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            string[] words = input.Split(new char[] { ' ', ',', '.', '!', '?', ';', ':', '-', '_', '(', ')', '[', ']', '{', '}', '"' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                if (word.Length > 1 && IsPalindrome(word))
                {
                    output.Add(word);
                }
            }
        }

        private bool IsPalindrome(string word)
        {
            int length = word.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (word[i] != word[length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            if (output == null || output.Count == 0)
            {
                return string.Empty;
            }

            return string.Join(Environment.NewLine, output);
        }
    }
}