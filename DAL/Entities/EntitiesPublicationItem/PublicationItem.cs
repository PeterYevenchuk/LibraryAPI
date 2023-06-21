using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace DAL.Entities.EntitiesPublicationItem
{
    public class PublicationItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("id")]
        public Guid ID { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("datePublished")]
        public DateTime DatePublished { get; set; }
        [JsonProperty("language")]
        public Language Language { get; set; }
        [JsonProperty("publisher")]
        public virtual Publisher Publisher { get; set; }
        [JsonProperty("tags")]
        [MaybeNull]
        public virtual IEnumerable<Tag> Tags { get; set; }
        [JsonProperty("preview")]
        public string Preview { get; set; }
        [JsonProperty("reviews")]
        [MaybeNull]
        public virtual IEnumerable<Review> Reviews { get; set; }    
        [JsonProperty("rating")]
        public byte Rating { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("pages")]
        public uint Pages { get; set; }
    }
}
