using System.Linq;
using API.Core.DAL;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {

        UnitOfWork unitOfWork;

        public HomeController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("/one")]
        public JsonResult Index()
        {
            var p = unitOfWork.GetRepository<Planet>().Query().Where(i => i.satellites.Count > 5).Select(i => i.Name).ToList();
            //return "dqqwdqwdqd";
            return Json(p);
        }
        [HttpGet("/two")]
        public JsonResult Index2()
        {
            var p = unitOfWork.GetRepository<Planet>().GetAll();
            //return "dqqwdqwdqd";
            return Json(p);
        }
    }
}