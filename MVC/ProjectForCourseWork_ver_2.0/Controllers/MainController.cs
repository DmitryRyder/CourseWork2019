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

        public ActionResult AddRentalWindow()
        {
            return View();
        }

        public ActionResult AddRoomWindow()
        {
            return View();
        }

        public async Task<ActionResult> Rooms()
        {
            var objectsB = await RestQuery.ExecuteAsync<List<BuildingDto>>("http://localhost:57770/", "GetAllBuildings", Method.GET);
            var objectsT = await RestQuery.ExecuteAsync<List<TypeOfRoomDto>>("http://localhost:57770/", "GetAllTypes", Method.GET);

            IList<BuildingDto> buildings = new List<BuildingDto>();
            IList<TypeOfRoomDto> types = new List<TypeOfRoomDto>();

            if (objectsB.Data.Count != 0)
            {
                foreach (var b in objectsB.Data as IEnumerable<BuildingDto>)
                {
                    buildings.Add(new BuildingDto { Id = b.Id, Name = b.Name });
                }

                buildings.OrderBy(e => e.Name);
            }

            if (objectsT.Data.Count != 0)
            {
                foreach (var t in objectsT.Data as IEnumerable<TypeOfRoomDto>)
                {
                    types.Add(new TypeOfRoomDto { Id = t.Id, Name = t.Name });
                }

                types.OrderBy(e => e.Name);
            }

            ViewData["buildings"] = buildings;
            ViewData["defaultBuilding"] = buildings?.First() ?? new BuildingDto();
            ViewData["typeOfRooms"] = types ?? null;
            ViewData["defaultType"] = types?.First() ?? new TypeOfRoomDto();

            return View();
        }

        public async Task<ActionResult> RoomsRental()
        {
            var objectsB = await RestQuery.ExecuteAsync<List<BuildingDto>>("http://localhost:57770/", "GetAllBuildings", Method.GET);
            var objectsO = await RestQuery.ExecuteAsync<List<OrganizationDto>>("http://localhost:57770/", "GetAllOrganizations", Method.GET);
            //var objectsR = await RestQuery.ExecuteAsync<List<OrganizationDto>>("http://localhost:57770/", "GetRoomsNotRental", Method.GET);

            IList<OrganizationDto> organizations = new List<OrganizationDto>();
            IList<BuildingDto> buildings = new List<BuildingDto>();
            //IList<RoomDto> rooms = new List<RoomDto>();

            if (objectsO.Data.Count != 0)
            {
                foreach (var b in objectsO.Data as IEnumerable<OrganizationDto>)
                {
                    organizations.Add(new OrganizationDto { Id = b.Id, Name = b.Name });
                }

                organizations.OrderBy(e => e.Name);
            }

            if (objectsB.Data.Count != 0)
            {
                foreach (var b in objectsB.Data as IEnumerable<BuildingDto>)
                {
                    buildings.Add(new BuildingDto { Id = b.Id, Name = b.Name });
                }

                buildings.OrderBy(e => e.Name);
            }

            //if (objectsR.Data.Count != 0)
            //{
            //    foreach (var b in objectsO.Data as IEnumerable<RoomDto>)
            //    {
            //        rooms.Add(new RoomDto { Id = b.Id, Number = b.Number });
            //    }

            //    rooms.OrderBy(e => e.Number);
            //}


            ViewData["buildings"] = buildings;
            ViewData["defaultBuilding"] = buildings?.First() ?? new BuildingDto();
            ViewData["organizations"] = organizations;
            ViewData["defaultOrganization"] = organizations?.First() ?? new OrganizationDto();

            return View();
        }
    }
}