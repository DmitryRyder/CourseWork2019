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
    public class MPOrganizationsController : BaseController
    {
        public async Task<ActionResult> GetAllOrganizationsM([DataSourceRequest] DataSourceRequest request)
        {
            var objects = await RestQuery.ExecuteAsync<List<OrganizationMDto>>("http://localhost:57770/", "GetAllOrganizationsM", Method.GET);
            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> AddOrganizationM(OrganizationMDto model)
        {
            var response = await RestQuery.ExecuteAsync<OrganizationMDto>("http://localhost:57770/", "AddOrganizationM", Method.POST, model);
            return Json(response);
        }

        public async Task<ActionResult> DeleteOrganizationM(Guid id)
        {
            var response = await RestQuery.ExecuteAsync<List<OrganizationMDto>>("http://localhost:57770/", $"DeleteOrganizationM/{id}", Method.DELETE);
            return Json(response);
        }

        //Каскадное добавление (или выборка для комбобоксов)
        public async Task<ActionResult> CascadingGetManagementBodies()
        {
            var objectsO = await RestQuery.ExecuteAsync<List<ManagementBodyDto>>("http://localhost:57770/", "GetAllManagementBodies", Method.GET);

            return Json(objectsO.Data, JsonRequestBehavior.AllowGet);
        }
    }
}