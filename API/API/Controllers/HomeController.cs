using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Core.DAL;
using API.Core.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class HomeController : Controller
    {

        UnitOfWork unitOfWork;

        public HomeController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public JsonResult Index()
        {
            var p = unitOfWork.PlanetRepository.Query().Where(i => i.satellites.Count > 5).Select(i => i.Name).ToList();
            //return "dqqwdqwdqd";
            return Json(p);
        }
    }
}