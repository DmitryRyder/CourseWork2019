using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectForCourseWork_ver_2._0.Controllers.Base
{
    public class BaseController : Controller
    {
        protected readonly Dictionary<string, string> RequestHeaders = new Dictionary<string, string>();

        /// <summary>
        /// Валидация Dto
        /// </summary>
        /// <param name="model">Объект Dto</param>
        /// <returns>Словарь ошибок или null</returns>
        public Dictionary<string, string> Validation(BaseDto model)
        {
            return model.Validate();
        }

        protected static new JsonResult Json(object data, JsonRequestBehavior behavior = JsonRequestBehavior.AllowGet)
        {
            return new JsonResult
            {
                Data = data,
                JsonRequestBehavior = behavior,
                MaxJsonLength = int.MaxValue
            };
        }
    }
}