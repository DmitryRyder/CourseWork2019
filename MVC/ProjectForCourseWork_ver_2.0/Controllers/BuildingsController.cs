﻿using Kendo.Mvc.UI;
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
    public class BuildingsController : BaseController
    {
        public async Task<ActionResult> GetAllBuildings([DataSourceRequest] DataSourceRequest request)
        {
            var objects = await RestQuery.ExecuteAsync<List<BuildingDto>>("http://localhost:57770/", "GetAllBuildings", Method.GET);
            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> GetForDropDownList()
        {
            var objects = await RestQuery.ExecuteAsync<List<BuildingDto>>("http://localhost:57770/", "GetAllBuildings", Method.GET);

            return Json(objects.Data);
        }

        public async Task<ActionResult> AddBuilding(BuildingDto building)
        {
            var response = await RestQuery.ExecuteAsync<BuildingDto>("http://localhost:57770/", "AddBuilding", Method.POST, building);
            return Json(response);
        }

        public async Task<ActionResult> UpdateBuilding(Guid id, BuildingDto building)
        {
            var response = await RestQuery.ExecuteAsync<List<BuildingDto>>("http://localhost:57770/", $"UpdateBuilding/{id}", Method.PUT, building);
            return Json(response);
        }

        public async Task<ActionResult> DeleteBuilding(Guid id)
        {
            var response = await RestQuery.ExecuteAsync<List<BuildingDto>>("http://localhost:57770/", $"DeleteBuilding/{id}", Method.DELETE);
            return Json(response);
        }
    }
}