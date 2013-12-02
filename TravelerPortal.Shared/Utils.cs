using System;
using System.Collections.Generic;
using System.Globalization;

namespace TravelerPortal.Shared
{
    public static class Utils
    {
        #region Extensions
        /// <summary>
        /// Checks whether the string is null or empty.
        /// </summary>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// Checks whether the string is not null or empty.
        /// </summary>
        public static bool HasValue(this string s)
        {
            return !string.IsNullOrEmpty(s);
        }

        public static DateTime Update(this DateTime dt, int? year = null, int? month = null, int? day = null, int? hour = null, int? minute = null, int? second = null)
        {
            var newDate = new DateTime(
                year ?? dt.Year,
                month ?? dt.Month,
                day ?? dt.Day,
                hour ?? dt.Hour,
                minute ?? dt.Minute,
                second ?? dt.Second
            );
            return new DateTimeOffset(newDate, new DateTimeOffset(dt).Offset).DateTime;
        }

        public static DateTime ConvertToDateTime(string date, string time)
        {
            return DateTime
                .ParseExact(date, "yyyy-MM-dd", null)
                .Add(TimeSpan.ParseExact(time, "hh':'mm", CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Extracts int array from comma-separated string.
        /// </summary>
        public static int[] ToIntArray(this string s)
        {
            var split = s.Split(new char[] { ',' });
            var result = new List<int>();
            foreach (var item in split)
            {
                result.Add(int.Parse(item));
            }
            return result.ToArray();
        }

        public static string IfEmptyThenReturn(this string preferableString, string alternativeString)
        {
            return preferableString.IsNullOrEmpty() ? alternativeString : preferableString;
        }
        #endregion
    }
}
