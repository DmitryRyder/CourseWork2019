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
    public class MPSteelPipeController : BaseController
    {
        public async Task<ActionResult> GetAllPipes([DataSourceRequest] DataSourceRequest request)
        {
            var objects = await RestQuery.ExecuteAsync<List<SteelPipeDto>>("http://localhost:57770/", "GetAllPipes", Method.GET);
            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> AddPipe(SteelPipeDto model)
        {
            var response = await RestQuery.ExecuteAsync<SteelPipeDto>("http://localhost:57770/", "AddPipe", Method.POST, model);
            return Json(response);
        }

        public async Task<ActionResult> UpdatePipe(Guid id, SteelPipeDto model)
        {
            var response = await RestQuery.ExecuteAsync<List<SteelPipeDto>>("http://localhost:57770/", $"UpdatePipe/{id}", Method.PUT, model);
            return Json(response);
        }

        public async Task<ActionResult> DeletePipe(Guid id)
        {
            var response = await RestQuery.ExecuteAsync<List<SteelPipeDto>>("http://localhost:57770/", $"DeletePipe/{id}", Method.DELETE);
            return Json(response);
        }
    }
}