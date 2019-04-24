﻿using System.Web.Mvc;

namespace ProjectForCourseWork_ver_2._0.Controllers
{
    public class MainController : Controller
    {
        public ActionResult MPTypeOfNodes() => View();
        public ActionResult MPThermalType() => View();
        public ActionResult MPManagementBodies() => View();
        public ActionResult MPOrganizations() => View();
        public ActionResult AddOrganizationMWindow() => View();
        public ActionResult MPThermalNetworks() => View();
        public ActionResult AddThermalNetworkWindow() => View();
        public ActionResult MPSteelPipes() => View();
        public ActionResult MPPipelineSections() => View();
        public ActionResult AddPipelineSectionWindow() => View();
        public ActionResult Start() => View();

        //ОТЧЕТЫ
        public ActionResult One() => View();
        public ActionResult Two() => View();
        public ActionResult Three() => View();
        public ActionResult Four() => View();
    }
}