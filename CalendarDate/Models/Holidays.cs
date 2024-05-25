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
            if (model!= null) {
                switch (month) {
                    case 1:
                        total = model.JanHoliday;
                        break;
                    case 2:
                        total = model.FebHoliday;
                        break;
                    case 3:
                        total = model.MarHoliday;
                        break;
                    case 4:
                        total = model.AprHoliday;
                        break;
                    case 5:
                        total = model.MayHoliday;
                        break;
                    case 6:
                        total = model.JunHoliday;
                        break;
                    case 7:
                        total = model.JulHoliday;
                        break;
                    case 8:
                        total = model.AugHoliday;
                        break;
                    case 9:
                        total = model.SepHoliday;
                        break;
                    case 10:
                        total = model.OctHoliday;
                        break;
                    case 11:
                        total = model.NovHoliday;
                        break;
                    case 12:
                        total = model.DecHoliday;
                        break;
                }
            }

            return total;

        }
    }
}