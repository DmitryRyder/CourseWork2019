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
    /// Контроллер для c типами сетей
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MPThermalTypeController : BaseController
    {
        UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MPThermalTypeController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Метод возвращающий все типы сетей из базы данных
        /// </summary>
        [HttpGet]
        [Route("/GetAllThermalTypes")]
        [ProducesResponseType(typeof(List<ThermalTypeDto>), 200)]
        public JsonResult GetAllThermalTypes()
        {
            var thermalTypes = unitOfWork.GetRepository<ThermalType>().Include(x => x.ThermalNetworks);

            return Json(mapper, thermalTypes, typeof(List<ThermalTypeDto>));
        }

        /// <summary>
        /// Метод добавляющий тип сети в базу данных
        /// </summary>
        [HttpPost]
        [Route("/AddThermalType")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult AddThermalType(ThermalTypeDto model)
        {
            var thermalType = model.MapTo<ThermalType>(mapper);

            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<ThermalType>().InsertAsync(thermalType);
                unitOfWork.GetRepository<ThermalType>().SaveAsync();
                return new ObjectResult("Model added successfully!");
            }
            return new ObjectResult("Model added unsuccessfully!");
        }

        /// <summary>
        /// Метод для обновления существующего типа сети в базе данных
        /// </summary>
        [HttpPut]
        [Route("/UpdateThermalType/{id}")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> UpdateThermalType(Guid id, ThermalTypeDto model)
        {
            var thermalType = model.MapTo<ThermalType>(mapper);
            var newThermalType = await unitOfWork.GetRepository<ThermalType>().GetByIdAsync(id);
            newThermalType.Name = thermalType.Name;

            if (ModelState.IsValid && id == model.Id)
            {
                unitOfWork.GetRepository<ThermalType>().Update(newThermalType);
                unitOfWork.GetRepository<ThermalType>().SaveAsync();
                return new ObjectResult("Model updated successfully!");
            }
            return new ObjectResult("Model updated unsuccessfully!");
        }

        /// <summary>
        /// Метод для удаления типа сети по id
        /// </summary>
        [HttpDelete]
        [Route("/DeleteThermalType/{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult DeleteThermalType(Guid id)
        {
            unitOfWork.GetRepository<ThermalType>().DeleteById(id);
            unitOfWork.GetRepository<ThermalType>().Save();

            return new ObjectResult("Model deleted successfully!");
        }
    }
}