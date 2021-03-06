using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounter.Models;

namespace WordCounter.Tests
{
  [TestClass]
  public class RepeatCounterTests
  {
    [TestMethod]
    public void Constructor_StoresWord_Word()
    {
      string newWord = "the";
      RepeatCounter wordCounter = new RepeatCounter(newWord, "test");

      string result = wordCounter.Word;

      Assert.AreEqual(newWord, result);
    }

    [TestMethod]
    public void Constructor_StoresSentence_Sentence()
    {
      string newSentence = "The man ate the cake";
      RepeatCounter wordCounter = new RepeatCounter("test", newSentence);

      string result = wordCounter.Sentence;

      Assert.AreEqual(newSentence, result);
    }

    [TestMethod]
    public void ValidateWord_ReturnsValidWord_True()
    {
      string newWord = "the";
      RepeatCounter wordCounter = new RepeatCounter(newWord, "test");

      bool result = wordCounter.ValidateWord();

      Assert.IsTrue(result);
    }

    [TestMethod]
    public void ValidateWord_ReturnsValidWord_False()
    {
      string newWord = "th6e";
      RepeatCounter wordCounter = new RepeatCounter(newWord, "test");

      bool result = wordCounter.ValidateWord();

      Assert.IsFalse(result);
    }

    [TestMethod]
    public void ValidateSentence_ReturnsValidSentence_True()
    {
      string newSentence = "The man ate the cake";
      RepeatCounter wordCounter = new RepeatCounter("test", newSentence);

      bool result = wordCounter.ValidateSentence();

      Assert.IsTrue(result);
    }

    [TestMethod]
    public void ValidateSentence_ReturnsValidSentence_False()
    {
      string newSentence = "The m4n at3e the cake";
      RepeatCounter wordCounter = new RepeatCounter("test", newSentence);

      bool result = wordCounter.ValidateSentence();

      Assert.IsFalse(result);
    }

    [TestMethod]
    public void ParseWord_ConvertsWordToLowerCase_LowerCaseWord()
    {
      string newWord = "The";
      RepeatCounter wordCounter = new RepeatCounter(newWord, "test");

      wordCounter.ParseWord();
      string result = wordCounter.ParsedWord;

      Assert.AreEqual(newWord.ToLower(), result);
    }

    [TestMethod]
    public void ParseSentence_ConvertsSentenceToLowerCase_LowerCaseSentence()
    {
      string newSentence = "The MAN ate the CAKE";
      RepeatCounter wordCounter = new RepeatCounter("test", newSentence);

      wordCounter.ParseSentence();
      string result = wordCounter.ParsedSentence;

      Assert.AreEqual(newSentence.ToLower(), result);
    }

    [TestMethod]
    public void RemovePunctuation_RemovesPunctuation_WordWithoutPunctuation()
    {
      string newWord = "why!?,[]()&";
      string expectedWord = "why";
      RepeatCounter wordCounter = new RepeatCounter(newWord, "test");

      string result = wordCounter.RemovePunctuation(newWord);

      Assert.AreEqual(expectedWord, result);
    }

    [TestMethod]
    public void ParseWord_CallsRemovePunctuation_WordWithoutPunctuation()
    {
      string newWord = "Why!?,[]()&";
      string expectedWord = "why";
      RepeatCounter wordCounter = new RepeatCounter(newWord, "test");

      wordCounter.ParseWord();
      string result = wordCounter.ParsedWord;

      Assert.AreEqual(expectedWord, result);
    }

    [TestMethod]
    public void ParseSentence_CallsRemovePunctuationOnEveryWord_SentenceWithoutPunctuation()
    {
      string newSentence = "He ate the Cake! Why?!?!";
      string expectedSentence = "he ate the cake why";
      RepeatCounter wordCounter = new RepeatCounter("test", newSentence);

      wordCounter.ParseSentence();
      string result = wordCounter.ParsedSentence;

      Assert.AreEqual(expectedSentence, result);
    }

    [TestMethod]
    public void FindMatches_ComparesFirstWord_One()
    {
      string newWord = "The";
      string newSentence = "The man ate cake.";
      RepeatCounter wordCounter = new RepeatCounter(newWord, newSentence);

      int result = wordCounter.GetWordCount();

      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void FindMatches_ComparesAllWords_Two()
    {
      string newWord = "The";
      string newSentence = "The man ate the cake.";
      RepeatCounter wordCounter = new RepeatCounter(newWord, newSentence);

      int result = wordCounter.GetWordCount();

      Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void GetWordCount_PerformsAllActions_WordCount()
    {
      string newWord = "The";
      string newSentence = "The MAN ate the CAKE!!!";
      RepeatCounter wordCounter = new RepeatCounter(newWord, newSentence);

      int result = wordCounter.GetWordCount();

      Assert.AreEqual(2, result);
    }
  }
}