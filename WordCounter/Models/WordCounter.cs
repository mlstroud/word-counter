namespace WordCounter.Models
{
  public class RepeatCounter
  {
    public string Word { get; set; }
    public string ParsedWord { get; set; }
    public string Sentence { get; set; }
    public string ParsedSentence { get; set; }

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
  }
}