using Newtonsoft.Json;

namespace contact
{
    public class Message
    {
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Email { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string? Phone { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Body { get; set; }
    }
}
