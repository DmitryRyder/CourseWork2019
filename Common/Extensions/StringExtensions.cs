using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Shortcut to string.IsNullOrEmpty(str);
        /// </summary>
        /// <param name="str"></param>
        /// <returns>bool</returns>
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        /// <summary>
        /// Аналог string.Format(), но заменяет не по номеру, а по имени
        /// </summary>
        /// <param name="source">Исходная строка</param>
        /// <param name="parameters">Параметры для замены</param>
        /// <returns>Строка с заменёнными параметрами</returns>
        public static string FormatNamed(this string source, params object[] parameters)
        {
            var matches = new Regex(@"{[^#}]*}", RegexOptions.IgnoreCase).Matches(source);
            var values = (
                             from Match m in matches
                             select m.Value).ToList();
            values = values.Distinct()
                           .ToList();
            if (values.Count < parameters.Length)
                throw new ArgumentException("Количество значений больше количества параметров!");
            for (var i = 0; i < parameters.Length; i++)
            {
                source = source.Replace(values[i], parameters[i]
                                           .ToString());    
                if (i == parameters.Length - 1)
                    break;
            }

            return source;
        }
    }
}
