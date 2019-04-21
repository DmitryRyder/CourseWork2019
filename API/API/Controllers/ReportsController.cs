using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Base;
using API.Core.DAL;
using AutoMapper;
using Common.DTO;
using Common.Filters;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер для отчетов согласно заданию
    /// </summary>
    //[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : BaseController
    {
        UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ReportsController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Метод возвращающий объем воды для всех органов управления
        /// </summary>
        [HttpGet]
        [Route("/GetWaterVolumeForManagementBodies")]
        [ProducesResponseType(typeof(List<WaterVolumeDto>), 200)]
        public async Task<IActionResult> GetWaterVolumeForManagementBodies()
        {
            var waterVolums = await unitOfWork.GetRepository<ManagementBody>().Query().Select(p => new WaterVolumeDto {
                                                                                 ManagementBodyName = p.Name,
                                                                                 WaterVolume = p.Organizations.Select(t => t.ThermalNetworks.Select(r => r.PipelineSections.Select(u => (u.SteelPipe.Diameter - u.SteelPipe.Thickness) * u.Length).Sum()).Sum()).Sum()
            }).ToListAsync();

            return Json(mapper, waterVolums, typeof(List<WaterVolumeDto>));
        }

        /// <summary>
        /// Метод возвращающий объем воды для всех организаций
        /// </summary>
        [HttpGet]
        [Route("/GetWaterVolumeForOrganizations")]
        [ProducesResponseType(typeof(List<WaterVolumeDto>), 200)]
        public async Task<IActionResult> GetWaterVolumeForOrganizations()
        {
            var waterVolums = await unitOfWork.GetRepository<OrganizationM>().Query().Select(p => new WaterVolumeDto {
                                                                                 OrganizationName = p.Name,
                                                                                 WaterVolume = p.ThermalNetworks.Select(r => r.PipelineSections.Select(u => (u.SteelPipe.Diameter - u.SteelPipe.Thickness) * u.Length).Sum()).Sum()
                                                                                 }).ToListAsync();

            return Json(mapper, waterVolums, typeof(List<WaterVolumeDto>));
        }

        /// <summary>
        /// Метод возвращающий протяженность труб для выбранных организаций
        /// </summary>
        [HttpPost]
        [Route("/GetPipesLengthForOrganizations")]
        [ProducesResponseType(typeof(List<PipeLengthDto>), 200)]
        public IActionResult GetPipesLengthForOrganizations(OrganizationsFilterDto filter)
        {
            var result = new List<PipeLengthDto>();

            if (filter.SteelPipeId == null)
                return Json("хуй");

            foreach(var v in filter.OrganizationIds)
            {
                var organizationName = unitOfWork.GetRepository<OrganizationM>().GetById(v).Name;
                var pipe = unitOfWork.GetRepository<SteelPipe>().GetById(filter.SteelPipeId);

                var pipesLength = unitOfWork.GetRepository<PipelineSection>().Query().Where(t => v == t.ThermalNetwork.OrganizationId && t.SteelPipeId == filter.SteelPipeId)
                                                                           .Sum(p => p.Length);
                result.Add(new PipeLengthDto
                {
                    OrganizationName = organizationName,
                    Name = pipe.Name,
                    Diameter = pipe.Diameter,
                    Thickness = pipe.Thickness,
                    Volume = pipe.Volume,
                    Weight = pipe.Weight,
                    Length = pipesLength
                });
            }

            return Json(result);
        }

        /// <summary>
        /// Метод возвращающий данные о ремонте трубопроводов за указанный период
        /// </summary>
        [HttpPost]
        [Route("/GetRepairsForPeriod")]
        [ProducesResponseType(typeof(List<FetchThreeDto>), 200)]
        public async Task<IActionResult> GetRepairsForPeriod(PeriodFilter filter)
        {
            var repairs = await unitOfWork.GetRepository<PipelineSection>().Query().Where(r => r.LastRepair >= filter.DateStart && r.LastRepair <= filter.DateEnd)
                                                                             .Select(p => new FetchThreeDto
                                                                             {
                                                                                 LastRepair = p.LastRepair,
                                                                                 Number = p.NumberOfSection,
                                                                                 Length = p.Length,
                                                                                 TypeofPipe = p.SteelPipe.Name,
                                                                                 ThermalNetworkName = p.ThermalNetwork.Name,
                                                                                 OrganizationName = p.ThermalNetwork.Organization.Name
                                                                             }).ToListAsync();
            return Json(repairs);
        }
    }
}