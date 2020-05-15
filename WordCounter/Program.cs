using System;
using WordCounter.Models;

namespace WordCounter
{
  public class Program
  {
    public static void Main()
    {
      bool isFinished = false;
      string userWord = "";
      string userSentence = "";
      bool wordIsValid = false;
      bool sentenceIsValid = false;
      RepeatCounter wordCount;

      while (!isFinished)
      {
        Console.WriteLine("Enter \"ESC\" at any time to quit.");
        if (!wordIsValid)
        {
          userWord = GetWord();
          wordIsValid = true;
        }

        if (!sentenceIsValid)
        {
          userSentence = GetSentence();
          sentenceIsValid = true;
        }

        wordCount = new RepeatCounter(userWord, userSentence);

        if (!wordCount.ValidateWord())
        {
          Console.WriteLine("Sorry, your word \"" + userWord + "\" is invalid. Please try again.");
          wordIsValid = false;
        }

        if (!wordCount.ValidateSentence())
        {
          Console.WriteLine("Sorry your sentence \"" + userSentence + "\"is invalid. Please try again.");
          wordIsValid = false;
        }

        if (wordIsValid && sentenceIsValid)
        {
          DisplayResults(wordCount);
          wordIsValid = false;
          sentenceIsValid = false;
        }
      }
    }

    public static string GetWord()
    {
      Console.Write("Enter a word: ");
      string input = Console.ReadLine();
      return input;
    }

    public static string GetSentence()
    {
      Console.Write("Enter a sentence: ");
      string input = Console.ReadLine();
      return input;
    }

    public static void DisplayResults(RepeatCounter wordCount)
    {
      Console.Clear();
      Console.WriteLine("------------------------------------------------------------------------------------");
      Console.WriteLine("The word \"" + wordCount.Word + "\" appeared " + wordCount.GetWordCount() + " times.");
      Console.WriteLine("------------------------------------------------------------------------------------");
    }
  }
}