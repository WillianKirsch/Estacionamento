using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Infraestrutura.Extensions
{
    public static class StringExtensions
    {
        public static string Formatar(this string texto, params string[] termo)
        {
            return string.Format(texto, termo);
        }

        public static string RemoverAcentos(this string palavra)
        {
            if (string.IsNullOrEmpty(palavra))
                return palavra;

            string stringNormalizada =
                palavra.Normalize(NormalizationForm.FormD);
            StringBuilder builder = new StringBuilder();

            for (int index = 0; index < stringNormalizada.Length; ++index)
            {
                char c = stringNormalizada[index];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    builder.Append(c);
            }
            return builder.ToString().ToLower();
        }

        public static DateTime? ConverterParaData(this string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return null;

            DateTime resultado;

            if (DateTime.TryParseExact(texto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out resultado))
                return resultado;
            else
                return null;
        }

        public static string ConverterParaTexto(this DateTime? data)
        {
            return data.HasValue ? data.Value.ToString("dd/MM/yyyy") : string.Empty;
        }

        public static string ConverterParaTextoHoraMinuto(this decimal? valor)
        {

            return valor.HasValue ? string.Format("{0:00:00}", int.Parse(valor.ToString().Replace(",", ""))) : string.Empty;
        }
    }
}
