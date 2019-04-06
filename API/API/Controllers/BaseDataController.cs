using System.Collections.Generic;
using System.Linq;
using API.Core.DAL;
using API.Core.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseDataController : Controller
    {
        UnitOfWork unitOfWork;
        IRepository<Building> buildingRepository;
        IRepository<Room> roomRepository;

        public BaseDataController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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