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
    public class BuildingsController : BaseController
    {
        public async Task<ActionResult> GetAllBuildings([DataSourceRequest] DataSourceRequest request)
        {
            var filters = new BaseFilterDto { Request = request };
            var objects = await RestQuery.ExecuteAsync<List<BuildingDto>>("http://localhost:57770/", "GetAllBuildings", Method.GET);
            var (data, aggregateResults) = filters.ApplyGroupingAndAggregates(objects.Data);
            var result = new DataSourceResult
            {
                AggregateResults = aggregateResults,
                Data = data,
                Total = objects.DataCount
            };
            return Json(result);
        }

        public async Task<ActionResult> AddBuilding(BuildingDto building)
        {
            var response = await RestQuery.ExecuteAsync<List<BuildingDto>>("http://localhost:57770/", "AddBuilding", Method.POST, building);
            return Json(response);
        }

        public async Task<ActionResult> UpdateBuilding(int id, BuildingDto building)
        {
            var response = await RestQuery.ExecuteAsync<List<BuildingDto>>("http://localhost:57770/", $"UpdateBuilding/{id}", Method.PUT, building);
            return Json(response);
        }
        public async Task<ActionResult> DeleteBuilding(int id)
        {
            var response = await RestQuery.ExecuteAsync<List<BuildingDto>>("http://localhost:57770/", $"DeleteBuilding/{id}", Method.DELETE);
            return Json(response);
        }
    }
}