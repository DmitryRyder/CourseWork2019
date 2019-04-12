using Kendo.Mvc.UI;
using System.Collections.Generic;
using RestSharp;
using System.Web.Mvc;
using ProjectForCourseWork_ver_2._0.Controllers.Base;
using System.Threading.Tasks;
using Common.Code;
using Common.DTO;
using System.Linq;
using Common.Filters;

namespace ProjectForCourseWork_ver_2._0.Controllers
{
    public class RoomsRentalController : BaseController
    {
        public async Task<ActionResult> GetAllRentalRooms([DataSourceRequest] DataSourceRequest request)
        {
            var filters = new BaseFilterDto { Request = request };
            var objects = await RestQuery.ExecuteAsync<List<RoomRentalDto>>("http://localhost:57770/", "GetAllRentalRooms", Method.GET);
            var (data, aggregateResults) = filters.ApplyGroupingAndAggregates(objects.Data);

            var result = new DataSourceResult
            {
                AggregateResults = aggregateResults,
                Data = data,
                Total = objects.DataCount
            };
            return Json(result);
        }

        public async Task<ActionResult> AddRentalRoom(RoomRentalDto Room)
        {
            var response = await RestQuery.ExecuteAsync<List<RoomRentalDto>>("http://localhost:57770/", "AddRentalRoom", Method.POST, Room);
            return Json(response);
        }

        public async Task<ActionResult> UpdateRentalRoom(int id, RoomRentalDto Room)
        {
            var response = await RestQuery.ExecuteAsync<List<RoomRentalDto>>("http://localhost:57770/", $"UpdateRentalRoom/{id}", Method.PUT, Room);
            return Json(response);
        }
        public async Task<ActionResult> DeleteRentalRoom(int id)
        {
            var response = await RestQuery.ExecuteAsync<List<RoomRentalDto>>("http://localhost:57770/", $"DeleteRentalRoom/{id}", Method.DELETE);
            return Json(response);
        }
    }
}