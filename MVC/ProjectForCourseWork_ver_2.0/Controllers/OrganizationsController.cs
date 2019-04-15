using Kendo.Mvc.UI;
using System.Collections.Generic;
using RestSharp;
using System.Web.Mvc;
using ProjectForCourseWork_ver_2._0.Controllers.Base;
using System.Threading.Tasks;
using Common.Code;
using Common.DTO;
using System;
using Common.Filters;
using Kendo.Mvc.Extensions;
namespace ProjectForCourseWork_ver_2._0.Controllers
{
    public class OrganizationsController : Controller
    {
        public async Task<ActionResult> GetAllOrganizations([DataSourceRequest] DataSourceRequest request)
        {
            var objects = await RestQuery.ExecuteAsync<List<OrganizationDto>>("http://localhost:57770/", "GetAllOrganizations", Method.GET);

            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> AddOrganization(OrganizationDto organization)
        {
            var response = await RestQuery.ExecuteAsync<OrganizationDto>("http://localhost:57770/", "AddOrganization", Method.POST, organization);
            return Json(response);
        }

        public async Task<ActionResult> UpdateOrganization(Guid id, OrganizationDto organization)
        {
            var response = await RestQuery.ExecuteAsync<List<OrganizationDto>>("http://localhost:57770/", $"UpdateOrganization/{id}", Method.PUT, organization);
            return Json(response);
        }

        public async Task<ActionResult> DeleteOrganization(Guid id)
        {
            var response = await RestQuery.ExecuteAsync<List<OrganizationDto>>("http://localhost:57770/", $"DeleteOrganization/{id}", Method.DELETE);
            return Json(response);
        }
    }
}