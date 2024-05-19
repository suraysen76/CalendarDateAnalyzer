using CalendarDate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarDate.Services
{
    public static class DateSevice
    {

        public static  List<DateModel> dateList { get; set; }
        public static List<DateModel> PopulateDates(int year)
        {
            dateList = new List<DateModel>();

            var startDate = new DateTime(year, 1, 1);
            var endDate = new DateTime(year, 12, 31);

            var dates = Enumerable.Range(0, (int)(endDate - startDate).TotalDays + 1)
                                  .Select(x => startDate.AddDays(x)).ToList();

            foreach (var day in dates)
            {
                dateList.Add(new DateModel { Date = day, Day = day.ToString("dddd") });
            }
            return dateList;
        }

        public static YearSummary AnalyzeYear(InputModel model)
        {
            var weekends1 = dateList.Where(x => x.Day == "Saturday").ToList();
            var weekends2 = dateList.Where(x => x.Day == "Sunday").ToList();

            var summary = new YearSummary();
            summary.Year = model.Year;
            summary.TotalDays = dateList.Count();
            summary.TotalSaturday = weekends1.Count();
            summary.TotalSunday = weekends2.Count();
            summary.TotalWeekends = weekends1.Count() + weekends2.Count();
            summary.TotalHolidays = CountTotalHolidays(model);
            summary.TotalWorkingDays = dateList.Count() - summary.TotalWeekends-summary.TotalHolidays;
            return summary;
        }

        public static  int CountTotalHolidays(InputModel model)
        {
            int count = 0;
            if (model.Holidays != null)
            {

                var holidaysModel = model.Holidays;
                count += holidaysModel.JanHoliday;
                count += holidaysModel.FebHoliday;
                count += holidaysModel.MarHoliday;
                count += holidaysModel.MayHoliday;
                count += holidaysModel.AprHoliday;
                count += holidaysModel.JunHoliday;
                count += holidaysModel.JulHoliday;
                count += holidaysModel.AugHoliday;
                count += holidaysModel.SepHoliday;
                count += holidaysModel.OctHoliday;
                count += holidaysModel.NovHoliday;
                count += holidaysModel.DecHoliday;
            }

            return count;
            
        }

        public static List<MonthSummary> AnalyzeMonth(InputModel inputModel)
        {
            var summary = new List<MonthSummary>();
            var weekends1 =new List<DateModel>();
            var weekends2 = new List<DateModel>();
            for (int i = 1; i <= 12; i++)
            {
                                   
                var model = new MonthSummary();
                var month1ist = dateList.Where(x => x.Date.Month == i).ToList();
                var weekendsSat = month1ist.Where(x => x.Day == "Saturday").ToList();

                var weekendsSun = month1ist.Where(x => x.Day == "Sunday").ToList();

                model.TotalDays = month1ist.Count();
                model.Year = inputModel.Year;
                model.Month = i;
                model.TotalWeekends = weekendsSat.Count() + weekendsSun.Count();
                model.TotalSaturday = weekendsSat.Count();
                model.TotalSunday = weekendsSun.Count();
                model.TotalHolidays = Holidays.GetMonthlyHolidays(inputModel, i);
                model.TotalWorkingDays = month1ist.Count() - model.TotalWeekends- model.TotalHolidays;
                
                summary.Add(model);
            }
          
           
            
            return summary;
        }
    }
}