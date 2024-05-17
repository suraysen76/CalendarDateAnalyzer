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
           
            var dates = DateSevice.PopulateDates(model.Year);
            var summary = DateSevice.AnalyzeYear(model.Year);
            

            ViewBag.Year = model.Year;
            return View(summary);
        }
       

        public ActionResult AnalyzeMonth(InputModel model)
        {
            if (model.Year == 0)
            {
                model = ViewBag.InputModel;
                model = TempData["Input"] as InputModel;
            }
            var dates = DateSevice.PopulateDates(model.Year);
            var summary = DateSevice.AnalyzeMonth(model.Year);
            ViewBag.Year = model.Year;
            return View(summary);
        }



    }
}