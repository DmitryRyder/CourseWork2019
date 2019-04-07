using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Base;
using API.Core.DAL;
using API.Core.Interfaces;
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
    public class RoomsController : BaseController
    {
        UnitOfWork unitOfWork;
        IRepository<Room> RoomRepository;
        private readonly IMapper mapper;

        public RoomsController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            RoomRepository = unitOfWork.GetRepository<Room>();
        }

        [HttpGet]
        [Route("/GetAllRooms")]
        [ProducesResponseType(typeof(List<RoomDto>), 200)]
        public JsonResult GetAllRooms()
        {
            var Rooms = RoomRepository.GetAll();

            return Json(mapper, Rooms, typeof(List<RoomDto>));
        }

        [HttpPost]
        [Route("/AddRoom")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult AddRoom(RoomDto model)
        {
            var Room = model.MapTo<Room>(mapper);

            if (ModelState.IsValid)
            {
                RoomRepository.Insert(Room);
                RoomRepository.Save();
                return new ObjectResult("Model added successfully!");
            }
            return new ObjectResult("Model added unsuccessfully!");
        }

        [HttpPut]
        [Route("/UpdateRoom/{id}")]
        [ProducesResponseType(typeof(string), 200)]
        public IActionResult UpdateRoom(int id, RoomDto model)
        {
            var room = model.MapTo<Room>(mapper);
            var newRoom = RoomRepository.GetById(id);
            newRoom.Number = room.Number;
            newRoom.Area = room.Area;
            newRoom.Floor = room.Floor;

            if (ModelState.IsValid && id == model.Id)
            {
                RoomRepository.Update(newRoom);
                RoomRepository.Save();
                return new ObjectResult("Model updated successfully!");
            }
            return new ObjectResult("Model updated unsuccessfully!");
        }

        [HttpDelete]
        [Route("/DeleteRoom/{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult DeleteRoom(int id)
        {
            RoomRepository.DeleteById(id);
            RoomRepository.Save();

            return new ObjectResult("Model deleted successfully!");
        }
    }
}