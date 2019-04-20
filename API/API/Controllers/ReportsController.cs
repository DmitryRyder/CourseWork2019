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
    /// Контроллер для отчетов согласно заданию
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : BaseController
    {
        UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ReportsController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Метод объем воды по организациям и органам управления
        /// </summary>
        [HttpGet]
        [Route("/GetWaterVolume")]
        [ProducesResponseType(typeof(List<TypeOfNodeDto>), 200)]
        public JsonResult GetAllTypeOfNodes()
        {
            var typeOfNodes = unitOfWork.GetRepository<TypeOfNode>().Include(x => x.ThermalNodes);

            return Json(mapper, typeOfNodes, typeof(List<TypeOfNodeDto>));
        }
    }
}