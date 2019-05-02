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
    /// Контроллер для работы с узлами тепловой сети
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MPManagementBodyController : BaseController
    {
        UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MPManagementBodyController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Метод возвращающий все органы управления из базы данных
        /// </summary>
        [HttpGet]
        [Route("/GetAllManagementBodies")]
        [ProducesResponseType(typeof(List<ManagementBodyDto>), 200)]
        public JsonResult GetAllManagementBodies()
        {
            var typeOfNodes = unitOfWork.GetRepository<ManagementBody>().Include(x => x.Organizations);

            return Json(mapper, typeOfNodes, typeof(List<ManagementBodyDto>));
        }

        /// <summary>
        /// Метод добавляющий орган управления в базу данных
        /// </summary>
        [HttpPost]
        [Route("/AddManagementBody")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult AddManagementBody(ManagementBodyDto model)
        {
            var managementBody = model.MapTo<ManagementBody>(mapper);

            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<ManagementBody>().InsertAsync(managementBody);
                unitOfWork.GetRepository<ManagementBody>().SaveAsync();
                return new ObjectResult("Model added successfully!");
            }
            return new ObjectResult("Model added unsuccessfully!");
        }

        /// <summary>
        /// Метод для обновления существующего органа управления в базе данных
        /// </summary>
        [HttpPut]
        [Route("/UpdateManagementBody/{id}")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> UpdateManagementBody(Guid id, ManagementBodyDto model)
        {
            var managementBody = model.MapTo<ManagementBody>(mapper);
            var newManagementBody = await unitOfWork.GetRepository<ManagementBody>().GetByIdAsync(id);
            newManagementBody.Name = managementBody.Name;

            if (ModelState.IsValid && id == model.Id)
            {
                unitOfWork.GetRepository<ManagementBody>().Update(newManagementBody);
                unitOfWork.GetRepository<ManagementBody>().SaveAsync();
                return new ObjectResult("Model updated successfully!");
            }
            return new ObjectResult("Model updated unsuccessfully!");
        }

        /// <summary>
        /// Метод для удаления органа управления по id
        /// </summary>
        [HttpDelete]
        [Route("/DeleteManagementBody/{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult DeleteTypeOfNode(Guid id)
        {
            unitOfWork.GetRepository<ManagementBody>().DeleteById(id);
            unitOfWork.GetRepository<ManagementBody>().Save();

            return new ObjectResult("Model deleted successfully!");
        }
    }
}