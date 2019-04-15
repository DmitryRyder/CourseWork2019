using Kendo.Mvc.UI;
using System.Collections.Generic;
using RestSharp;
using System.Web.Mvc;
using ProjectForCourseWork_ver_2._0.Controllers.Base;
using System.Threading.Tasks;
using Common.Code;
using Common.DTO;
using System;
using Kendo.Mvc.Extensions;

namespace ProjectForCourseWork_ver_2._0.Controllers
{
    public class ElectricsByOrganizationController : BaseController
    {
        public async Task<ActionResult> GetAllElectricsByOrganization([DataSourceRequest] DataSourceRequest request)
        {
            var objects = await RestQuery.ExecuteAsync<List<ElectricsByOrganizationDto>>("http://localhost:57770/", "GetAllElectricsByOrganization", Method.GET);
            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> AddElectricByOrganization(ElectricsByOrganizationDto model)
        {
            var response = await RestQuery.ExecuteAsync<List<ElectricsByOrganizationDto>>("http://localhost:57770/", "AddElectricByOrganization", Method.POST, model);
            return Json(response);
        }

        public async Task<ActionResult> DeleteElectricByOrganization(Guid id)
        {
            var response = await RestQuery.ExecuteAsync<List<ElectricsByOrganizationDto>>("http://localhost:57770/", $"DeleteElectricByOrganization/{id}", Method.DELETE);
            return Json(response);
        }

        public async Task<ActionResult> CascadingGetOrganizations()
        {
            var objectsO = await RestQuery.ExecuteAsync<List<OrganizationDto>>("http://localhost:57770/", "GetAllOrganizations", Method.GET);

            return Json(objectsO.Data, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CascadingGetElectrics()
        {
            var objectsO = await RestQuery.ExecuteAsync<List<ElectricDto>>("http://localhost:57770/", "GetAllElectrics", Method.GET);

            return Json(objectsO.Data, JsonRequestBehavior.AllowGet);
        }
    }
}