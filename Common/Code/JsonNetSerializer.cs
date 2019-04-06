using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization;

namespace Common.Code
{
    public class JsonNetSerializer : IRestSerializer
    {
        private readonly JsonSerializerSettings _settings;

        public JsonNetSerializer(JsonSerializerSettings settings)
        {
            _settings = settings;
        }

        public JsonNetSerializer()
        {
            _settings = Settings.JsonSetings;
        }

        public string Serialize(object obj) => JsonConvert.SerializeObject(obj, _settings);

        public T Deserialize<T>(IRestResponse response) => JsonConvert.DeserializeObject<T>(response.Content, _settings);

        public string Serialize(Parameter parameter) => JsonConvert.SerializeObject(parameter.Value, _settings);

        public string[] SupportedContentTypes { get; } = { "application/json", "text/json", "text/x-json", "text/javascript", "*+json" };

        public string ContentType { get; set; } = "application/json";

        public DataFormat DataFormat { get; } = DataFormat.Json;
    }
}
