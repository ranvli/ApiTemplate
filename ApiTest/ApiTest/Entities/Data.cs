namespace ApiTest.Entities
{
    public class Data
    {
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        public List<User> Users { get; set; }

        public Data()
        {
            Orders = new List<Order>();
            Products = new List<Product>();
            Users = new List<User>();
        }
    }


}
