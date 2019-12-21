using NUnit.Framework;

namespace Bulgarianize.Tests
{
    public class AsWordsTests
    {
        [TestCase(0, "нула")]
        [TestCase(1, "едно")]
        [TestCase(2, "две")]
        [TestCase(3, "три")]
        [TestCase(4, "четири")]
        [TestCase(5, "пет")]
        [TestCase(6, "шест")]
        [TestCase(7, "седем")]
        [TestCase(8, "осем")]
        [TestCase(9, "девет")]
        public void ShouldWorkWithSimpleNumbersLessThan10(long number, string word)
        {
            Assert.AreEqual(word, number.AsWords());
        }

        [TestCase(0, "нула", GrammarGender.Neuter)]
        [TestCase(0, "нула", GrammarGender.Male)]
        [TestCase(0, "нула", GrammarGender.Female)]

        [TestCase(1, "едно", GrammarGender.Neuter)]
        [TestCase(1, "един", GrammarGender.Male)]
        [TestCase(1, "една", GrammarGender.Female)]

        [TestCase(2, "две", GrammarGender.Neuter)]
        [TestCase(2, "два", GrammarGender.Male)]
        [TestCase(2, "две", GrammarGender.Female)]

        [TestCase(3, "три", GrammarGender.Neuter)]
        [TestCase(3, "три", GrammarGender.Male)]
        [TestCase(3, "три", GrammarGender.Female)]
        public void ShouldEnableGendersWithNumbersLessThan10(long number, string word, GrammarGender gender)
        {
            Assert.AreEqual(word, number.AsWords(gender));
        }

        [TestCase(11, "единадесет")]
        [TestCase(12, "дванадесет")]
        [TestCase(13, "тринадесет")]
        [TestCase(14, "четиринадесет")]
        [TestCase(15, "петнадесет")]
        [TestCase(16, "шестнадесет")]
        [TestCase(17, "седемнадесет")]
        [TestCase(18, "осемнадесет")]
        [TestCase(19, "деветнадесет")]
        public void ShouldWorkWithNumbersFrom11To19(long number, string word)
        {
            Assert.AreEqual(word, number.AsWords());
        }

        [TestCase(10, "десет")]
        [TestCase(20, "двадесет")]
        [TestCase(30, "тридесет")]
        [TestCase(40, "четиридесет")]
        [TestCase(50, "петдесет")]
        [TestCase(60, "шестдесет")]
        [TestCase(70, "седемдесет")]
        [TestCase(80, "осемдесет")]
        [TestCase(90, "деветдесет")]
        public void ShouldWorkWithNumbersDividableBy10(long number, string word)
        {
            Assert.AreEqual(word, number.AsWords());
        }

        [TestCase(21, "двадесет и едно")]
        [TestCase(32, "тридесет и две")]
        [TestCase(43, "четиридесет и три")]
        [TestCase(54, "петдесет и четири")]
        [TestCase(65, "шестдесет и пет")]
        public void ShouldWorkWithNumbersLessThan100AndNotDividableBy10(long number, string word)
        {
            Assert.AreEqual(word, number.AsWords());
        }
    }
}