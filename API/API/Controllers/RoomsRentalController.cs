﻿using System;
using System.Collections.Generic;
using System.Linq;
using API.Controllers.Base;
using API.Core.DAL;
using AutoMapper;
using BackOffice.API.Core.Extensions;
using Common.Code;
using Common.DTO;
using Common.Filters;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsRentalController : BaseController
    {
        UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public RoomsRentalController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("/GetAllRentalRooms")]
        [ProducesResponseType(typeof(List<RoomRentalDto>), 200)]
        public JsonResult GetAllRentalRooms()
        {
            var RoomsRental = unitOfWork.GetRepository<Room_rental>().Include(x => x.Room, x => x.Organization, x => x.Room.Building);

            var rooms = RoomsRental.MapTo<List<RoomRentalDto>>(mapper);

            return Json(mapper, RoomsRental, typeof(List<RoomRentalDto>));
        }

        [HttpPost]
        [Route("/GetFilteredRentalRooms")]
        [ProducesResponseType(typeof(List<RoomRentalDto>), 200)]
        public JsonResult GetFilteredRentalRooms(RoomRentalDtoFilters filter)
        {
            var RoomsRental = unitOfWork.GetRepository<Room_rental>().Include(x => x.Room, x => x.Organization, x => x.Room.Building)
                                                                     .Where(x => x.InputDate >= filter.DateInputStart && x.InputDate <= filter.DateInputEnd
                                                                            && x.OutputDate >= filter.DateOutputStart && x.OutputDate <= filter.DateOutputEnd);

            var rooms = RoomsRental.MapTo<List<RoomRentalDto>>(mapper);

            return Json(mapper, RoomsRental, typeof(List<RoomRentalDto>));
        }

        [HttpPost]
        [Route("/AddRentalRoom")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult AddRentalRoom(RoomRentalDto model)
        {
            var roomRental = model.MapTo<Room_rental>(mapper);

            //roomRental.Room = null;
            //roomRental.Organization = null;

            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<Room_rental>().InsertAsync(roomRental);
                unitOfWork.GetRepository<Room_rental>().Save();
                return new ObjectResult("Model added successfully!");
            }
            return new ObjectResult("Model added unsuccessfully!");
        }

        [HttpPut]
        [Route("/UpdateRentalRoom/{id}")]
        [ProducesResponseType(typeof(string), 200)]
        public IActionResult UpdateRentalRoom(Guid id, RoomRentalDto model)
        {
            var room = model.MapTo<Room_rental>(mapper);
            var newRoomRental = unitOfWork.GetRepository<Room_rental>().GetById(id);
            newRoomRental.InputDate = room.InputDate;
            newRoomRental.OutputDate = room.OutputDate;

            if (ModelState.IsValid && id == model.Id)
            {
                unitOfWork.GetRepository<Room_rental>().Update(newRoomRental);
                unitOfWork.GetRepository<Room_rental>().Save();
                return new ObjectResult("Model updated successfully!");
            }
            return new ObjectResult("Model updated unsuccessfully!");
        }

        [HttpDelete]
        [Route("/DeleteRentalRoom/{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult DeleteRentalRoom(Guid id)
        {
            unitOfWork.GetRepository<Room_rental>().DeleteById(id);
            unitOfWork.GetRepository<Room_rental>().Save();

            return new ObjectResult("Model deleted successfully!");
        }
    }
}