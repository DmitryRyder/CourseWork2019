using Common.Code;
using Common.DTO;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjectForCourseWork_ver_2._0.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Buildings()
        {
            return View();
        }

        public ActionResult TypeOfRooms()
        {
            return View();
        }

        public ActionResult Organizations()
        {
            return View();
        }

        public ActionResult ElectricsByOrganization()
        {
            return View();
        }

        public ActionResult Electrics()
        {
            return View();
        }

        public ActionResult AddElectricWindow()
        {
            return View();
        }
       
        public ActionResult AddRentalWindow()
        {
            return View();
        }

        public ActionResult AddRoomWindow()
        {
            return View();
        }

        public ActionResult Rooms()
        {
            return View();
        }

        public ActionResult RoomsRental()
        {
            return View();
        }
    }
}