using API.Code;
using AutoMapper;
using Common.Code;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mime;

namespace API.Controllers.Base
{
    [ProducesResponseType(500)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ApiResponse<string>), 400)]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        /// <summary>
        /// Конструктор для удачного запроса
        /// </summary>
        protected JsonResult Json(object obj = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return base.Json(new JResult(obj, statusCode));
        }

        /// <summary>
        /// Конструктор для удачного запроса
        /// </summary>
        protected JsonResult Json(IMapper mapper,
                                  object sourceObject,
                                  Type dtoType,
                                  long dataCount = default,
                                  HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return base.Json(new JResult(mapper, sourceObject, dtoType, dataCount, statusCode));
        }

        /// <summary>
        /// Конструктор для некорректно отправленного пользовательсткого запроса или сообщения
        /// </summary>
        protected JsonResult Json(string msg, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return base.Json(new JResult(msg, statusCode));
        }
    }
}
