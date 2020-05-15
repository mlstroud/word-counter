using System;
using System.Threading;
using WordCounter.Models;
using System.Collections.Generic;

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
          if (CheckForQuit(userWord)) break;
          wordIsValid = true;
        }

        if (!sentenceIsValid)
        {
          userSentence = GetSentence();
          if (CheckForQuit(userSentence)) break;
          sentenceIsValid = true;
        }

        wordCount = new RepeatCounter(userWord, userSentence);

        if (!wordCount.ValidateWord())
        {
          Console.Clear();
          Console.WriteLine("Sorry, your word \"" + userWord + "\" is invalid. Please try again.");
          wordIsValid = false;
        }

        if (!wordCount.ValidateSentence())
        {
          Console.Clear();
          Console.WriteLine("Sorry your sentence \"" + userSentence + "\" is invalid. Please try again.");
          sentenceIsValid = false;
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

    public static bool CheckForQuit(string input)
    {
      if (input.ToLower() == "esc")
      {
        Console.WriteLine("Thank you for using Word Counter. Goodbye.");
        return true;
      }
      else
      {
        return false;
      }
    }

    public static void DisplayResults(RepeatCounter wordCount)
    {
      Console.Clear();
      int wordTotalOccurrences = wordCount.GetWordCount();
      string[] sentenceOutput = wordCount.ParsedSentence.Split(" ");
      string[] originalSentence = wordCount.Sentence.Split(" ");

      LoadResults();

      Console.WriteLine("Searching your sentence for matches...");

      for (int word = 0; word < sentenceOutput.Length; word++)
      {
        if (sentenceOutput[word] == wordCount.ParsedWord)
        {
          Console.ForegroundColor = ConsoleColor.Green;
        }
        else
        {
          Console.ForegroundColor = ConsoleColor.White;
        }

        Console.Write(originalSentence[word] + " ");

        if (word == sentenceOutput.Length - 1)
        {
          Console.Write("\n");
        }
        Thread.Sleep(150);
      }
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("------------------------------------------------------------------------------------");
      Console.WriteLine("The word \"" + wordCount.Word + "\" appeared " + wordTotalOccurrences + " times.");
      Console.WriteLine("------------------------------------------------------------------------------------");
    }

    public static void LoadResults()
    {

      const char block = '■';
      int percentComplete = 0;
      Random random = new Random();
      int loadCycles = random.Next(7, 20);
      int loadPerCycle = 100 / loadCycles;
      int blocksToAdd = 0;
      char[] progressBar = new char[102];
      progressBar[0] = '[';
      progressBar[101] = ']';

      for (int i = 1; i < 101; i++)
      {
        progressBar[i] = ' ';
      }


      for (int i = 1; i < 101; i++)
      {
        Console.Clear();
        Console.WriteLine("Parsing your data...please wait.");
        progressBar[i] = block;

        string updatedProgressBar = new string(progressBar);
        percentComplete += 1;
        updatedProgressBar += percentComplete.ToString() + "%";
        Console.Write(updatedProgressBar);
        Thread.Sleep(50);
      }
      Thread.Sleep(200);
      Console.Clear();
    }
  }
}