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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfRoomController : BaseController
    {
        UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TypeOfRoomController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("/GetAllTypes")]
        [ProducesResponseType(typeof(List<TypeOfRoomDto>), 200)]
        public JsonResult GetAllTypes()
        {
            var buildings = unitOfWork.GetRepository<Type_of_room>().Include(x => x.rooms);

            return Json(mapper, buildings, typeof(List<TypeOfRoomDto>));
        }

        [HttpPost]
        [Route("/AddType")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult AddBuilding(TypeOfRoomDto model)
        {
            var type = model.MapTo<Type_of_room>(mapper);

            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<Type_of_room>().InsertAsync(type);
                unitOfWork.SaveAsync();
                return new ObjectResult("Model added successfully!");
            }
            return new ObjectResult("Model added unsuccessfully!");
        }

        [HttpPut]
        [Route("/UpdateType/{id}")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> UpdateBuilding(Guid id, TypeOfRoomDto model)
        {
            var type = model.MapTo<Type_of_room>(mapper);
            var newType = await unitOfWork.GetRepository<Type_of_room>().GetByIdAsync(id);
            newType.Name = type.Name;

            if (ModelState.IsValid && id == model.Id)
            {
                unitOfWork.GetRepository<Type_of_room>().Update(newType);
                unitOfWork.GetRepository<Type_of_room>().SaveAsync();
                return new ObjectResult("Model updated successfully!");
            }
            return new ObjectResult("Model updated unsuccessfully!");
        }

        [HttpDelete]
        [Route("/DeleteType/{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult DeleteBuilding(Guid id)
        {
            unitOfWork.GetRepository<Type_of_room>().DeleteById(id);
            unitOfWork.GetRepository<Type_of_room>().Save();

            return new ObjectResult("Model deleted successfully!");
        }
    }
}