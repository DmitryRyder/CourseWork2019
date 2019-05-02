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
            var pipelineSections = unitOfWork.GetRepository<PipelineSection>().Include(x => x.SteelPipe, x => x.ThermalNetwork);
            return Json(mapper, pipelineSections, typeof(List<PipelineSectionDto>));
        }

        /// <summary>
        /// Метод добавляющий участок трубопровода в базу данных, включая вновь созданные участки трубопровода
        /// </summary>
        [HttpPost]
        [Route("/AddPipelineSections")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult AddPipelineSections(PipelineSectionDto model)
        {
            var initThermalNode = new ThermalNode() { Id = Guid.NewGuid(), Number = model.InitialThermalNode.Number, TypeOfNodeId = model.InitialThermalNode.TypeOfNodeId };
            var endThermalNode = new ThermalNode() { Id = Guid.NewGuid(), Number = model.EndThermalNode.Number, TypeOfNodeId = model.EndThermalNode.TypeOfNodeId };
            unitOfWork.GetRepository<ThermalNode>().Insert(initThermalNode);
            unitOfWork.GetRepository<ThermalNode>().Insert(endThermalNode);
            unitOfWork.GetRepository<ThermalNode>().Save();
            var pipelineSection = model.MapTo<PipelineSection>(mapper);

            pipelineSection.Nodes.Add(new Nodes() { ThermalNodeId = initThermalNode.Id });
            pipelineSection.Nodes.Add(new Nodes() { ThermalNodeId = endThermalNode.Id });
            //unitOfWork.GetRepository<PipelineSection>().InsertAsync(pipelineSection);
            //unitOfWork.GetRepository<PipelineSection>().SaveAsync();
            //pipelineSection = unitOfWork.GetRepository<PipelineSection>().Query().Where(p => p.NumberOfSection == model.NumberOfSection).FirstOrDefault();

            Guid initialNodeId, endNodeId;

            //if (model.InitialThermalNode != null)
            //{
                
            //}

            //if (model.EndThermalNode != null)
            //{
            //}

            unitOfWork.GetRepository<PipelineSection>().Insert(pipelineSection);
            unitOfWork.GetRepository<PipelineSection>().Save();
            unitOfWork.GetRepository<Nodes>().Save();
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