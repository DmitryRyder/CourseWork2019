using AutoMapper;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Automapper.Converters
{
    /// <inheritdoc />
    /// <summary>
    /// Конвертер для получения только айдишников из сущности для автомаппера
    /// </summary>
    public class ModelToIntConverter : ITypeConverter<BaseModel, int>
    {
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public int Convert(BaseModel source, int destination, ResolutionContext context)
        {
            return source?.Id ?? 0;
        }
    }
}
