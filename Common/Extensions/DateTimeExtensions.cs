using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static long ToUnix(this DateTime date)
        {
            return date.Year > 1970 ? new DateTimeOffset(date).ToUnixTimeSeconds() : 0;
        }

        public static bool IsAfterTen(this DateTime? date)
        {
            return date.HasValue && IsAfterTen(date.GetValueOrDefault());
        }

        public static bool IsAfterTen(this DateTime date)
        {
            date = date.Date;
            if (date >= DateTime.Today || date < new DateTime(2001, 1, 1))
                return false;
            var beginOfPreviousMonth = DateTime.Now.StartOfMonth()
                                               .AddMonths(-1);
            return date < beginOfPreviousMonth || DateTime.Now.Day >= 10 && date.Month == beginOfPreviousMonth.Month && date.Year == beginOfPreviousMonth.Year;
        }

        public static bool IsAfterSeven(this DateTime date)
        {
            date = date.Date;
            if (date >= DateTime.Today || date < new DateTime(2001, 1, 1))
                return false;
            var beginOfPreviousMonth = DateTime.Now.StartOfMonth()
                                               .AddMonths(-1);
            return date < beginOfPreviousMonth || DateTime.Now.Day >= 7 && date.Month == beginOfPreviousMonth.Month && date.Year == beginOfPreviousMonth.Year;
        }

        /// <summary>
        /// Возвращает дату с переносом на час вперед с точностью до часа(15:00:00)
        /// Для тикетов!
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ToNextHour(this DateTime date) =>
            new DateTime(date.Year, date.Month, date.Day, date.Hour + 1, 0,
                         0);

        /// <summary>
        /// 23:59:59:999
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime EndOfTheDay(this DateTime date)
        {
            return date.Date
                       .AddDays(1)
                       .AddMilliseconds(-1);
        }

        public static DateTime StartOfTheYear(this DateTime date)
        {
            return new DateTime(date.Year, 1, 1);
        }

        public static DateTime EndOfTheYear(this DateTime date)
        {
            return new DateTime(date.Year + 1, 1, 1).AddMilliseconds(-1);
        }

        public static DateTime StartOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }


        public static DateTime EndOfMonth(this DateTime date)
        {
            return date.StartOfMonth()
                       .AddMonths(1)
                       .AddMilliseconds(-1);
        }

        /// <summary>
        /// Меняет день в дате на указанный
        /// </summary>
        /// <param name="date"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime Day(this DateTime date, int day) =>
            new DateTime(date.Year, date.Month, day, date.Hour, date.Minute,
                         date.Second);

        /// <summary>
        /// Является ли день выходным
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekEnd(this DateTime date) => date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday;

        /// <summary>
        /// Получить дату в формате "yyyy-MM-dd'T'HH:mmK", напр. 2014-08-01T23:59+06:00
        /// </summary>
        public static string ToIsoDateTime(this DateTime value)
        {
            if (value.Kind == DateTimeKind.Unspecified)
                value = new DateTime(value.Ticks, DateTimeKind.Local);
            return value.ToString("yyyy-MM-dd'T'HH:mmK");
        }

        public static DateTime ApplyTimeZoneShift(this DateTime dt, double timeZone)
        {
            var shift = timeZone - DateTimeOffset.Now.Offset.TotalHours;
            return MakeShift(dt, shift);
        }

        public static DateTime ReverseTimeZoneShift(this DateTime dt, double timeZone)
        {
            var shift = DateTimeOffset.Now.Offset.TotalHours - timeZone;
            return MakeShift(dt, shift);
        }

        private static DateTime MakeShift(DateTime dt, double shift)
        {
            if (shift < 0 && dt <= DateTime.MinValue.AddHours(-shift) || shift > 0 && dt >= DateTime.MaxValue.AddHours(-shift))
                return dt;
            return dt.AddHours(shift);
        }
    }
}
