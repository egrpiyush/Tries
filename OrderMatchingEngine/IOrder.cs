namespace OrderMatchingEngine
{
    public interface IOrder
    {
       OperationType OrderType { get; }
        OrderType Type { get; set; }
        int Price { get; set; }
        int Quantity { get; set; }
        string OrderId { get; set; }
    }
}
