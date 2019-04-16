using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    /// Контроллер для работы с организациями
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MPOrganizationsController : BaseController
    {
        UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MPOrganizationsController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Метод возвращающий все организации из базы данных
        /// </summary>
        [HttpGet]
        [Route("/GetAllOrganizationsM")]
        [ProducesResponseType(typeof(List<OrganizationMDto>), 200)]
        public JsonResult GetAllOrganizationsM()
        {
            var typeOfNodes = unitOfWork.GetRepository<OrganizationM>().Include(x => x.ManagementBody, x => x.ThermalNetworks);

            return Json(mapper, typeOfNodes, typeof(List<OrganizationMDto>));
        }

        /// <summary>
        /// Метод организацию в базу данных
        /// </summary>
        [HttpPost]
        [Route("/AddOrganizationM")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult AddOrganizationM(OrganizationMDto model)
        {
            var organization = model.MapTo<OrganizationM>(mapper);

            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<OrganizationM>().InsertAsync(organization);
                unitOfWork.GetRepository<OrganizationM>().SaveAsync();
                return new ObjectResult("Model added successfully!");
            }
            return new ObjectResult("Model added unsuccessfully!");
        }

        /// <summary>
        /// Метод для удаления организации по id
        /// </summary>
        [HttpDelete]
        [Route("/DeleteOrganizationM/{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult DeleteOrganizationM(Guid id)
        {
            unitOfWork.GetRepository<OrganizationM>().DeleteById(id);
            unitOfWork.GetRepository<OrganizationM>().Save();

            return new ObjectResult("Model deleted successfully!");
        }
    }
}