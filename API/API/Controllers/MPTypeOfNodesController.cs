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
    /// Контроллер для работы с типами узлов
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MPTypeOfNodesController : BaseController
    {
        UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MPTypeOfNodesController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Метод возвращающий все типы узлов из базы данных
        /// </summary>
        [HttpGet]
        [Route("/GetAllTypeOfNodes")]
        [ProducesResponseType(typeof(List<TypeOfNodeDto>), 200)]
        public JsonResult GetAllTypeOfNodes()
        {
            var typeOfNodes = unitOfWork.GetRepository<TypeOfNode>().Include(x => x.ThermalNodes);

            return Json(mapper, typeOfNodes, typeof(List<TypeOfNodeDto>));
        }

        /// <summary>
        /// Метод добавляющий тип узла в базу данных
        /// </summary>
        [HttpPost]
        [Route("/AddTypeOfNode")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult AddTypeOfNode(TypeOfNodeDto model)
        {
            var typeOfNode = model.MapTo<TypeOfNode>(mapper);

            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<TypeOfNode>().InsertAsync(typeOfNode);
                unitOfWork.GetRepository<TypeOfNode>().SaveAsync();
                return new ObjectResult("Model added successfully!");
            }
            return new ObjectResult("Model added unsuccessfully!");
        }

        /// <summary>
        /// Метод для обновления существующего типа узла в базе данных
        /// </summary>
        [HttpPut]
        [Route("/UpdateTypeOfNode/{id}")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> UpdateTypeOfNode(Guid id, TypeOfNodeDto model)
        {
            var typeOfNode = model.MapTo<TypeOfNode>(mapper);
            var newTypeOfNode = await unitOfWork.GetRepository<TypeOfNode>().GetByIdAsync(id);
            newTypeOfNode.Name = typeOfNode.Name;

            if (ModelState.IsValid && id == model.Id)
            {
                unitOfWork.GetRepository<TypeOfNode>().Update(newTypeOfNode);
                unitOfWork.GetRepository<TypeOfNode>().SaveAsync();
                return new ObjectResult("Model updated successfully!");
            }
            return new ObjectResult("Model updated unsuccessfully!");
        }

        /// <summary>
        /// Метод для удаления типа узла по id
        /// </summary>
        [HttpDelete]
        [Route("/DeleteTypeOfNode/{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult DeleteTypeOfNode(Guid id)
        {
            unitOfWork.GetRepository<TypeOfNode>().DeleteById(id);
            unitOfWork.GetRepository<TypeOfNode>().Save();

            return new ObjectResult("Model deleted successfully!");
        }
    }
}