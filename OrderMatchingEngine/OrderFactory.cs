using System;

namespace OrderMatchingEngine
{
    public static class OrderFactory
    {
        public static IOrder Build(string[] input)
        {
            OperationType orderType;
            var action = Enum.TryParse(input[0], out orderType);
            switch (orderType)
            {
                case OperationType.BUY:
                    return new BuyOrder { Type = (OrderType)Enum.Parse(typeof(OrderType), input[1]), Price = Convert.ToInt32(input[2]), Quantity = Convert.ToInt32(input[3]), OrderId = input[4] };
                case OperationType.SELL:
                    return new SellOrder { Type = (OrderType)Enum.Parse(typeof(OrderType), input[1]), Price = Convert.ToInt32(input[2]), Quantity = Convert.ToInt32(input[3]), OrderId = input[4] };
                case OperationType.CANCEL:
                    return new CancelOrder { OrderId = input[1] };
                case OperationType.MODIFY:
                    break;
                case OperationType.PRINT:
                    break;
                default:
                    break;
            }
            return null;
        }
    }
}
