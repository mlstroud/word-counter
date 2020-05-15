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

      Assert.AreEqual(result, newWord);
    }

    [TestMethod]
    public void Constructor_StoresSentence_Sentence()
    {
      string newSentence = "The man ate the cake";
      RepeatCounter wordCounter = new RepeatCounter("test", newSentence);

      string result = wordCounter.Sentence;

      Assert.AreEqual(result, newSentence);
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
  }
}