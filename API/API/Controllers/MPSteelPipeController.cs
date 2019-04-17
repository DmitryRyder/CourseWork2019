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
    public class MPSteelPipeController : BaseController
    {
        UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MPSteelPipeController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Метод возвращающий все трубы из базы данных
        /// </summary>
        [HttpGet]
        [Route("/GetAllPipes")]
        [ProducesResponseType(typeof(List<SteelPipeDto>), 200)]
        public JsonResult GetAllPipes()
        {
            var steelPipe = unitOfWork.GetRepository<SteelPipe>().Include(x => x.PipelineSections);

            return Json(mapper, steelPipe, typeof(List<SteelPipeDto>));
        }

        /// <summary>
        /// Метод добавляющий трубу в базу данных
        /// </summary>
        [HttpPost]
        [Route("/AddPipe")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult AddPipe(SteelPipeDto model)
        {
            var steelPipe = model.MapTo<SteelPipe>(mapper);

            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<SteelPipe>().InsertAsync(steelPipe);
                unitOfWork.GetRepository<SteelPipe>().SaveAsync();
                return new ObjectResult("Model added successfully!");
            }
            return new ObjectResult("Model added unsuccessfully!");
        }

        /// <summary>
        /// Метод для обновления существующей трубы в базе данных
        /// </summary>
        [HttpPut]
        [Route("/UpdatePipe/{id}")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> UpdatePipe(Guid id, SteelPipeDto model)
        {
            var steelPipe = model.MapTo<SteelPipe>(mapper);
            var newSteelPipe = await unitOfWork.GetRepository<SteelPipe>().GetByIdAsync(id);
            newSteelPipe.Name = steelPipe.Name;
            newSteelPipe.Diameter = steelPipe.Diameter;
            newSteelPipe.Thickness = steelPipe.Thickness;
            newSteelPipe.Volume = steelPipe.Volume;
            newSteelPipe.Weight = steelPipe.Weight;

            if (ModelState.IsValid && id == model.Id)
            {
                unitOfWork.GetRepository<SteelPipe>().Update(newSteelPipe);
                unitOfWork.GetRepository<SteelPipe>().SaveAsync();
                return new ObjectResult("Model updated successfully!");
            }
            return new ObjectResult("Model updated unsuccessfully!");
        }

        /// <summary>
        /// Метод для удаления трубы по id
        /// </summary>
        [HttpDelete]
        [Route("/DeletePipe/{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult DeletePipe(Guid id)
        {
            unitOfWork.GetRepository<SteelPipe>().DeleteById(id);
            unitOfWork.GetRepository<SteelPipe>().Save();

            return new ObjectResult("Model deleted successfully!");
        }
    }
}