using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarDate.Models
{
    public static class Holidays
    {

        public static Dictionary<int,int> GetHolidays()
        {
            
            Dictionary<int, int> holidays = new Dictionary<int, int>();

            holidays.Add(1, 2);
            holidays.Add(2, 4);
            holidays.Add(3, 1);
            holidays.Add(4, 2);
            holidays.Add(5, 2);
            holidays.Add(6, 2);
            holidays.Add(7, 2);
            holidays.Add(8, 1);
            holidays.Add(9, 2);
            holidays.Add(10, 1);
            holidays.Add(11, 0);
            holidays.Add(12, 2);

            return holidays;

        }
    }
}