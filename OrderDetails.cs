namespace HOY_API_2
{
    public class OrderDetails
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public int price { get; set; }
        public string sku { get; set; }
        public int quantity { get; set; }
        public string orderStatus { get; set; }
    }
}
