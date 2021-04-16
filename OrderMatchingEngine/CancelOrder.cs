namespace OrderMatchingEngine
{
    public class CancelOrder : IOrder
    {
        public string OrderId { get; set; }
        public OperationType OrderType { get => OperationType.CANCEL; }
        public OrderType Type { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Price { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Quantity { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
