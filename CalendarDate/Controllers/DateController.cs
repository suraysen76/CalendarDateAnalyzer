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
        public ActionResult AnalyzeYear(InputModel model)
        {
           
            if (model.Year == 0 || model == null)
            {
                model = (InputModel)TempData["InputModel"];
            }
            model.Holidays = (HolidayModel)TempData["HolidaysModel"];


            var dates = DateSevice.PopulateDates(model.Year);
            var summary = DateSevice.AnalyzeYear(model);
            

            ViewBag.Year = model.Year;
            TempData["InputModel"] = model;
            return View(summary);
        }
       

        public ActionResult AnalyzeMonth(InputModel model)
        {
           if (model.Year == 0 || model==null)
            {
                model=(InputModel) TempData["InputModel"];
            }
            var dates = DateSevice.PopulateDates(model.Year);
            var summary = DateSevice.AnalyzeMonth(model);
            ViewBag.Year = model.Year;
            TempData["InputModel"] = model;
            return View(summary);
        }



    }
}