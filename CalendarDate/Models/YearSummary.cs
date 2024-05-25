using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CalendarDate.Models
{
    public class YearSummary
    {
        public int Year { get; set; }

        [Display(Name = "Total Days")]
        public int TotalDays { get; set; }

        [Display(Name = "Total Saturday")]
        public int TotalSaturday { get; set; }

        [Display(Name = "Total Sunday")]
        public int TotalSunday { get; set; }

        [Display(Name = "Total Weekends")]
        public int TotalWeekends { get; set; }

        [Display(Name = "Total Working Days")]
        public int TotalWorkingDays { get; set; }
        [Display(Name = "Total HolidDays")]
        public int TotalHolidays { get; set; }

        public InputModel InputModel { get; set; }
    }
}