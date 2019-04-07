using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectForCourseWork_ver_2._0.Controllers
{
    public class MainController : Controller
    {
        public ActionResult GetBuildings()
        {
            return View();
        }

        public ActionResult Buildings()
        {
            return View();
        }

        public ActionResult Rooms()
        {
            return View();
        }
    }
}