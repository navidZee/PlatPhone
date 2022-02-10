using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PlatPhone.Extention
{
    public static class DateCovertor
    {
        private static PersianCalendar pc = new PersianCalendar();
        public static DateTime ToMiladi(this string date)
        {
            string[] result = new string[3];
            int i = 0;
            foreach (var item in date.Split('/'))
            {
                result[i] = item;
                i++;
            }
            PersianCalendar pc = new PersianCalendar();
            return new DateTime(int.Parse(result[0]), int.Parse(result[1]), int.Parse(result[2]), pc);
        }

        public static string ToShamsi(this DateTime dateTime)
        {
            return $"{pc.GetYear(dateTime)}/{pc.GetMonth(dateTime)}/{pc.GetDayOfMonth(dateTime)}";
        }
        public static string ToShamsiWithTime(this DateTime dateTime)
        {
            return $"{pc.GetHour(dateTime)}:{pc.GetMinute(dateTime)} {pc.GetYear(dateTime)}/{pc.GetMonth(dateTime)}/{pc.GetDayOfMonth(dateTime)}";
        }
    }
}
