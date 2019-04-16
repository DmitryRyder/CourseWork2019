using Kendo.Mvc.UI;
using System.Collections.Generic;
using RestSharp;
using System.Web.Mvc;
using ProjectForCourseWork_ver_2._0.Controllers.Base;
using System.Threading.Tasks;
using Common.Code;
using Common.DTO;
using Kendo.Mvc.Extensions;
using Common.Filters;

namespace ProjectForCourseWork_ver_2._0.Controllers
{
    public class ReportsController : BaseController
    {
        public async Task<ActionResult> GetOrganizationsForPeriod([DataSourceRequest] DataSourceRequest request, OrganizationPeriodFilterDto filters)
        {
            var objects = await RestQuery.ExecuteAsync<List<OrganizationForReportsDto>>("http://localhost:57770/", "GetOrganizationsForPeriod", Method.POST, filters);

            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> GetOrganizationsInBuildAndPeriod([DataSourceRequest] DataSourceRequest request, OrganizationBuildingAndPeriodFilterDto filters)
        {
            var objects = await RestQuery.ExecuteAsync<List<OrganizationForReportsDto>>("http://localhost:57770/", "GetOrganizationsInBuildAndPeriod", Method.POST, filters);

            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> GetOrganizationsOutBuildAndPeriod([DataSourceRequest] DataSourceRequest request, OrganizationBuildingAndPeriodFilterDto filters)
        {
            var objects = await RestQuery.ExecuteAsync<List<OrganizationForReportsDto>>("http://localhost:57770/", "GetOrganizationsOutBuildAndPeriod", Method.POST, filters);

            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> GetDebtorOrganizationForDate([DataSourceRequest] DataSourceRequest request, OrganizationDebtorDateFilter filters)
        {
            var objects = await RestQuery.ExecuteAsync<List<OrganizationForReportsDto>>("http://localhost:57770/", "GetDebtorOrganizationForDate", Method.POST, filters);

            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> GetInvoicesWithFullInfoOfCurrentMonth([DataSourceRequest] DataSourceRequest request)
        {
            var objects = await RestQuery.ExecuteAsync<List<OrganizationWithInvoicesForReportsDto>>("http://localhost:57770/", "GetInvoicesWithFullInfoOfCurrentMonth", Method.POST);

            return Json(objects.Data.ToDataSourceResult(request));
        }
    }
}