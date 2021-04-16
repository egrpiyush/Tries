namespace OrderMatchingEngine
{
    public class ModifyOrder : Order
    {
        public string OrderId { get; set; }
        public OperationType Operation { get; set; }
        public int NewPrice { get; set; }
        public int NewQuantity { get; set; }
    }
}
