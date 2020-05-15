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
      RepeatCounter wordCounter = new RepeatCounter(newWord);

      string result = wordCounter.Word;

      Assert.AreEqual(result, newWord);
    }
  }
}