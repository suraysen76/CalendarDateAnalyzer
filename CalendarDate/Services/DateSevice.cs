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

        public static YearSummary AnalyzeYear(int year)
        {
            var summary = new YearSummary();
            var dict =  Holidays.GetHolidays().ToList();
            summary.TotalHolidays  = dict.Sum(x => x.Value);
            //summary.TotalHolidays = dict.Count;
           

            summary.TotalDays = dateList.Count();
            var weekends1 = dateList.Where(x => x.Day == "Saturday").ToList();

            var weekends2 = dateList.Where(x => x.Day == "Sunday").ToList();
            summary.Year = year;
            summary.TotalWeekends = weekends1.Count() + weekends2.Count();
            summary.TotalSaturday = weekends1.Count();
            summary.TotalSunday = weekends2.Count();
            summary.TotalWorkingDays = dateList.Count() - summary.TotalWeekends-summary.TotalHolidays;
            return summary;
        }
        public static List<MonthSummary> AnalyzeMonth(int year)
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
                model.Year = year;
                model.Month = i;
                model.TotalWeekends = weekendsSat.Count() + weekendsSun.Count();
                model.TotalSaturday = weekendsSat.Count();
                model.TotalSunday = weekendsSun.Count();
                model.TotalWorkingDays = month1ist.Count() - model.TotalWeekends;
                model.TotalHolidays = Holidays.GetHolidays()[i];
                summary.Add(model);
            }
          
           
            
            return summary;
        }
    }
}