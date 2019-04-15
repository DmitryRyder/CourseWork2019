using Kendo.Mvc.UI;
using System.Collections.Generic;
using RestSharp;
using System.Web.Mvc;
using ProjectForCourseWork_ver_2._0.Controllers.Base;
using System.Threading.Tasks;
using Common.Code;
using Common.DTO;
using System;
using Kendo.Mvc.Extensions;
using Common.Filters;

namespace ProjectForCourseWork_ver_2._0.Controllers
{
    public class RoomsRentalController : BaseController
    {
        public async Task<ActionResult> GetAllRentalRooms([DataSourceRequest] DataSourceRequest request)
        {
            var objects = await RestQuery.ExecuteAsync<List<RoomRentalDto>>("http://localhost:57770/", "GetAllRentalRooms", Method.GET);

            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> GetFiltered([DataSourceRequest] DataSourceRequest request, RoomRentalDtoFilters filters)
        {
            var response = await RestQuery.ExecuteAsync<List<RoomRentalDto>>("http://localhost:57770/", "GetFilteredRentalRooms", Method.POST, filters);

            return Json(response.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> AddRentalRoom(RoomRentalDto Room)
        {
            var response = await RestQuery.ExecuteAsync<List<RoomRentalDto>>("http://localhost:57770/", "AddRentalRoom", Method.POST, Room);
            return Json(response);
        }

        public async Task<ActionResult> UpdateRentalRoom(Guid id, RoomRentalDto Room)
        {
            var response = await RestQuery.ExecuteAsync<List<RoomRentalDto>>("http://localhost:57770/", $"UpdateRentalRoom/{id}", Method.PUT, Room);
            return Json(response);
        }
        public async Task<ActionResult> DeleteRentalRoom(Guid id)
        {
            var response = await RestQuery.ExecuteAsync<List<RoomRentalDto>>("http://localhost:57770/", $"DeleteRentalRoom/{id}", Method.DELETE);
            return Json(response);
        }
        //каскадное добавление данных
        public async Task<ActionResult> CascadingGetOrganizations()
        {
            var objectsO = await RestQuery.ExecuteAsync<List<OrganizationDto>>("http://localhost:57770/", "GetAllOrganizations", Method.GET);

            return Json(objectsO.Data, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CascadingGetBuildings()
        {
            var objectsO = await RestQuery.ExecuteAsync<List<BuildingDto>>("http://localhost:57770/", "GetAllBuildings", Method.GET);

            return Json(objectsO.Data, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CascadingGetRooms(Guid buildingId)
        {
            var objectsO = await RestQuery.ExecuteAsync<List<RoomDto>>("http://localhost:57770/", $"GetRoomsForBuilding/{buildingId}", Method.GET);

            return Json(objectsO.Data, JsonRequestBehavior.AllowGet);
        }
    }
}