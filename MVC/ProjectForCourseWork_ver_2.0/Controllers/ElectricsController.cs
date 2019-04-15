using Kendo.Mvc.UI;
using System.Collections.Generic;
using RestSharp;
using System.Web.Mvc;
using ProjectForCourseWork_ver_2._0.Controllers.Base;
using System.Threading.Tasks;
using Common.Code;
using Common.DTO;
using Common.Filters;
using System;
using Kendo.Mvc.Extensions;

namespace ProjectForCourseWork_ver_2._0.Controllers
{
    public class ElectricsController : BaseController
    {
        // GET: Electrics
        public async Task<ActionResult> GetAllElectrics([DataSourceRequest] DataSourceRequest request)
        {
            //var filters = new BaseFilterDto { Request = request };
            var objects = await RestQuery.ExecuteAsync<List<ElectricDto>>("http://localhost:57770/", "GetAllElectrics", Method.GET);
            //var (data, aggregateResults) = filters.ApplyGroupingAndAggregates(objects.Data);
            //var result = new DataSourceResult
            //{
            //    AggregateResults = aggregateResults,
            //    Data = data,
            //    Total = objects.DataCount
            //};
            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> AddElectric(ElectricDto model)
        {
            var response = await RestQuery.ExecuteAsync<ElectricDto>("http://localhost:57770/", "AddElectric", Method.POST, model);
            return Json(response);
        }

        public async Task<ActionResult> UpdateElectric(Guid id, ElectricDto model)
        {
            var response = await RestQuery.ExecuteAsync<List<ElectricDto>>("http://localhost:57770/", $"UpdateElectric/{id}", Method.PUT, model);
            return Json(response);
        }

        public async Task<ActionResult> DeleteElectric(Guid id)
        {
            var response = await RestQuery.ExecuteAsync<List<ElectricDto>>("http://localhost:57770/", $"DeleteElectric/{id}", Method.DELETE);
            return Json(response);
        }
    }
}