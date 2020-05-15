using System.Collections.Generic;

namespace WordCounter.Models
{
  public class RepeatCounter
  {
    public string Word { get; set; }
    public string ParsedWord { get; set; }
    public string Sentence { get; set; }
    public string ParsedSentence { get; set; }
    private static List<char> _punctuation = new List<char> { '`', '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_',
      '+', '=', '[', ']', '|', '\\', ';', ':', '"', '\'', ',', '<', '>', '.', '?', '/' };

    public RepeatCounter(string word, string sentence)
    {
      Word = word;
      Sentence = sentence;
    }

    public bool ValidateWord()
    {
      foreach (char letter in Word)
      {
        if (char.IsDigit(letter))
        {
          return false;
        }
      }

      return true;
    }

    public bool ValidateSentence()
    {
      string[] words = Sentence.Split(" ");

      foreach (string word in words)
      {
        foreach (char letter in word)
        {
          if (char.IsDigit(letter))
          {
            return false;
          }
        }
      }

      return true;
    }

    public void ParseWord()
    {
      ParsedWord = Word.ToLower();
    }

    public void ParseSentence()
    {
      ParsedSentence = Sentence.ToLower();
    }
  }
}