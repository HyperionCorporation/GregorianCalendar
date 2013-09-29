using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GregorianCalendar
{
    public static class DoomsdayCalculator
    {
 
        //Return the day of the week a particular day falls on in a given year
        public static Calendar.DaysOfWeek getDayOfWeek(int month, int day, int year)
        {
            //Find that year's doomsday
            Calendar.DaysOfWeek yearsDoomsday = getYearsDoomsday(year);
            
            //Find that month's doomsday
            int monthDoomsday = getMonthsDoomsday(month, year);
           
            //Find the day of the week
            int offSet = day - monthDoomsday;

            while (offSet > 7)
            {
                offSet -= 7;
            }

            int rawDay = (int)yearsDoomsday + offSet;

            if (rawDay > 7)
            {
                int change = 7 - rawDay;
                Calendar.DaysOfWeek dayWeek = yearsDoomsday + change;
                return dayWeek;
            }

            else
            {
                return (Calendar.DaysOfWeek)rawDay;
            }
        }


        private static bool isLeapYear(int year)
        {
            if (year % 4 == 0)
            {
                if(year % 100 == 0 && year % 400 != 0)
                {
                    return false;
                }

                return true;
            }
            return false;
        }

        private static Calendar.DaysOfWeek getYearsDoomsday(int year)
        {
            string yearString = Convert.ToString(year).Substring(2);
            int lastTwo = Convert.ToInt16(yearString);

            int offSet = (lastTwo + (lastTwo / 4)) % 7;

            if (year >= 1900 && year < 2000)
            {
                return Calendar.DaysOfWeek.WEDNESDAY + offSet;
            }

            else if (year >= 2000 && year < 3000)
            {
                return Calendar.DaysOfWeek.TUESDAY + offSet;
            }

            else return Calendar.DaysOfWeek.MONDAY; 

        }

        private static int getMonthsDoomsday(int month, int year)
        {
            Calendar.MonthsOfYear monthOfYear= (Calendar.MonthsOfYear) month;

            if (month % 2 == 0)
            {
                //Even month
                if (monthOfYear == Calendar.MonthsOfYear.FEBRUARY)
                {
                    if (isLeapYear(year))
                    {
                        return 29;
                    }

                    return 28;
                }
                if (monthOfYear == Calendar.MonthsOfYear.APRIL)
                {
                    return 4;
                }

                if (monthOfYear == Calendar.MonthsOfYear.JUNE)
                {
                    return 6;
                }

                if (monthOfYear == Calendar.MonthsOfYear.AUGUST)
                {
                    return 8;
                }

                if (monthOfYear == Calendar.MonthsOfYear.OCTOBER)
                {
                    return 10;
                }

                if (monthOfYear == Calendar.MonthsOfYear.DECEMBER)
                {
                    return 12;
                }

                return -1;
            }

            else
            {
                //Odd months
                if (monthOfYear == Calendar.MonthsOfYear.JANUARY)
                {
                    if (isLeapYear(year))
                    {
                        return 4;
                    }

                    return 3;
                }

                if (monthOfYear == Calendar.MonthsOfYear.MARCH)
                {
                    return 7;
                }

                if (monthOfYear == Calendar.MonthsOfYear.MAY)
                {
                    return 9;
                }

                if (monthOfYear == Calendar.MonthsOfYear.JULY)
                {
                    return 11;
                }

                if (monthOfYear == Calendar.MonthsOfYear.SEPTEMBER)
                {
                    return 5;
                }

                if(monthOfYear == Calendar.MonthsOfYear.NOVEMBER)
                {
                    return 7;
                }
                
                return -1;
            }
        }
    }

    public static class Calendar
    {

        public enum CenturyDoomsday
        {
            TWENTIETH = DaysOfWeek.WEDNESDAY,
            TWENTYFIRST = DaysOfWeek.TUESDAY
        };

        public enum DaysOfWeek
        {
            SUNDAY = 1,
            MONDAY = 2,
            TUESDAY = 3,
            WEDNESDAY = 4,
            THURSDAY = 5,
            FRIDAY = 6,
            SATURDAY = 7
        };

        public enum MonthsOfYear
        {
            JANUARY = 1,
            FEBRUARY = 2,
            MARCH = 3,
            APRIL = 4,
            MAY = 5,
            JUNE = 6,
            JULY = 7,
            AUGUST = 8,
            SEPTEMBER = 9,
            OCTOBER = 10,
            NOVEMBER = 11,
            DECEMBER = 12
       };

    
    }
}
