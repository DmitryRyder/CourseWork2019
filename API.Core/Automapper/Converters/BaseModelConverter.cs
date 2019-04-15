using AutoMapper;
using Common.Models;
using System;

namespace API.Core.Automapper.Converters
{
    /// <inheritdoc />
    /// <summary>
    /// Конвертер для получения только айдишников из сущности для автомаппера
    /// </summary>
    public class ModelToGuidConverter : ITypeConverter<BaseModel, Guid>
    {
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public Guid Convert(BaseModel source, Guid destination, ResolutionContext context)
        {
            return source.Id;
        }
    }
}
