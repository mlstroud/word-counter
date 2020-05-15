using System;

namespace WordCounter
{
  public class Program
  {
    public static void Main()
    {
      bool isFinished = false;
      string userWord;
      string userSentence;

      while (!isFinished)
      {
        userWord = GetWord();
      }
    }

    public static string GetWord()
    {
      Console.Write("Enter a word: ");
      string input = Console.ReadLine();
      return input;
    }
  }
}