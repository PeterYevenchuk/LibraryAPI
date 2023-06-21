namespace DAL.Entities.EntitiesLibrary
{
    public class Admin
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
