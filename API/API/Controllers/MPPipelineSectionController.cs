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
    /// Контроллер для работы с трубами
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MPPipelineSectionController : BaseController
    {
        UnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public MPPipelineSectionController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Метод возвращающий все участки трбопровода из базы данных
        /// </summary>
        [HttpGet]
        [Route("/GetAllPipelineSections")]
        [ProducesResponseType(typeof(List<PipelineSection>), 200)]
        public JsonResult GetAllPipelineSections()
        {
            var typeOfNodes = unitOfWork.GetRepository<PipelineSection>().Include(x => x.SteelPipe, x => x.Nodes);

            return Json(mapper, typeOfNodes, typeof(List<PipelineSectionDto>));
        }

        /// <summary>
        /// Метод добавляющий участок трубопровода в базу данных
        /// </summary>
        [HttpPost]
        [Route("/AddPipelineSections")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public async Task<IActionResult> AddPipelineSections(PipelineSectionDto model)
        {
            var pipelineSection = model.MapTo<PipelineSection>(mapper);
            var initialNode = await unitOfWork.GetRepository<ThermalNode>().GetByIdAsync(model.InitialNoneId);
            var endNode = await unitOfWork.GetRepository<ThermalNode>().GetByIdAsync(model.EndNodeId);
            pipelineSection.Nodes.Add(initialNode);
            pipelineSection.Nodes.Add(endNode);

            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<PipelineSection>().InsertAsync(pipelineSection);
                unitOfWork.GetRepository<PipelineSection>().SaveAsync();
                return new ObjectResult("Model added successfully!");
            }
            return new ObjectResult("Model added unsuccessfully!");
        }

        /// <summary>
        /// Метод для удаления участка трубопровода по id
        /// </summary>
        [HttpDelete]
        [Route("/DeletePipelineSections/{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult DeletePipelineSections(Guid id)
        {
            unitOfWork.GetRepository<PipelineSection>().DeleteById(id);
            unitOfWork.GetRepository<PipelineSection>().Save();

            return new ObjectResult("Model deleted successfully!");
        }
    }
}