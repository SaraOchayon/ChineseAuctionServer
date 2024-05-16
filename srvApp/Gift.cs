

namespace srvApp
{
    public class Gift
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Donor? Donor { get; set; }
        public int Price { get; set; }
        public string? img { get; set; }
        public List<User> Customers { get; set; } = new List<User>();
    }

}
