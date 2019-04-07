using Common.Extensions;
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
        private readonly IMapper mapper;

        public RoomsController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("/GetAllRooms")]
        [ProducesResponseType(typeof(List<RoomDto>), 200)]
        public JsonResult GetAllRooms()
        {
            var Rooms = unitOfWork.GetRepository<Room>().Include(x => x.TypeOfRoom);
            
            return Json(mapper, Rooms, typeof(List<RoomDto>));
        }

        [HttpPost]
        [Route("/AddRoom")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult AddRoom(RoomDto model)
        {
            var room = model.MapTo<Room>(mapper);
            Type_of_room typeOfRoom = null;

            if (!model.TypeOfRoom.IsNullOrEmpty())
            {
                typeOfRoom = unitOfWork.GetRepository<Type_of_room>().Query()
                                                                         .Where(t => model.TypeOfRoom.ToLower() == t.Name.ToLower())
                                                                         .FirstOrDefault();
            }

            if (typeOfRoom == null && !model.TypeOfRoom.IsNullOrEmpty())
            {
                unitOfWork.GetRepository<Type_of_room>().Insert(new Type_of_room { Name = model.TypeOfRoom });
                unitOfWork.GetRepository<Type_of_room>().Save();
            }
            else
                return new ObjectResult("Model added unsuccessfully!");

            room.Type_of_roomId = unitOfWork.GetRepository<Type_of_room>().Query()
                                                                            .Where(t => model.TypeOfRoom.ToLower() == t.Name.ToLower())
                                                                            .Select(t => t.Id)
                                                                            .FirstOrDefault();
            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<Room>().Insert(room);
                unitOfWork.GetRepository<Room>().Save();
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

        [HttpDelete]
        [Route("/DeleteRoom/{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult DeleteRoom(int id)
        {
            unitOfWork.GetRepository<Room>().DeleteById(id);
            unitOfWork.GetRepository<Room>().Save();

            return new ObjectResult("Model deleted successfully!");
        }
    }
}