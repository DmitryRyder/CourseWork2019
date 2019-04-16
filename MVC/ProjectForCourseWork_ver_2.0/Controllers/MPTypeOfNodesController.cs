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
    public class MPTypeOfNodesController : BaseController
    {
        public async Task<ActionResult> GetAllTypeOfNodes([DataSourceRequest] DataSourceRequest request)
        {
            var objects = await RestQuery.ExecuteAsync<List<TypeOfNodeDto>>("http://localhost:57770/", "GetAllTypeOfNodes", Method.GET);
            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> AddTypeOfNode(TypeOfNodeDto typeOfNodeDto)
        {
            var response = await RestQuery.ExecuteAsync<TypeOfNodeDto>("http://localhost:57770/", "AddTypeOfNode", Method.POST, typeOfNodeDto);
            return Json(response);
        }

        public async Task<ActionResult> UpdateTypeOfNode(Guid id, TypeOfNodeDto typeOfNodeDto)
        {
            var response = await RestQuery.ExecuteAsync<List<TypeOfNodeDto>>("http://localhost:57770/", $"UpdateTypeOfNode/{id}", Method.PUT, typeOfNodeDto);
            return Json(response);
        }

        public async Task<ActionResult> DeleteTypeOfNode(Guid id)
        {
            var response = await RestQuery.ExecuteAsync<List<TypeOfNodeDto>>("http://localhost:57770/", $"DeleteTypeOfNode/{id}", Method.DELETE);
            return Json(response);
        }
    }
}