using AutoMapper;
using API.Core.Automapper.Converters;
using Common.Models;

namespace API.Core.Automapper
{
    public static class MapperConfig
    {
        public static void Config(IMapperConfigurationExpression m)
        {
            m.CreateMap<bool, string>()
             .ConvertUsing(b => b ? "Да" : "Нет");
            m.CreateMap<BaseModel, int>()
             .ConvertUsing<ModelToIntConverter>();
            m.CreateMissingTypeMaps = true;
            m.ValidateInlineMaps = false;
        }
    }
}
