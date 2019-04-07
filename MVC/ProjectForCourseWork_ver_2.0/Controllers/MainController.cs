using Common.Code;
using Common.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ActionResult> Rooms()
        {
            var objects = await RestQuery.ExecuteAsync<List<BuildingDto>>("http://localhost:57770/", "GetAllBuildings", Method.GET);

            IList<BuildingDto> buildings = new List<BuildingDto>();

            foreach (var b in objects.Data as IEnumerable<BuildingDto>)
            {
                buildings.Add(new BuildingDto { Id = b.Id, Name = b.Name });
            }

            buildings.OrderBy(e => e.Name);

            ViewData["buildings"] = buildings;
            ViewData["defaultBuilding"] = buildings?.First();

            return View();
        }
    }
}