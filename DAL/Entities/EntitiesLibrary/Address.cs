namespace DAL.Entities.EntitiesLibrary
{
    public class Address
    {
        public Guid ID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Flat { get; set; }
        public string Postcode { get; set; }
    }
}
