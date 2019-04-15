using Kendo.Mvc.UI;
using System.Collections.Generic;
using RestSharp;
using System.Web.Mvc;
using ProjectForCourseWork_ver_2._0.Controllers.Base;
using System.Threading.Tasks;
using Common.Code;
using Common.DTO;
using Common.Filters;
using Kendo.Mvc.Extensions;
using System;

namespace ProjectForCourseWork_ver_2._0.Controllers
{
    public class TypeOfRoomController : Controller
    {
        public async Task<ActionResult> GetAllTypes([DataSourceRequest] DataSourceRequest request)
        {
            var objects = await RestQuery.ExecuteAsync<List<TypeOfRoomDto>>("http://localhost:57770/", "GetAllTypes", Method.GET);

            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> AddType(TypeOfRoomDto type)
        {
            var response = await RestQuery.ExecuteAsync<string>("http://localhost:57770/", "AddType", Method.POST, type);
            return Json(response);
        }

        public async Task<ActionResult> UpdateType(Guid id, TypeOfRoomDto type)
        {
            var response = await RestQuery.ExecuteAsync<string>("http://localhost:57770/", $"UpdateType/{id}", Method.PUT, type);
            return Json(response);
        }

        public async Task<ActionResult> DeleteType(Guid id)
        {
            var response = await RestQuery.ExecuteAsync<string>("http://localhost:57770/", $"DeleteType/{id}", Method.DELETE);
            return Json(response);
        }
    }
}