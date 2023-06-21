namespace DAL.Entities.EntitiesLibrary
{
    public class SeasonTicket
    {
        public Guid ID { get; set; }
        public TicketType TicketType { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set;}
        public DateTime ExpirationDate { get; set;}
    }
}
