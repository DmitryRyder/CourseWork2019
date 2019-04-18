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
    public class MPPipelineSectionController : BaseController
    {
        public async Task<ActionResult> GetAllPipelineSections([DataSourceRequest] DataSourceRequest request)
        {
            var objects = await RestQuery.ExecuteAsync<List<PipelineSectionDto>>("http://localhost:57770/", "GetAllPipelineSections", Method.GET);
            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> AddPipelineSections(PipelineSectionDto model)
        {
            var response = await RestQuery.ExecuteAsync<PipelineSectionDto>("http://localhost:57770/", "AddPipelineSections", Method.POST, model);
            return Json(response);
        }

        public async Task<ActionResult> DeletePipelineSections(Guid id)
        {
            var response = await RestQuery.ExecuteAsync<List<PipelineSectionDto>>("http://localhost:57770/", $"DeletePipelineSections/{id}", Method.DELETE);
            return Json(response);
        }

        //Каскадное добавление (или выборка для комбобоксов)
        public async Task<ActionResult> CascadingGetSteelPipes()
        {
            var objectsO = await RestQuery.ExecuteAsync<List<SteelPipeDto>>("http://localhost:57770/", "GetAllPipes", Method.GET);

            return Json(objectsO.Data, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetAllThermalNetworks()
        {
            var objectsO = await RestQuery.ExecuteAsync<List<ThermalNetworkDto>>("http://localhost:57770/", "GetAllThermalNetworks", Method.GET);

            return Json(objectsO.Data, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetAllThermalNode()
        {
            var objectsO = await RestQuery.ExecuteAsync<List<ThermalNodeDto>>("http://localhost:57770/", "GetAllThermalNode", Method.GET);

            return Json(objectsO.Data, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetAllTypeOfNodes()
        {
            var objectsO = await RestQuery.ExecuteAsync<List<TypeOfNodeDto>>("http://localhost:57770/", "GetAllTypeOfNodes", Method.GET);

            return Json(objectsO.Data, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> GetAllPipes()
        {
            var objectsO = await RestQuery.ExecuteAsync<List<SteelPipeDto>>("http://localhost:57770/", "GetAllPipes", Method.GET);

            return Json(objectsO.Data, JsonRequestBehavior.AllowGet);
        }
    }
}