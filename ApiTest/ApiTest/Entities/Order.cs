namespace ApiTest.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? Total { get; set; }
        public string? Status { get; set; }
        public string? ShippingAddress { get; set; }
    }
}
