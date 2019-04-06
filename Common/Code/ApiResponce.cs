using System.Net;

namespace Common.Code
{
    public class ApiResponse<T>
    {
        /// <summary>
        /// Код ответа
        /// </summary>
        public HttpStatusCode Code { get; set; }

        /// <summary>
        /// Был ли запрос успешен (200)
        /// </summary>
        public bool Success => Code == HttpStatusCode.OK;

        /// <summary>
        /// Сообщение (в случае ошибки)
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Данные
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Количество записей
        /// </summary>
        public int DataCount { get; set; }
    }
}
