using Kendo.Mvc.UI;
using System.Collections.Generic;
using RestSharp;
using System.Web.Mvc;
using ProjectForCourseWork_ver_2._0.Controllers.Base;
using System.Threading.Tasks;
using Common.Code;
using Common.DTO;
using Common;
using Common.Filters;

namespace ProjectForCourseWork_ver_2._0.Controllers
{
    public class RoomsController : BaseController
    {
        public async Task<ActionResult> GetAllRooms([DataSourceRequest] DataSourceRequest request)
        {
            var filters = new BaseFilterDto { Request = request };
            var objects = await RestQuery.ExecuteAsync<List<RoomDto>>("http://localhost:57770/", "GetAllRooms", Method.GET);
            var (data, aggregateResults) = filters.ApplyGroupingAndAggregates(objects.Data);
            var result = new DataSourceResult
            {
                AggregateResults = aggregateResults,
                Data = data,
                Total = objects.DataCount
            };
            return Json(result);
        }

        public async Task<ActionResult> AddRoom(RoomDto Room)
        {
            var response = await RestQuery.ExecuteAsync<List<RoomDto>>("http://localhost:57770/", "AddRoom", Method.POST, Room);
            return Json(response);
        }

        public async Task<ActionResult> UpdateRoom(int id, RoomDto Room)
        {
            var response = await RestQuery.ExecuteAsync<List<RoomDto>>("http://localhost:57770/", $"UpdateRoom/{id}", Method.PUT, Room);
            return Json(response);
        }
        public async Task<ActionResult> DeleteRoom(int id)
        {
            var response = await RestQuery.ExecuteAsync<List<RoomDto>>("http://localhost:57770/", $"DeleteRoom/{id}", Method.DELETE);
            return Json(response);
        }
    }
}