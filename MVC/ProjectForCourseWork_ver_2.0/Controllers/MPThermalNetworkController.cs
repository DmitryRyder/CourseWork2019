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
    public class MPThermalNetworkController : BaseController
    {
        public async Task<ActionResult> GetAllThermalNetworks([DataSourceRequest] DataSourceRequest request)
        {
            var objects = await RestQuery.ExecuteAsync<List<ThermalNetworkDto>>("http://localhost:57770/", "GetAllThermalNetworks", Method.GET);
            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> AddThermalNetwork(ThermalNetworkDto model)
        {
            var response = await RestQuery.ExecuteAsync<ThermalNetworkDto>("http://localhost:57770/", "AddThermalNetwork", Method.POST, model);
            return Json(response);
        }

        public async Task<ActionResult> DeleteThermalNetwork(Guid id)
        {
            var response = await RestQuery.ExecuteAsync<List<ThermalNetworkDto>>("http://localhost:57770/", $"DeleteThermalNetwork/{id}", Method.DELETE);
            return Json(response);
        }

        //Каскадное добавление (или выборка для комбобоксов)
        public async Task<ActionResult> CascadingGetOrganizations()
        {
            var objectsO = await RestQuery.ExecuteAsync<List<OrganizationMDto>>("http://localhost:57770/", "GetAllOrganizationsM", Method.GET);

            return Json(objectsO.Data, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CascadingGetThermalType()
        {
            var objectsO = await RestQuery.ExecuteAsync<List<ThermalTypeDto>>("http://localhost:57770/", "GetAllThermalTypes", Method.GET);

            return Json(objectsO.Data, JsonRequestBehavior.AllowGet);
        }
    }
}