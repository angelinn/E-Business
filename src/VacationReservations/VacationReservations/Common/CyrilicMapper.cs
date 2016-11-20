using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VacationReservations.Common
{
    public static class CyrilicMapper
    {
        private static Dictionary<char, string> mapper = new Dictionary<char, string>
        {
            { 'а', "a" },
            { 'б', "b" },
            { 'в', "v" },
            { 'г', "g" },
            {'д', "d" },
            {'е', "e" },
            {'ж', "zh" },
            {'з', "z" },
            {'и', "i" },
            {'й', "i" },
            {'к', "k" },
            {'л', "l" },
            {'м', "m" },
            {'н', "n" },
            {'о', "o" },
            {'п', "p" },
            {'р', "r" },
            {'с', "s" },
            {'т', "t" },
            {'у', "u" },
            {'ф', "f" },
            {'х', "h" },
            {'ц', "ts" },
            {'ч', "ch" },
            {'ш', "sh" },
            {'щ', "sht" },
            {'ъ', "y" },
            {'ь', "i" },
            {'ю', "iu" },
            {'я', "ia" },
            {' ', " " }
        };

        public static string Map(string cyrilicText)
        {
            return String.Concat(cyrilicText.ToLower().Select(c =>
            {
                try
                {
                    return mapper[c];
                }
                catch (KeyNotFoundException)
                {
                    return String.Empty;
                }
            }));
        }
    }
}