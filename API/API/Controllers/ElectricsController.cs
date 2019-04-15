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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер для работы со зданиями
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricsController : BaseController
    {
        UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ElectricsController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Метод возвращающий всё электрооборудование для организаций в базе данных
        /// </summary>
        [HttpGet]
        [Route("/GetAllElectrics")]
        [ProducesResponseType(typeof(List<ElectricDto>), 200)]
        public JsonResult GetAllElectrics()
        {
            var buildings = unitOfWork.GetRepository<Electric>().GetAll()/*Include(x => x.Organization, x => x.Electric)*/;

            return Json(mapper, buildings, typeof(List<ElectricDto>));
        }

        /// <summary>
        /// Метод добавляющий элекрооборудование в базу данных
        /// </summary>
        [HttpPost]
        [Route("/AddElectric")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult AddElectric(ElectricDto model)
        {
            var building = model.MapTo<Electric>(mapper);

            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<Electric>().InsertAsync(building);
                unitOfWork.GetRepository<Electric>().SaveAsync();
                return new ObjectResult("Model added successfully!");
            }
            return new ObjectResult("Model added unsuccessfully!");
        }

        /// <summary>
        /// Метод для обновления существующего здания в базе данных
        /// </summary>
        [HttpPut]
        [Route("/UpdateElectric/{id}")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> UpdateElectric(Guid id, ElectricDto model)
        {
            var electric = model.MapTo<Electric>(mapper);
            var newElectric = await unitOfWork.GetRepository<Electric>().GetByIdAsync(id);

            if (ModelState.IsValid && id == model.Id)
            {
                unitOfWork.GetRepository<Electric>().Update(newElectric);
                unitOfWork.GetRepository<Electric>().SaveAsync();
                return new ObjectResult("Model updated successfully!");
            }
            return new ObjectResult("Model updated unsuccessfully!");
        }

        /// <summary>
        /// Метод для удаления электрооборудования по id
        /// </summary>
        [HttpDelete]
        [Route("/DeleteElectric/{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult DeleteElectric(Guid id)
        {
            unitOfWork.GetRepository<Electric>().DeleteById(id);
            unitOfWork.GetRepository<Electric>().Save();

            return new ObjectResult("Model deleted successfully!");
        }
    }
}