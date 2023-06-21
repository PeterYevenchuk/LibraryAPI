using Newtonsoft.Json;

namespace DAL.Entities.EntitiesPublicationItem
{
    public class Tag
    {
        [JsonProperty("id")]
        public Guid ID { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
