using System.Collections.Generic;
using System.Linq;
using API.Core.DAL;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {

        UnitOfWork unitOfWork;

        public HomeController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Сохранить/Обновить
        /// </summary>
        [HttpGet]
        [Route("/one")]
        [ProducesResponseType(typeof(List<string>), 200)]
        public JsonResult Index()
        {
            var p = unitOfWork.GetRepository<Planet>().Query().Where(i => i.satellites.Count > 5).Select(i => i.Name).ToList();
            //return "dqqwdqwdqd";
            return Json(p);
        }

        /// <summary>
        /// Сохранить/Обновить
        /// </summary>
        [HttpGet]
        [Route("/two")]
        [ProducesResponseType(typeof(List<Planet>), 200)]
        public JsonResult Index2()
        {
            var p = unitOfWork.GetRepository<Planet>().GetAll();
            //return "dqqwdqwdqd";
            return Json(p);
        }
    }
}