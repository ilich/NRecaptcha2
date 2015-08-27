using System;

namespace NRecaptcha2.Core
{
    static class LanguageHelpers
    {
        public static string Language2String(Language language)
        {
            switch (language)
            {
                case Language.Arabic:
                    return "ar";

                case Language.Bengali:
                    return "bn";

                case Language.Bulgarian:
                    return "bg";

                case Language.Catalan:
                    return "ca";

                case Language.ChineseSimplified:
                    return "zh-CN";

                case Language.ChineseTraditional:
                    return "zh-TW";

                case Language.Croatian:
                    return "hr";

                case Language.Czech:
                    return "cs";

                case Language.Danish:
                    return "da";

                case Language.Dutch:
                    return "nl";

                case Language.EnglishUk:
                    return "en-GB";

                case Language.EnglishUs:
                    return "en";

                case Language.Estonian:
                    return "et";

                case Language.Filipino:
                    return "fil";

                case Language.Finnish:
                    return "fi";

                case Language.French:
                    return "fr";

                case Language.FrenchCanadian:
                    return "fr-CA";

                case Language.German:
                    return "de";

                case Language.Gujarati:
                    return "gu";

                case Language.GermanAustria:
                    return "de-AT";

                case Language.GermanSwitzerland:
                    return "de-CH";

                case Language.Greek:
                    return "el";

                case Language.Hebrew:
                    return "iw";

                case Language.Hindi:
                    return "hi";

                case Language.Hungarain:
                    return "hu";

                case Language.Indonesian:
                    return "id";

                case Language.Italian:
                    return "it";

                case Language.Japanese:
                    return "ja";

                case Language.Kannada:
                    return "kn";

                case Language.Korean:
                    return "ko";

                case Language.Latvian:
                    return "lv";

                case Language.Lithuanian:
                    return "lt";

                case Language.Malay:
                    return "ms";

                case Language.Malayalam:
                    return "ml";

                case Language.Marathi:
                    return "mr";

                case Language.Norwegian:
                    return "no";

                case Language.Persian:
                    return "fa";

                case Language.Polish:
                    return "pl";

                case Language.Portuguese:
                    return "pt";

                case Language.PortugueseBrazil:
                    return "pt-BR";

                case Language.PortuguesePortugal:
                    return "pt-PT";

                case Language.Romanian:
                    return "ro";

                case Language.Russian:
                    return "ru";

                case Language.Serbian:
                    return "sr";

                case Language.Slovak:
                    return "sk";

                case Language.Slovenian:
                    return "sl";

                case Language.Spanish:
                    return "es";

                case Language.SpanishLatinAmerica:
                    return "es-419";

                case Language.Swedish:
                    return "sv";

                case Language.Tamil:
                    return "ta";

                case Language.Telugu:
                    return "te";

                case Language.Thai:
                    return "th";

                case Language.Turkish:
                    return "tr";

                case Language.Ukrainian:
                    return "uk";

                case Language.Urdu:
                    return "ur";

                case Language.Vietnamese:
                    return "vi";
            }

            throw new ArgumentException(nameof(language));
        }
    }
}
