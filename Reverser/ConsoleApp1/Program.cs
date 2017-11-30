using FFCG.Reverser;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Reverser reverser = new Reverser();

            char s = 's';
            Console.WriteLine(s);
            Char.ToUpper(s);
            // Console.WriteLine(s);
            Console.WriteLine(reverser.StringReverser("HEllo"));
            //string[] stringArray= reverser.StringReverser("hej test");

            DateTime d = new DateTime(2017,12,31);

            int weekNr = WeekOfYearISO8601(d);

            int WeekOfYearISO8601(DateTime date)
            {
                var day = (int)CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date);
                return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date.AddDays(4 - (day == 0 ? 7 : day)), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            }

            var currentCulture = CultureInfo.CurrentCulture;
            int weekNo = currentCulture.Calendar.GetWeekOfYear(
                            d,
                            currentCulture.DateTimeFormat.CalendarWeekRule,
                            currentCulture.DateTimeFormat.FirstDayOfWeek);

            Console.WriteLine(weekNr);
            Console.WriteLine(weekNo);
            Console.ReadLine();

            //foreach (var substring in stringArray)
            //{
            //    Console.WriteLine(substring);
            //}
            //Console.ReadLine();
        }
    }
}
