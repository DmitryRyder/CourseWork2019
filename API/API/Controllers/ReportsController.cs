﻿using System.Collections.Generic;
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
    [Produces("application/json")]
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
        public async Task<JsonResult> GetWaterVolumeForManagementBodies()
        {
            var waterVolums = await unitOfWork.GetRepository<ThermalNetwork>().Query().Select(p => new WaterVolumeDto {
                                                                                 ManagementBodyName = p.Organization.ManagementBody.Name,
                                                                                 OrganizationName = p.Organization.Name,
                                                                                 ThermalNetworkName = p.Name,
                                                                                 WaterVolume = p.PipelineSections.Select(r=>r.SteelPipe.Volume).Sum() *
                                                                                 p.PipelineSections.Select(r => r.SteelPipe).Count()
                                                                                 }).ToListAsync();

            return Json(mapper, waterVolums, typeof(List<WaterVolumeDto>));
        }

        /// <summary>
        /// Метод возвращающий объем воды для всех организаций
        /// </summary>
        [HttpGet]
        [Route("/GetWaterVolumeForOrganizations")]
        [ProducesResponseType(typeof(List<WaterVolumeDto>), 200)]
        public async Task<JsonResult> GetWaterVolumeForOrganizations()
        {
            var waterVolums = await unitOfWork.GetRepository<ThermalNetwork>().Query().Select(p => new WaterVolumeDto {
                                                                                 OrganizationName = p.Organization.Name,
                                                                                 ThermalNetworkName = p.Name,
                                                                                 WaterVolume = p.PipelineSections.Select(r=>r.SteelPipe.Volume).Sum() *
                                                                                 p.PipelineSections.Select(r => r.SteelPipe).Count()
                                                                                 }).ToListAsync();

            return Json(mapper, waterVolums, typeof(List<WaterVolumeDto>));
        }

        /// <summary>
        /// Метод возвращающий протяженность труб для выбранных организаций
        /// </summary>
        [HttpGet]
        [Route("/GetPipesLengthForOrganizations")]
        [ProducesResponseType(typeof(List<PipeLengthDto>), 200)]
        public async Task<JsonResult> GetPipesLengthForOrganizations(OrganizationsFilterDto filter)
        {
            var pipesLength = await unitOfWork.GetRepository<PipelineSection>().Query().Where(t => filter.Organizations.Contains(t.ThermalNetwork.OrganizationId))
                                                                                     .Select(p => new PipeLengthDto
                                                                                     {
                                                                                         OrganizationName = p.ThermalNetwork.Organization.Name,
                                                                                         Name = p.SteelPipe.Name,
                                                                                         Diameter = p.SteelPipe.Diameter,
                                                                                         Thickness = p.SteelPipe.Thickness,
                                                                                         Volume = p.SteelPipe.Volume,
                                                                                         Weight = p.SteelPipe.Weight,
                                                                                         Length = p.Length
                                                                                     }).ToListAsync();

            return Json(mapper, pipesLength, typeof(List<PipeLengthDto>));
        }

        /// <summary>
        /// Метод возвращающий данные о ремонте трубопроводов за указанный период
        /// </summary>
        [HttpGet]
        [Route("/GetRepairsDataForPeriod")]
        [ProducesResponseType(typeof(List<PipelineSectionDto>), 200)]
        public async Task<JsonResult> GetPipesLengthForOrganizations(PeriodFilter filter)
        {
            var repairs = await unitOfWork.GetRepository<PipelineSection>().Query().Where(r => r.LastRepair >= filter.DateStart && r.LastRepair <= filter.DateEnd)
                                                                             .Select(p => new PipelineSectionDto
                                                                             {
                                                                                 NumberOfSection = p.NumberOfSection,
                                                                                 Length = p.Length,
                                                                                 LastRepair = p.LastRepair,
                                                                                 SteelPipeName = p.SteelPipe.Name
                                                                             }).ToListAsync();

            return Json(mapper, repairs, typeof(List<PipelineSectionDto>));
        }
    }
}