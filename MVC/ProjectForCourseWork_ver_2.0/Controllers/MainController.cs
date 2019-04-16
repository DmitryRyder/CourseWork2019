using System.Web.Mvc;

namespace ProjectForCourseWork_ver_2._0.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Buildings() => View();

        public ActionResult TypeOfRooms() => View();

        public ActionResult Organizations() => View();

        public ActionResult ElectricsByOrganization() => View();

        public ActionResult Electrics() => View();

        public ActionResult AddElectricWindow() => View();
       
        public ActionResult AddRentalWindow() => View();

        public ActionResult AddRoomWindow() => View();

        public ActionResult Rooms() => View();

        public ActionResult RoomsRental() => View();
    }
}