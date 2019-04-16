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
    public class InvoiceController : BaseController
    {
        public async Task<ActionResult> GetAllinvoices([DataSourceRequest] DataSourceRequest request)
        {
            var objects = await RestQuery.ExecuteAsync<List<InvoiceDto>>("http://localhost:57770/", "GetAllinvoices", Method.GET);
            return Json(objects.Data.ToDataSourceResult(request));
        }

        public async Task<ActionResult> AddInvoice(InvoiceDto invoice)
        {
            var response = await RestQuery.ExecuteAsync<InvoiceDto>("http://localhost:57770/", "AddInvoice", Method.POST, invoice);
            return Json(response);
        }

        public async Task<ActionResult> DeleteInvoice(Guid id)
        {
            var response = await RestQuery.ExecuteAsync<List<BuildingDto>>("http://localhost:57770/", $"DeleteInvoice/{id}", Method.DELETE);
            return Json(response);
        }

        public async Task<ActionResult> CascadingGetRentalRooms()
        {
            var objectsO = await RestQuery.ExecuteAsync<List<RoomRentalDto>>("http://localhost:57770/", $"GetAllRentalRooms", Method.GET);

            return Json(objectsO.Data, JsonRequestBehavior.AllowGet);
        }
    }
}