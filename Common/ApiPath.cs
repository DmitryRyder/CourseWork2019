using Common.Extensions;
using System;

namespace Common
{
    public static class ApiPath
    {
        public const string GetAllFilteredRoute = "api/{controller}/filtered";
        public const string GetAllRoute = "api/{controller}/all";
        public const string GetForListRoute = "api/{controller}/forlist";
        public const string PostForListRoute = "api/{controller}/postForlist";
        public const string GetLoadDymanicRoute = "api/{controller}/loaddynamic";
        public const string CopyRoute = "api/{controller}/copy/{id}";
        public const string DeleteRoute = "api/{controller}/delete/{id}";
        public const string DeleteMultiRoute = "api/{controller}/deletemulti/{idsString}";
        public const string GetRoute = "api/{controller}/{id}";
        public const string PutRoute = "api/{controller}/";
        public const string GetVersionInfosRoute = "api/{controller}/versions/{id}";
        public const string GetVersionRoute = "api/{controller}/version";
        public const string GetAllVersionsRoute = "api/{controller}/allversions";

        public static string CtrlName(string controller) => controller?.Replace("Controller", string.Empty).Replace("Dto", string.Empty);
        public static string CtrlName(Type type) => CtrlName(type?.Name);
        public static string CtrlName<T>() => CtrlName(typeof(T));
        public static string GetAll<T>() => GetAllRoute.FormatNamed(CtrlName<T>());
        public static string GetFiltered<T>() => GetAllFilteredRoute.FormatNamed(CtrlName<T>());
        public static string Get<T>(object id = null) => GetRoute.FormatNamed(CtrlName<T>(), id?.ToString());
        public static string PostForList<T>() => PostForListRoute.FormatNamed(CtrlName<T>());
        public static string GetForList<T>() => GetForListRoute.FormatNamed(CtrlName<T>());
        public static string GetForList(string controller) => GetForListRoute.FormatNamed(controller);
        public static string Put<T>() => PutRoute.FormatNamed(CtrlName<T>());
        public static string Delete<T>(object id = null) => DeleteRoute.FormatNamed(CtrlName<T>(), id?.ToString());
        public static string Copy<T>(object id = null) => CopyRoute.FormatNamed(CtrlName<T>(), id?.ToString());
        public static string Dynamic<T>() => GetLoadDymanicRoute.FormatNamed(CtrlName<T>());
        public static string DeleteMulti<T>(string idsString) => DeleteMultiRoute.FormatNamed(CtrlName<T>(), idsString);
        public static string GetVersionInfos<T>(object id = null) => GetVersionInfosRoute.FormatNamed(CtrlName<T>(), id?.ToString());
        public static string GetVersion<T>() => GetVersionRoute.FormatNamed(CtrlName<T>());
        public static string GetAllVersions<T>() => GetAllVersionsRoute.FormatNamed(CtrlName<T>());
    }
}
