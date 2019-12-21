using NUnit.Framework;

namespace Bulgarianize.Tests
{
    public class AsLevaTests
    {
        [TestCase(42, "четиридесет и два лева и 0 стотинки")]
        [TestCase(3.14, "три лева и 14 стотинки")]
        [TestCase(3.05, "три лева и 5 стотинки")]
        public void ShouldGiveNumbersAsLeva(decimal number, string word)
        {
            Assert.AreEqual(word, number.AsLeva());
        }
    }
}
