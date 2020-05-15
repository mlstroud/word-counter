using System.Collections.Generic;

namespace WordCounter.Models
{
  public class RepeatCounter
  {
    public string Word { get; set; }
    public string ParsedWord { get; set; }
    public string Sentence { get; set; }
    public string ParsedSentence { get; set; }
    private Dictionary<string, int> _matches;

    public RepeatCounter(string word, string sentence)
    {
      Word = word;
      Sentence = sentence;
      _matches = new Dictionary<string, int>();
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
      ParsedWord = RemovePunctuation(ParsedWord);
    }

    public void ParseSentence()
    {
      ParsedSentence = Sentence.ToLower();

      string[] words = ParsedSentence.Split(" ");

      string SentenceWithoutPunctuation = "";

      for (int word = 0; word < words.Length; word++)
      {
        words[word] = RemovePunctuation(words[word]);
      }

      ParsedSentence = string.Join(" ", words);
    }

    public string RemovePunctuation(string word)
    {
      string wordWithoutPunctuation = "";

      foreach (char letter in word)
      {
        if (!char.IsPunctuation(letter))
        {
          wordWithoutPunctuation += letter;
        }
      }

      return wordWithoutPunctuation;
    }

    public int GetWordCount()
    {
      ParseWord();
      ParseSentence();
      FindMatches();

      return _matches.ContainsKey(ParsedWord) ? _matches[ParsedWord] : 0;
    }


    public void FindMatches()
    {
      string[] wordList = ParsedSentence.Split(" ");

      foreach (string word in wordList)
      {
        if (_matches.ContainsKey(word))
        {
          _matches[word]++;
        }
        else
        {
          _matches[word] = 1;
        }
      }
    }
  }
}