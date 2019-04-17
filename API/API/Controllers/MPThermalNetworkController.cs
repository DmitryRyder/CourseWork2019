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
    /// Контроллер для работы с тепловыми сетями
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MPThermalNetworkController : BaseController
    {
        UnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public MPThermalNetworkController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Метод возвращающий все тепловые сети из базы данных
        /// </summary>
        [HttpGet]
        [Route("/GetAllThermalNetworks")]
        [ProducesResponseType(typeof(List<ThermalNetworkDto>), 200)]
        public JsonResult GetAllThermalNetworks()
        {
            var typeOfNodes = unitOfWork.GetRepository<ThermalNetwork>().Include(x => x.Organization, x => x.PipelineSections, x => x.ThermalType);

            return Json(mapper, typeOfNodes, typeof(List<ThermalNetworkDto>));
        }

        /// <summary>
        /// Метод добавляющий тепловую сеть в базу данных
        /// </summary>
        [HttpPost]
        [Route("/AddThermalNetwork")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult AddThermalNetwork(ThermalNetworkDto model)
        {
            var thermalNetwork = model.MapTo<ThermalNetwork>(mapper);

            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<ThermalNetwork>().InsertAsync(thermalNetwork);
                unitOfWork.GetRepository<ThermalNetwork>().SaveAsync();
                return new ObjectResult("Model added successfully!");
            }
            return new ObjectResult("Model added unsuccessfully!");
        }

        /// <summary>
        /// Метод для удаления тепловой сети по id
        /// </summary>
        [HttpDelete]
        [Route("/DeleteThermalNetwork/{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult DeleteThermalNetwork(Guid id)
        {
            unitOfWork.GetRepository<ThermalNetwork>().DeleteById(id);
            unitOfWork.GetRepository<ThermalNetwork>().Save();

            return new ObjectResult("Model deleted successfully!");
        }
    }
}