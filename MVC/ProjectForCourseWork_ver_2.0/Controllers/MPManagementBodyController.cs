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
    public class MPManagementBodyController : BaseController
    {
        public async Task<ActionResult> GetAllManagementBodies([DataSourceRequest] DataSourceRequest request)
        {
            var objects = await RestQuery.ExecuteAsync<List<ManagementBodyDto>>("http://localhost:57770/", "GetAllManagementBodies", Method.GET);
            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> AddManagementBody(ManagementBodyDto model)
        {
            var response = await RestQuery.ExecuteAsync<ManagementBodyDto>("http://localhost:57770/", "AddManagementBody", Method.POST, model);
            return Json(response);
        }

        public async Task<ActionResult> UpdateManagementBody(Guid id, ManagementBodyDto model)
        {
            var response = await RestQuery.ExecuteAsync<List<ManagementBodyDto>>("http://localhost:57770/", $"UpdateManagementBody/{id}", Method.PUT, model);
            return Json(response);
        }

        public async Task<ActionResult> DeleteManagementBody(Guid id)
        {
            var response = await RestQuery.ExecuteAsync<List<ManagementBodyDto>>("http://localhost:57770/", $"DeleteManagementBody/{id}", Method.DELETE);
            return Json(response);
        }
    }
}