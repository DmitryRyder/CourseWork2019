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
using System.Linq;

namespace ProjectForCourseWork_ver_2._0.Controllers
{
    public class ReportsController : BaseController
    {
        public async Task<ActionResult> GetWaterVolumeForManagementBodies([DataSourceRequest] DataSourceRequest request)
        {
            var objects = await RestQuery.ExecuteAsync<List<WaterVolumeDto>>("http://localhost:57770/", "GetWaterVolumeForManagementBodies", Method.GET);
            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> GetWaterVolumeForOrganizations([DataSourceRequest] DataSourceRequest request)
        {
            var objects = await RestQuery.ExecuteAsync<List<WaterVolumeDto>>("http://localhost:57770/", "GetWaterVolumeForOrganizations", Method.GET);
            return Json(objects.Data.ToDataSourceResult(request));
        }

        [HttpPost]
        public async Task<ActionResult> GetPipesLengthForOrganizations([DataSourceRequest] DataSourceRequest request, OrganizationsFilterDto filter)
        {
            if (filter == null)
                return Json("Non criteria");
            var objects = await RestQuery.ExecuteAsync<List<PipeLengthDto>>("http://localhost:57770/", "GetPipesLengthForOrganizations", Method.POST, filter);
            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> GetRepairsDataForPeriod([DataSourceRequest] DataSourceRequest request, PeriodFilter filter)
        {
            var objects = await RestQuery.ExecuteAsync<List<PipelineSectionDto>>("http://localhost:57770/", "GetRepairsDataForPeriod", Method.POST, filter);
            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> CascadingGetOrganizations()
        {
            var objectsO = await RestQuery.ExecuteAsync<List<OrganizationMDto>>("http://localhost:57770/", "GetAllOrganizationsM", Method.GET);

            return Json(objectsO.Data.ToList());
        }
    }
}