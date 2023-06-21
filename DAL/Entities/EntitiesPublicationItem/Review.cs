using Newtonsoft.Json;

namespace DAL.Entities.EntitiesPublicationItem
{
    public class Review
    {
        [JsonProperty("id")]
        public Guid ID { get; set; }
        [JsonProperty("visitorID")]
        public Guid VisitorID { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("rating")]
        public byte Rating { get; set; }
    }
}
