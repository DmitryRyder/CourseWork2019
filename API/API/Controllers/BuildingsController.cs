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
    public class BuildingsController : BaseController
    {
        UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BuildingsController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("/GetAllBuildings")]
        [ProducesResponseType(typeof(List<BuildingDto>), 200)]
        public JsonResult GetAllBuildings()
        {
            var buildings = unitOfWork.GetRepository<Building>().Include(x => x.rooms);

            return Json(mapper, buildings, typeof(List<BuildingDto>));
        }

        [HttpPost]
        [Route("/AddBuilding")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult AddBuilding(BuildingDto model)
        {
            var building = model.MapTo<Building>(mapper);

            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<Building>().InsertAsync(building);
                unitOfWork.Save();
                return new ObjectResult("Model added successfully!");
            }
            return new ObjectResult("Model added unsuccessfully!");
        }

        [HttpPut]
        [Route("/UpdateBuilding/{id}")]
        [ProducesResponseType(typeof(string), 200)]
        public IActionResult UpdateBuilding(int id, BuildingDto model)
        {
            var building = model.MapTo<Building>(mapper);
            var newBuilding = unitOfWork.GetRepository<Building>().GetById(id);
            newBuilding.Name = building.Name;
            newBuilding.Post = building.Post;
            newBuilding.Number_of_floors = building.Number_of_floors;

            if (ModelState.IsValid && id == model.Id)
            {
                unitOfWork.GetRepository<Building>().Update(newBuilding);
                unitOfWork.GetRepository<Building>().Save();
                return new ObjectResult("Model updated successfully!");
            }
            return new ObjectResult("Model updated unsuccessfully!");
        }

        [HttpDelete]
        [Route("/DeleteBuilding/{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult DeleteBuilding(int id)
        {
            unitOfWork.GetRepository<Building>().DeleteById(id);
            unitOfWork.GetRepository<Building>().Save();

            return new ObjectResult("Model deleted successfully!");
        }
    }
}