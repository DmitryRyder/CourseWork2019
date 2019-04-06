using AutoMapper;
using Common.DTO.BaseData;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Automapper.Profiles
{
    class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            CreateMap<Building, BuildingDto>();
        }
    }
}
