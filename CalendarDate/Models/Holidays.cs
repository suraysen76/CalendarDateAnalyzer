using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarDate.Models
{
    public static class Holidays
    {

        public static int GetMonthlyHolidays(InputModel model, int month)
        {
            var total = 0;
            if (model.Holidays!= null) {
                switch (month) {
                    case 1:
                        total = model.Holidays.JanHoliday;
                        break;
                    case 2:
                        total = model.Holidays.FebHoliday;
                        break;
                    case 3:
                        total = model.Holidays.MarHoliday;
                        break;
                    case 4:
                        total = model.Holidays.AprHoliday;
                        break;
                    case 5:
                        total = model.Holidays.MayHoliday;
                        break;
                    case 6:
                        total = model.Holidays.JunHoliday;
                        break;
                    case 7:
                        total = model.Holidays.JulHoliday;
                        break;
                    case 8:
                        total = model.Holidays.AugHoliday;
                        break;
                    case 9:
                        total = model.Holidays.SepHoliday;
                        break;
                    case 10:
                        total = model.Holidays.OctHoliday;
                        break;
                    case 11:
                        total = model.Holidays.NovHoliday;
                        break;
                    case 12:
                        total = model.Holidays.DecHoliday;
                        break;
                }
            }

            return total;

        }
    }
}