using System;
using System.Collections.Generic;
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
    public class ElectricsByOrganizationController : BaseController
    {
        UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ElectricsByOrganizationController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("/GetAllElectricsByOrganization")]
        [ProducesResponseType(typeof(List<ElectricsByOrganizationDto>), 200)]
        public JsonResult GetAllElectricsByOrganization()
        {
            var electrics = unitOfWork.GetRepository<ElectricsByOrganization>().Include(x => x.Electric, x => x.Organization);

            var electric = electrics.MapTo<List<ElectricsByOrganizationDto>>(mapper);

            return Json(mapper, electric, typeof(List<ElectricsByOrganizationDto>));
        }

        [HttpPost]
        [Route("/AddElectricByOrganization")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult AddElectricByOrganization(ElectricsByOrganizationDto model)
        {
            var electric = model.MapTo<ElectricsByOrganization>(mapper);

            //roomRental.Room = null;
            //roomRental.Organization = null;

            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<ElectricsByOrganization>().InsertAsync(electric);
                unitOfWork.GetRepository<ElectricsByOrganization>().Save();
                return new ObjectResult("Model added successfully!");
            }
            return new ObjectResult("Model added unsuccessfully!");
        }

        [HttpDelete]
        [Route("/DeleteElectricByOrganization/{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult DeleteElectricByOrganization(Guid id)
        {
            unitOfWork.GetRepository<ElectricsByOrganization>().DeleteById(id);
            unitOfWork.GetRepository<ElectricsByOrganization>().Save();

            return new ObjectResult("Model deleted successfully!");
        }
    }
}