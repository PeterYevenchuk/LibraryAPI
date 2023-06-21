using Newtonsoft.Json;

namespace DAL.Entities.EntitiesPublicationItem
{
    public class EBook : PublicationItem
    {
        [JsonProperty("authors")]
        public virtual IEnumerable<Author> Authors { get; set; }
        [JsonProperty("imagePath")]
        public string ImagePath { get; set; }
        [JsonProperty("genre")]
        public Genre Genre { get; set; }
        [JsonProperty("format")]
        public Format Format { get; set; }
    }
}
