using Newtonsoft.Json;

namespace DAL.Entities.EntitiesPublicationItem
{
    public class Author
    {
        [JsonProperty("id")]
        public Guid ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("surname")]
        public string Surname { get; set; }
        [JsonProperty("rate")]
        public byte Rate { get; set; }
    }
}
