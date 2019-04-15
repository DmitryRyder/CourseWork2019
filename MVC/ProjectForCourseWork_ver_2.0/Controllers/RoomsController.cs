using Kendo.Mvc.UI;
using System.Collections.Generic;
using RestSharp;
using System.Web.Mvc;
using ProjectForCourseWork_ver_2._0.Controllers.Base;
using System.Threading.Tasks;
using Common.Code;
using Common.DTO;
using System.Linq;
using System;
using Common.Filters;
using Common.Models;
using Kendo.Mvc.Extensions;

namespace ProjectForCourseWork_ver_2._0.Controllers
{
    public class RoomsController : BaseController
    {
        public async Task<ActionResult> GetAllRooms([DataSourceRequest] DataSourceRequest request)
        {
            //var filters = new BaseFilterDto { Request = request };
            var objects = await RestQuery.ExecuteAsync<List<RoomDto>>("http://localhost:57770/", "GetAllRooms", Method.GET);
            //var (data, aggregateResults) = filters.ApplyGroupingAndAggregates(objects.Data);

            //var result = new DataSourceResult
            //{
            //    AggregateResults = aggregateResults,
            //    Data = data,
            //    Total = objects.DataCount
            //};
            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> AddRoom(RoomDto Room)
        {
            var response = await RestQuery.ExecuteAsync<List<RoomDto>>("http://localhost:57770/", "AddRoom", Method.POST, Room);
            return Json(response);
        }

        public async Task<ActionResult> UpdateRoom(Guid id, RoomDto Room)
        {
            var response = await RestQuery.ExecuteAsync<List<RoomDto>>("http://localhost:57770/", $"UpdateRoom/{id}", Method.PUT, Room);
            return Json(response);
        }
        public async Task<ActionResult> DeleteRoom(Guid id)
        {
            var response = await RestQuery.ExecuteAsync<List<RoomDto>>("http://localhost:57770/", $"DeleteRoom/{id}", Method.DELETE);
            return Json(response);
        }

        //каскадное добавление данных
        public async Task<ActionResult> CascadingGetBuildings()
        {
            var objectsO = await RestQuery.ExecuteAsync<List<BuildingDto>>("http://localhost:57770/", "GetAllBuildings", Method.GET);

            return Json(objectsO.Data, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CascadingGetTypes()
        {
            var objectsO = await RestQuery.ExecuteAsync<List<TypeOfRoomDto>>("http://localhost:57770/", "GetAllTypes", Method.GET);

            return Json(objectsO.Data, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CascadingGetFloors(Guid buildingId)
        {
            var objectsO = await RestQuery.ExecuteAsync<List<Selected>>("http://localhost:57770/", $"GetFloorsForBuilding/{buildingId}", Method.GET);
            //var objectsO = await RestQuery.ExecuteAsync<List<BuildingDto>>("http://localhost:57770/", "GetAllBuildings", Method.GET);
            //var t = new List<Selected> { new Selected { Key = "2" }, new Selected { Key = "3" }, new Selected { Key = "4" } };

            return Json(objectsO.Data, JsonRequestBehavior.AllowGet);
        }
    }
}