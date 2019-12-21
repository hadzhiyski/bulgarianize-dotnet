using System;

namespace Bulgarianize
{
    public static class NumberExtensions
    {
        private static readonly string[] MaleDigits = new[] { "нула", "един", "два", "три", "четири", "пет", "шест", "седем", "осем", "девет" };
        private static readonly string[] FemaleDigits = new[] { "нула", "една", "две", "три", "четири", "пет", "шест", "седем", "осем", "девет" };
        private static readonly string[] NeuterDigits = new[] { "нула", "едно", "две", "три", "четири", "пет", "шест", "седем", "осем", "девет" };
        private static readonly string[] NamesFrom11To19 = new[] { "единадесет", "дванадесет", "тринадесет", "четиринадесет", "петнадесет", "шестнадесет", "седемнадесет", "осемнадесет", "деветнадесет" };
        private static readonly string[] MultiplesOf10 = new[] { "десет", "двадесет", "тридесет", "четиридесет", "петдесет", "шестдесет", "седемдесет", "осемдесет", "деветдесет" };
        private static readonly string[] Hundreds = new[] { "сто", "двеста", "триста", "четиристотин", "петстотин", "шестстотин", "седемстотин", "осемстотин", "деветстотин" };

        public static string AsWords(this long number, GrammarGender gender = GrammarGender.Neuter) => WordsFor(number, gender);

        public static string AsLeva(this decimal number)
        {
            var levas = (long)Math.Truncate(number);
            var cents = (long)(number % 1 * 100);

            var levasWords = WordsFor(levas, GrammarGender.Male);

            return JoinWords($"{levasWords} лева", $"{cents} стотинки");
        }

        private static string WordsFor(long number, GrammarGender gender)
        {
            switch (number)
            {
                case long n when (n >= 0 && n <= 9):
                    {
                        switch (gender)
                        {
                            case GrammarGender.Male:
                                return MaleDigits[n];
                            case GrammarGender.Female:
                                return FemaleDigits[n];
                            case GrammarGender.Neuter:
                                return NeuterDigits[n];
                        }

                        break;
                    }
                case long n when (n >= 11 && n <= 19):
                    return NamesFrom11To19[n - 11];
                case long n when (n % 10 == 0 && n <= 90):
                    return MultiplesOf10[n / 10 - 1];
                case long n when (n >= 21 && n <= 99):
                    return JoinWords(WordsFor(WholePart(n, 10), gender), WordsFor(n % 10, gender));
                case long n when (n % 100 == 0 && n <= 900):
                    return Hundreds[n / 100 - 1];
                case long n when (n >= 101 && n <= 999):
                    return JoinWords(WordsFor(WholePart(n, 100), gender), WordsFor(n % 100, gender));
                case long n when n == 1000:
                    return "хиляда";
                case long n when (n % 1000 == 0 && n > 1000 && n < 1_000_000):
                    return $"{WordsFor(n / 1000, GrammarGender.Female)} хиляди";
                case long n when (n >= 1001 && n <= 999_999):
                    return JoinWords(WordsFor(WholePart(n, 1000), gender), WordsFor(n % 1000, gender));
                case long n when (n == 1_000_000):
                    return "един милион";
                case long n when (n % 1_000_000 == 0 && n > 1_000_000 && n < 1_000_000_000_000):
                    return $"{WordsFor(n / 1_000_000, GrammarGender.Male)} милиона";
                case long n when (n >= 1_000_001 && n <= 999_999_999):
                    return JoinWords(WordsFor(WholePart(n, 1_000_000), gender), WordsFor(n % 1_000_000, gender));
            }

            return number.ToString();
        }

        private static string JoinWords(string left, string right)
        {
            if (right.Contains(" и "))
            {
                return $"{left} {right}";
            }

            return $"{left} и {right}";
        }

        private static long WholePart(long number, int @base) => (number / @base) * @base;
    }
}
