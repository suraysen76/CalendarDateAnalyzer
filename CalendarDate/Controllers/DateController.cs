using CalendarDate.Models;
using CalendarDate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalendarDate.Controllers
{
    public class DateController : Controller
    {

        public static InputModel inputModel { get; set; }
        public ActionResult AnalyzeYear(InputModel model)
        {
            if (model.Year == 0)
            {
                model = inputModel;
            }
            var summary = DateSevice.AnalyzeYear(model);
            
                if (model != null)
                {
                    var dates = DateSevice.PopulateDates(model.Year);                  


                    ViewBag.Year = model.Year;
                    ViewBag.HourlyPay = model.HourlyPay;
                    ViewBag.WorkingHoursPerDay = model.WorkingHoursPerDay;
                    inputModel = model;
            }            
            return View(summary);
        }
       

        public ActionResult AnalyzeMonth(InputModel model)
        {
            if (model.Year == 0)
            {
                model = inputModel;
            }
            var summary = DateSevice.AnalyzeMonth(model);


            if (model != null)
            {
                var dates = DateSevice.PopulateDates(model.Year);

                ViewBag.Year = model.Year;
                ViewBag.HourlyPay = model.HourlyPay;
                ViewBag.WorkingHoursPerDay = model.WorkingHoursPerDay;              

            }
            
            return View(summary);
        }



    }
}