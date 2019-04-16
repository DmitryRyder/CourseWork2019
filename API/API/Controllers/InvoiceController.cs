using System;
using System.Collections.Generic;
using API.Controllers.Base;
using API.Core.DAL;
using AutoMapper;
using BackOffice.API.Core.Extensions;
using Common.Code;
using Common.DTO;
using Common.Models;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    /// <summary>
    /// Контроллер для работы со счетами
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : BaseController
    {
        UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public InvoiceController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Метод возвращающий все счета в базе данных
        /// </summary>
        [HttpGet]
        [Route("/GetAllInvoices")]
        [ProducesResponseType(typeof(List<InvoiceDto>), 200)]
        public JsonResult GetAllBuildings()
        {
            var invoices = unitOfWork.GetRepository<Invoice>().Include(x => x.Room_Rental);

            return Json(mapper, invoices, typeof(List<InvoiceDto>));
        }

        /// <summary>
        /// Метод добавляющий счет в базу данных
        /// </summary>
        [HttpPost]
        [Route("/AddInvoice")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult AddInvoice(InvoiceDto model)
        {
            var invoice = model.MapTo<Invoice>(mapper);

            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<Invoice>().InsertAsync(invoice);
                unitOfWork.GetRepository<Invoice>().SaveAsync();
                return new ObjectResult("Model added successfully!");
            }
            return new ObjectResult("Model added unsuccessfully!");
        }

        /// <summary>
        /// Метод для удаления счета по id
        /// </summary>
        [HttpDelete]
        [Route("/DeleteInvoice/{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult DeleteBuilding(Guid id)
        {
            unitOfWork.GetRepository<Invoice>().DeleteById(id);
            unitOfWork.GetRepository<Invoice>().Save();

            return new ObjectResult("Model deleted successfully!");
        }
    }
}