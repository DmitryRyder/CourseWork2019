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
    public class MPThermalNodeController : BaseController
    {
        UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MPThermalNodeController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Метод добавляющий узел в базу данных
        /// </summary>
        [HttpPost]
        [Route("/AddThermalNode")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult AddThermalNode(ThermalNodeDto model)
        {
            var thermalNode = model.MapTo<ThermalNode>(mapper);

            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<ThermalNode>().InsertAsync(thermalNode);
                unitOfWork.GetRepository<ThermalNode>().SaveAsync();
                return new ObjectResult("Model added successfully!");
            }
            return new ObjectResult("Model added unsuccessfully!");
        }
    }
}