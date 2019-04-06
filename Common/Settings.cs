using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Common
{
    public static class Settings
    {
        public static JsonSerializerSettings JsonSetings =>
            new JsonSerializerSettings
            {
                DateFormatString = Constants.DateTimeFullFormat,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                NullValueHandling = NullValueHandling.Ignore,
                Culture = CultureInfo.CurrentCulture,
                TypeNameHandling = TypeNameHandling.Auto,
                ContractResolver = new DefaultContractResolver(),
                Formatting = Formatting.Indented
            };
    }
}
