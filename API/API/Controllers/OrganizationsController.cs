using System;
using System.Collections.Generic;
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
    public class OrganizationsController : BaseController
    {
        UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OrganizationsController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Метод возвращающий все организации в базе данных
        /// </summary>
        [HttpGet]
        [Route("/GetAllOrganizations")]
        [ProducesResponseType(typeof(List<OrganizationDto>), 200)]
        public JsonResult GetAllOrganizations()
        {
            var organizations = unitOfWork.GetRepository<Organization>().GetAll();

            return Json(mapper, organizations, typeof(List<OrganizationDto>));
        }

        /// <summary>
        /// Метод добавляющий организацию в базу данных
        /// </summary>
        [HttpPost]
        [Route("/AddOrganization")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult AddOrganization(OrganizationDto model)
        {
            var organization = model.MapTo<Organization>(mapper);

            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<Organization>().InsertAsync(organization);
                unitOfWork.GetRepository<Organization>().SaveAsync();
                return new ObjectResult("Model added successfully!");
            }
            return new ObjectResult("Model added unsuccessfully!");
        }

        /// <summary>
        /// Метод для обновления существующей организации в базе данных
        /// </summary>
        [HttpPut]
        [Route("/UpdateOrganization/{id}")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> UpdateOrganization(Guid id, OrganizationDto model)
        {
            var organization = model.MapTo<Organization>(mapper);
            var newOrganization = await unitOfWork.GetRepository<Organization>().GetByIdAsync(id);
            newOrganization.Name = organization.Name;
            newOrganization.Post = organization.Post;

            if (ModelState.IsValid && id == model.Id)
            {
                unitOfWork.GetRepository<Organization>().Update(newOrganization);
                unitOfWork.GetRepository<Organization>().SaveAsync();
                return new ObjectResult("Model updated successfully!");
            }
            return new ObjectResult("Model updated unsuccessfully!");
        }

        /// <summary>
        /// Метод для удаления организации по id
        /// </summary>
        [HttpDelete]
        [Route("/DeleteOrganization/{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult DeleteOrganization(Guid id)
        {
            unitOfWork.GetRepository<Organization>().DeleteById(id);
            unitOfWork.GetRepository<Organization>().Save();

            return new ObjectResult("Model deleted successfully!");
        }
    }
}