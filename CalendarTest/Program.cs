using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GregorianCalendar;

namespace CalendarTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Date Formats: MM/DD/YYYY or MM.DD.YYYY");
            Console.WriteLine("Please enter the Date to find the day of the week it fell on");
            String rawDate = Console.ReadLine();
            string[] seperatedComponents = seperateComponents(rawDate);
            if (seperatedComponents != null)
            {
                int month = Convert.ToInt16(seperatedComponents[0]);
                int day = Convert.ToInt16(seperatedComponents[1]);
                int year = Convert.ToInt16(seperatedComponents[2]);

                Calendar.DaysOfWeek myDay = DoomsdayCalculator.getDayOfWeek(month, day, year);
                Console.WriteLine("That day is a : " + myDay.ToString());

            }

            else
            {
                Console.WriteLine("Incorrect Date Format: MM/DD/YYYY or MM.DD.YYYY");
            }

            Console.ReadLine();
        }

        private static string[] seperateComponents(string input)
        {

            if(!input.Contains('/') && !input.Contains('.'))
            {
                return null;
            }

            int countSeperators = 0;

            foreach (char c in input)
            {
                if (c == '/' || c == '.')
                {
                    countSeperators++;
                }
            }

            if (countSeperators < 0 || countSeperators > 2)
            {
                return null;
            }

            string[] info = input.Split(new char[] { '/', '.' });

           
            return info;
        }
    }
}
