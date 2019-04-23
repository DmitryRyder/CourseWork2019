using System.Collections.Generic;
using API.Controllers.Base;
using API.Core.DAL;
using AutoMapper;
using BackOffice.API.Core.Extensions;
using Common.Code;
using Common.DTO;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : BaseController
    {
        UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public RoomsController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Метод возвращающий все помещения в базе данных
        /// </summary>
        [HttpGet]
        [Route("/GetAllRooms")]
        [ProducesResponseType(typeof(List<RoomDto>), 200)]
        public JsonResult GetAllRoomsAsync()
        {
            var rooms = unitOfWork.GetRepository<Room>().Include(x => x.Building);

            return Json(mapper, rooms, typeof(List<RoomDto>));
        }

        /// <summary>
        /// Метод добавляющий помещение в базу данных
        /// </summary>
        [HttpPost]
        [Route("/AddRoom")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult AddRoom(RoomDto model)
        {
            var room = model.MapTo<Room>(mapper);

            room.Building = null;

            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<Room>().InsertAsync(room);
                unitOfWork.GetRepository<Room>().Save();
                return new ObjectResult("Model added successfully!");
            }
            return new ObjectResult("Model added unsuccessfully!");
        }

        /// <summary>
        /// Метод обновляющй существующее помещение в базе данных
        /// </summary>
        [HttpPut]
        [Route("/UpdateRoom/{id}")]
        [ProducesResponseType(typeof(string), 200)]
        public IActionResult UpdateRoom(Guid id, RoomDto model)
        {
            var room = model.MapTo<Room>(mapper);
            var newRoom = unitOfWork.GetRepository<Room>().GetById(id);
            newRoom.Number = room.Number;
            newRoom.Area = room.Area;
            newRoom.Floor = room.Floor;

            if (ModelState.IsValid && id == model.Id)
            {
                unitOfWork.GetRepository<Room>().Update(newRoom);
                unitOfWork.GetRepository<Room>().Save();
                return new ObjectResult("Model updated successfully!");
            }
            return new ObjectResult("Model updated unsuccessfully!");
        }

        /// <summary>
        /// Метод удаляющий помещение в базе данных по id
        /// </summary>
        [HttpDelete]
        [Route("/DeleteRoom/{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult DeleteRoom(Guid id)
        {
            unitOfWork.GetRepository<Room>().DeleteById(id);
            unitOfWork.GetRepository<Room>().Save();

            return new ObjectResult("Model deleted successfully!");
        }
    }
}