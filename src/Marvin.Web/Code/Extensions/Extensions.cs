using AutoMapper;
using System.Globalization;
using System.Linq.Expressions;

namespace Marvin.Web
{
    // Small set of helpful extension methods

    public static class Extensions
    {
        // Comma separate an enumerable source

        public static string CommaSeparate<T, U>(this IEnumerable<T> source, Func<T, U> func)
        {
            if (!source.Any()) return "0";
            return string.Join(",", source.Select(s => func(s)!.ToString()).ToArray());
        }

        // Comma separate an enumerable source

        public static string CommaSeparatePadded<T, U>(this IEnumerable<T> source, Func<T, U> func)
        {
            if (!source.Any()) return "0";
            return string.Join(", ", source.Select(s => func(s)!.ToString()).ToArray());
        }

        // checks if string is numeric

        public static bool IsNumeric(this string s)
        {
            return int.TryParse(s, out _);
        }

        // used for currency, remove all non-numbers

        public static string OnlyNumbers(this string s)
        {
            return string.Join("", s.Where(char.IsDigit));
        }

        public static decimal CurrencyToDecimal(this string currency)
        {
            if (string.IsNullOrEmpty(currency)) return 0;
            return decimal.Parse(currency, NumberStyles.AllowCurrencySymbol | NumberStyles.Number);
        }

        public static string ToCurrency(this decimal? amount)
        {
            if (amount == null) return "";
            return amount.Value.ToCurrency();
        }

        public static string ToCurrency(this decimal amount)
        {
            return string.Format("{0:C0}", amount);
        }

        public static string ToDate(this DateTime? dt)
        {
            if (dt == null) return "";
            return dt.Value.ToDate();
        }

        public static string ToDate(this DateTime dt)
        {
            return string.Format("{0:M/d/yyyy}", dt);
        }

        public static string ToDateTime(this DateTime? dt)
        {
            if (dt == null) return "";
            return dt.Value.ToDateTime();
        }

        public static string ToDateTime(this DateTime dt)
        {
            return string.Format("{0:M/d/yyyy hh:mm tt}", dt);
        }

        public static string ToFileStampDateTime(this DateTime dt)
        {
            return string.Format("{0:M-d-yyyy hh-mm}", dt);
        }

        public static string ToPercent(this decimal? percent)
        {
            if (percent == null) return "";
            return percent.Value.ToPercent();
        }

        public static string ToPercent(this decimal percent)
        {
            return string.Format("{0:P0}", percent / 100m);
        }

        public static string Pluralize(this int count, string singular, string plural)
        {
            return count == 1 ? "1 " + singular : count.ToString() + " " + plural;
        }

        public static string Escape(this string s)
        {
            if (string.IsNullOrEmpty(s)) return "";

            return s.Replace("'", "''");
        }

        public static int? GetId(this object? obj, int? defaultId = null)
        {
            if (obj == null) return defaultId;

            if (int.TryParse(obj.ToString(), out int value))
                return value;

            return defaultId;
        }

        public static bool IsNullOrZero(this object? obj)
        {
            if (obj == null) return true;

            if (int.TryParse(obj.ToString(), out int value))
                return value == 0;

            return true;
        }

        public static string? CleanNumber(this object number)
        {
            return number?.ToString()!.Replace(",", "");
        }

        // ** Iterator Design Pattern

        // foreach iterates over an enumerable collection

        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }

        // Truncates a string and appends ellipsis if beyond a given length

        public static string Ellipsify(this string s, int maxLength)
        {
            if (string.IsNullOrEmpty(s)) return "";
            if (s.Length <= maxLength) return s;

            return s.Substring(0, maxLength) + "...";
        }

        // Mimics SQL IN Clause

        public static bool In<T>(this T source, params T[] list)
        {
            return list.Contains(source);
        }

        // FROM: http://stackoverflow.com/a/16808867/5561153

        // .Ignore is easier to remember than .ForMember
        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(
              this IMappingExpression<TSource, TDestination> map, Expression<Func<TDestination, object>> selector)
        {
            map.ForMember(selector, config => config.Ignore());
            return map;
        }

        // .Map is easier to remember than .ForMember
        public static IMappingExpression<TSource, TDestination> Map<TSource, TDestination>(
              this IMappingExpression<TSource, TDestination> map,
              Expression<Func<TDestination, object>> selector,
              Action<IMemberConfigurationExpression<TSource, TDestination, object>> memberOptions)
        {
            map.ForMember(selector, memberOptions);
            return map;
        }

        // Appends sql AND clauses

        public static string AND(this string clause, string condition)
        {
            if (string.IsNullOrEmpty(condition))
                return clause ?? "";

            if (clause == null)
                clause = "";

            if (!string.IsNullOrWhiteSpace(clause))
                clause += " AND ";

            return clause + condition;
        }

        // Appends sql OR clauses

        public static string OR(this string clause, string condition)
        {
            if (string.IsNullOrEmpty(condition))
                return clause ?? "";

            if (clause == null)
                clause = "";

            if (!string.IsNullOrWhiteSpace(clause))
                clause += " OR ";

            return clause + condition;
        }
    }
}
