using CalendarDate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalendarDate.Controllers
{
    public class HomeController : Controller
    {

       
        public ActionResult Index()
        {
           

            return View();
        }

        [HttpPost]
        public ActionResult Index(InputModel model)
        {
            
            TempData["InputModel"] = model;
            ViewBag.InputModel= model;
            return RedirectToAction("AnalyzeYear", "Date",  model );
        }

    }
}