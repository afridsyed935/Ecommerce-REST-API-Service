namespace HOY_API_2
{
    public class Orders
    {
        public int id { get; set; }
        public int customerId { get; set; }
        public int amount { get; set; }
        public string shippingAddress { get; set; }
        public string orderEmail { get; set; }
        public string orderDate { get; set; }
        public string orderStatus { get; set; }
    }
}
