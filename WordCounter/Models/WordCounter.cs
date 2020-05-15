namespace WordCounter.Models
{
  public class RepeatCounter
  {
    public string Word { get; set; }
    public string Sentence { get; set; }

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
      Word = Word.ToLower();
    }

    public void ParseSentence()
    {
      Sentence = Sentence.ToLower();
    }
  }
}