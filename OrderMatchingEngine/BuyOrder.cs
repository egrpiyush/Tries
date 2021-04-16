namespace OrderMatchingEngine
{
    public class BuyOrder : IOrder
    {
        public OrderType Type { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string OrderId { get; set; }
        public OperationType OrderType { get => OperationType.BUY; }
    }

    public class SellOrder : IOrder
    {
        public OrderType Type { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string OrderId { get; set; }
        public OperationType OrderType { get => OperationType.SELL; }
    }
}
