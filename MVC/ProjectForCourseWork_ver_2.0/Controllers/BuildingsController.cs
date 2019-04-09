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
using System;

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

        public async Task<ActionResult> GetForDropDownList()
        {
            var objects = await RestQuery.ExecuteAsync<List<BuildingDto>>("http://localhost:57770/", "GetAllBuildings", Method.GET);

            return Json(objects.Data);
        }

        public async Task<ActionResult> AddBuildings([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<BuildingDto> buildings)
        {
            var response = await RestQuery.ExecuteAsync<List<BuildingDto>>("http://localhost:57770/", "AddBuildings", Method.POST, buildings);
            return Json(response);
        }

        public async Task<ActionResult> UpdateBuildings([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<BuildingDto> buildings)
        {
            var response = await RestQuery.ExecuteAsync<List<BuildingDto>>("http://localhost:57770/", "UpdateBuildings", Method.PUT, buildings);
            return Json(response);
        }
        public async Task<ActionResult> DeleteBuildings(int id)
        {
            var response = await RestQuery.ExecuteAsync<List<BuildingDto>>("http://localhost:57770/", $"DeleteBuilding", Method.DELETE);
            return Json(response);
        }
    }
}