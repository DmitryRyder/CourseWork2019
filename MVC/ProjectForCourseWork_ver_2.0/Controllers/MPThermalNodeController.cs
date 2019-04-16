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
    public class MPThermalNodeController : BaseController
    {
        public async Task<ActionResult> GetAllThermalNodes([DataSourceRequest] DataSourceRequest request)
        {
            var objects = await RestQuery.ExecuteAsync<List<ThermalNodeDto>>("http://localhost:57770/", "GetAllThermalNodes", Method.GET);
            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> AddThermalNode(ThermalNodeDto thermalNode)
        {
            var response = await RestQuery.ExecuteAsync<ThermalNodeDto>("http://localhost:57770/", "AddThermalNode", Method.POST, thermalNode);
            return Json(response);
        }

        public async Task<ActionResult> DeleteThermalNode(Guid id)
        {
            var response = await RestQuery.ExecuteAsync<List<ThermalNodeDto>>("http://localhost:57770/", $"DeleteThermalNode/{id}", Method.DELETE);
            return Json(response);
        }

        //Каскадное добавление (или выборка для комбобоксов)
        public async Task<ActionResult> CascadingGetTypeOfNodes()
        {
            var objectsO = await RestQuery.ExecuteAsync<List<TypeOfNodeDto>>("http://localhost:57770/", "GetAllTypeOfNodes", Method.GET);

            return Json(objectsO.Data, JsonRequestBehavior.AllowGet);
        }
    }
}