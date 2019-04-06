using System;
using System.Collections;
using System.Net;
using AutoMapper;
using Newtonsoft.Json;

namespace API.Code
{
    /// <summary>
    /// Стандартный ответ API
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class JResult
    {
        /// <summary>
        /// Http код ответа
        /// </summary>
        [JsonProperty("Code")]
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// Сообщение
        /// </summary>
        [JsonProperty(PropertyName = "Message")]
        public string Message { get; set; }

        /// <summary>
        /// Данные
        /// </summary>
        [JsonProperty(PropertyName = "Data")]
        public object Data { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        [JsonProperty(PropertyName = "DataCount")]
        public long DataCount { get; set; }


        /// <inheritdoc />
        /// <summary>
        /// Конструктор для удачного запроса
        /// </summary>
        public JResult(IMapper mapper, object sourceObject, Type dtoType, long dataCount = default, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            HttpStatusCode = statusCode;

            if (sourceObject is null || dtoType is null)
                return;
            var data = sourceObject.GetType() == dtoType ? sourceObject : mapper.Map(sourceObject, sourceObject.GetType(), dtoType);

            Data = data;
            DataCount = dataCount is 0 ? sourceObject is IList list ? list.Count : default : dataCount;
        }

        /// <inheritdoc />
        /// <summary>
        /// Консутрктор для некорректно отправленного пользовательсткого запроса или сообщения
        /// </summary>
        public JResult(string msg, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            HttpStatusCode = statusCode;

            if (HttpStatusCode == HttpStatusCode.OK)
                Data = msg;
            else
                Message = msg;
        }

        /// <inheritdoc />
        /// <summary>
        /// Консутрктор для возврата http-ответа без тела.
        /// Подходит, например, в случае удачного добавления или удаления сущности из базы.
        /// </summary>
        public JResult(object obj = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            HttpStatusCode = statusCode;
            Data = obj;
        }

        /// <inheritdoc />
        /// <summary>
        /// Консутрктор для запроса, вызвавшего внутреннюю ошибку в API
        /// </summary>
        public JResult(Exception exception, string message = null, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            HttpStatusCode = statusCode;
            Message = message;
            Data = JsonConvert.SerializeObject(exception);
        }
    }
}
