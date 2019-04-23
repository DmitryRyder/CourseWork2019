using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Base;
using API.Core.DAL;
using Common.DTO;
using Common.Extensions;
using Common.Filters;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер для вывода отчетов согласно заданию курсовой
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : BaseController
    {
        UnitOfWork unitOfWork;

        public ReportsController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Метод возвращающий все организации въезжавшие в помещения за определенный период
        /// </summary>
        [HttpPost]
        [Route("/GetOrganizationsForPeriod")]
        [ProducesResponseType(typeof(List<OrganizationForReportsDto>), 200)]
        public async Task<IActionResult> GetOrganizationsForPeriod(OrganizationPeriodFilterDto filter)
        {
            var organizations = await unitOfWork.GetRepository<Room_rental>().Query().Where(r => r.InputDate >= filter.DateStart && r.InputDate <= filter.DateEnd)
                                                               .Select(p => new OrganizationForReportsDto
                                                               {
                                                                   Name = p.Organization.Name,
                                                                   Post = p.Organization.Post,
                                                                   InputDate = p.InputDate,
                                                                   OutputDate = p.OutputDate,
                                                                   BuildingName = p.Room.Building.Name,
                                                                   RoomNumber = p.Room.Number
                                                               }).ToListAsync();
            return Json(organizations);
        }

        /// <summary>
        /// Метод возвращающий все организации въезжавшие в заданное здание за выбранный период
        /// </summary>
        [HttpPost]
        [Route("/GetOrganizationsInBuildAndPeriod")]
        [ProducesResponseType(typeof(List<OrganizationForReportsDto>), 200)]
        public async Task<IActionResult> GetOrganizationsInBuildAndPeriod(OrganizationBuildingAndPeriodFilterDto filter)
        {
            var organizations = await unitOfWork.GetRepository<Room_rental>().Query().Where(r => r.InputDate >= filter.DateStart && r.InputDate <= filter.DateEnd && r.Room.BuildingId == filter.BuildingId)
                                                               .Select(p => new OrganizationForReportsDto
                                                               {
                                                                   Name = p.Organization.Name,
                                                                   Post = p.Organization.Post,
                                                                   InputDate = p.InputDate,
                                                                   OutputDate = p.OutputDate,
                                                                   BuildingName = p.Room.Building.Name,
                                                                   RoomNumber = p.Room.Number
                                                               }).ToListAsync();
            return Json(organizations);
        }

        /// <summary>
        /// Метод возвращающий все организации с просроченной оплатой по счетам за электричество
        /// </summary>
        [HttpPost]
        [Route("/GetDebtorOrganizationForDate")]
        [ProducesResponseType(typeof(List<OrganizationForReportsDto>), 200)]
        public async Task<IActionResult> GetDebtorOrganizationForDate(OrganizationDebtorDateFilter filter)
        {
            var organizations = await unitOfWork.GetRepository<Invoice>().Query().Where(r => r.PaymentDate < filter.Date && !r.StatusOfPayment)
                                                               .Select(p => new OrganizationForReportsDto
                                                               {
                                                                   Name = p.Room_Rental.Organization.Name,
                                                                   Post = p.Room_Rental.Organization.Post,
                                                                   InputDate = p.Room_Rental.InputDate,
                                                                   OutputDate = p.Room_Rental.OutputDate,
                                                                   BuildingName = p.Room_Rental.Room.Building.Name,
                                                                   RoomNumber = p.Room_Rental.Room.Number
                                                               }).ToListAsync();
            return Json(organizations);
        }
    }
}