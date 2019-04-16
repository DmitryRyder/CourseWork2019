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
    /// Контроллер для работы со зданиями
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : BaseController
    {
        UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BuildingsController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Метод возвращающий все здания в базе данных
        /// </summary>
        [HttpGet]
        [Route("/GetAllBuildings")]
        [ProducesResponseType(typeof(List<BuildingDto>), 200)]
        public JsonResult GetAllBuildings()
        {
            var buildings = unitOfWork.GetRepository<Building>().Include(x => x.rooms);

            return Json(mapper, buildings, typeof(List<BuildingDto>));
        }

        /// <summary>
        /// Метод возвращающий комнаты для определнного здания
        /// </summary>
        [HttpGet]
        [Route("/GetRoomsForBuilding/{id}")]
        [ProducesResponseType(typeof(List<RoomDto>), 200)]
        public JsonResult GetRoomsForBuilding(Guid id)
        {
            var rooms = unitOfWork.GetRepository<Room>().Include(x => x.Building).Where(r => r.BuildingId == id);

            return Json(mapper, rooms, typeof(List<RoomDto>));
        }

        /// <summary>
        /// Метод возвращающий список этажей в здании
        /// </summary>
        [HttpGet]
        [Route("/GetFloorsForBuilding/{id}")]
        [ProducesResponseType(typeof(List<Selected>), 200)]
        public async Task<JsonResult> GetFloorsForBuilding(Guid id)
        {
            var building = await unitOfWork.GetRepository<Building>().GetByIdAsync(id);

            List<Selected> floors = new List<Selected>();

            for (int i = 1; i <= building.Number_of_floors; i++)
                floors.Add(new Selected { Key = i.ToString()});

            return Json(floors);
        }
        
        /// <summary>
        /// Метод добавляющий здание в базу данных
        /// </summary>
        [HttpPost]
        [Route("/AddBuilding")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult AddBuilding(BuildingDto model)
        {
            var building = model.MapTo<Building>(mapper);

            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<Building>().InsertAsync(building);
                unitOfWork.GetRepository<Building>().SaveAsync();
                return new ObjectResult("Model added successfully!");
            }
            return new ObjectResult("Model added unsuccessfully!");
        }

        /// <summary>
        /// Метод для обновления существующего здания в базе данных
        /// </summary>
        [HttpPut]
        [Route("/UpdateBuilding/{id}")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> UpdateBuilding(Guid id, BuildingDto model)
        {
            var building = model.MapTo<Building>(mapper);
            var newBuilding = await unitOfWork.GetRepository<Building>().GetByIdAsync(id);
            newBuilding.Name = building.Name;
            newBuilding.Post = building.Post;
            newBuilding.Number_of_floors = building.Number_of_floors;

            if (ModelState.IsValid && id == model.Id)
            {
                unitOfWork.GetRepository<Building>().Update(newBuilding);
                unitOfWork.GetRepository<Building>().SaveAsync();
                return new ObjectResult("Model updated successfully!");
            }
            return new ObjectResult("Model updated unsuccessfully!");
        }

        /// <summary>
        /// Метод для удаления здания по id
        /// </summary>
        [HttpDelete]
        [Route("/DeleteBuilding/{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult DeleteBuilding(Guid id)
        {
            unitOfWork.GetRepository<Building>().DeleteById(id);
            unitOfWork.GetRepository<Building>().Save();

            return new ObjectResult("Model deleted successfully!");
        }
    }
}