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

        [TestCase(100, "сто")]
        [TestCase(200, "двеста")]
        [TestCase(300, "триста")]
        [TestCase(400, "четиристотин")]
        [TestCase(500, "петстотин")]
        [TestCase(600, "шестстотин")]
        [TestCase(700, "седемстотин")]
        [TestCase(800, "осемстотин")]
        [TestCase(900, "деветстотин")]
        public void ShouldWorkWithNumbersLessThan1000AndDividableBy100(long number, string word)
        {
            Assert.AreEqual(word, number.AsWords());
        }

        [TestCase(110, "сто и десет")]
        [TestCase(123, "сто двадесет и три")]
        [TestCase(217, "двеста и седемнадесет")]
        [TestCase(420, "четиристотин и двадесет")]
        public void ShouldWorkWithNumbersGreaterThan100AndLessThan1000AndNotDividableBy100(long number, string word)
        {
            Assert.AreEqual(word, number.AsWords());
        }

        [TestCase(1_000, "хиляда")]
        [TestCase(2_000, "две хиляди")]
        [TestCase(5_000, "пет хиляди")]
        [TestCase(10_000, "десет хиляди")]
        [TestCase(13_000, "тринадесет хиляди")]
        [TestCase(28_000, "двадесет и осем хиляди")]
        [TestCase(100_000, "сто хиляди")]
        [TestCase(673_000, "шестстотин седемдесет и три хиляди")]
        public void ShouldWorkWithNumbersDividableBy1000(long number, string word)
        {
            Assert.AreEqual(word, number.AsWords());
        }

        [TestCase(1_001, "хиляда и едно")]
        [TestCase(1_024, "хиляда двадесет и четири")]
        [TestCase(17_001, "седемнадесет хиляди и едно")]
        [TestCase(24_200, "двадесет и четири хиляди и двеста")]
        [TestCase(65_536, "шестдесет и пет хиляди петстотин тридесет и шест")]
        [TestCase(123_456, "сто двадесет и три хиляди четиристотин петдесет и шест")]
        public void ShouldWorkWithNumbersLessThanAMillionAndNotDividableBy1000(long number, string word)
        {
            Assert.AreEqual(word, number.AsWords());
        }

        [TestCase(1_000_000, "един милион")]
        [TestCase(1_000_001, "един милион и едно")]
        [TestCase(2_000_200, "два милиона и двеста")]
        [TestCase(35_000_035, "тридесет и пет милиона тридесет и пет")]
        [TestCase(123_456_789, "сто двадесет и три милиона четиристотин петдесет и шест хиляди седемстотин осемдесет и девет")]
        public void ShouldWorkWithMillions(long number, string word)
        {
            Assert.AreEqual(word, number.AsWords());
        }
    }
}