using Kendo.Mvc.UI;
using System.Collections.Generic;
using RestSharp;
using System.Web.Mvc;
using ProjectForCourseWork_ver_2._0.Controllers.Base;
using System.Threading.Tasks;
using Common.Code;
using Common.DTO;
using Kendo.Mvc.Extensions;
using System;

namespace ProjectForCourseWork_ver_2._0.Controllers
{
    public class MPThermalTypeController : BaseController
    {
        public async Task<ActionResult> GetAllThermalTypes([DataSourceRequest] DataSourceRequest request)
        {
            var objects = await RestQuery.ExecuteAsync<List<ThermalTypeDto>>("http://localhost:57770/", "GetAllThermalTypes", Method.GET);
            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> AddThermalType(ThermalTypeDto model)
        {
            var response = await RestQuery.ExecuteAsync<ThermalTypeDto>("http://localhost:57770/", "AddThermalType", Method.POST, model);
            return Json(response);
        }

        public async Task<ActionResult> UpdateThermalType(Guid id, ThermalTypeDto model)
        {
            var response = await RestQuery.ExecuteAsync<List<ThermalTypeDto>>("http://localhost:57770/", $"UpdateThermalType/{id}", Method.PUT, model);
            return Json(response);
        }

        public async Task<ActionResult> DeleteThermalType(Guid id)
        {
            var response = await RestQuery.ExecuteAsync<List<ThermalTypeDto>>("http://localhost:57770/", $"DeleteThermalType/{id}", Method.DELETE);
            return Json(response);
        }
    }
}