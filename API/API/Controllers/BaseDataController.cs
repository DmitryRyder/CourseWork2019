using System.Collections.Generic;
using System.Threading.Tasks;
using API.Controllers.Base;
using API.Core.DAL;
using API.Core.Interfaces;
using AutoMapper;
using Common.DTO.BaseData;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseDataController : BaseController
    {
        UnitOfWork unitOfWork;
        IRepository<Building> buildingRepository;
        IRepository<Room> roomRepository;
        private readonly IMapper mapper;

        public BaseDataController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            buildingRepository = unitOfWork.GetRepository<Building>();
            roomRepository = unitOfWork.GetRepository<Room>();
        }

        [HttpPost]
        [Route("/AutoBuildingAdd")]
        [ProducesResponseType(typeof(ObjectResult), 200)]
        public IActionResult AutoAddOrganization()
        {
            var building = new Building
            {
                Name = "здание",
                Post = "юр. адрес",
                Number_of_floors = 5
            };

            buildingRepository.Insert(building);
            buildingRepository.Save();
            return new ObjectResult("Building added!");
        }

        [HttpGet]
        [Route("/GetAllBuildings")]
        [ProducesResponseType(typeof(List<BuildingDto>), 200)]
        public JsonResult GetAllBuildings()
        {
            var buildings = buildingRepository.GetAll();

            return Json(mapper, buildings, typeof(List<BuildingDto>));
        }

        [HttpPost]
        [Route("/AutoRoomAdd")]
        [ProducesResponseType(typeof(ObjectResult), 200)]
        public IActionResult AutoAddRoom()
        {
            var room = new Room
            {
                Number = 22,
                Area = 33.1,
                Floor = 3
            };

            roomRepository.Insert(room);
            roomRepository.Save();
            return new ObjectResult("Room added!");
        }
    }
}