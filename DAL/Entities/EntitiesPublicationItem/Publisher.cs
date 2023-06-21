using Newtonsoft.Json;

namespace DAL.Entities.EntitiesPublicationItem
{
    public class Publisher
    {
        [JsonProperty("id")]
        public Guid ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
