using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OrderMatchingEngine
{
    public class OrderBook
    {
        public IList<IOrder> Orders { get; private set; } = new List<IOrder>();
        public string ProcessOrder(OperationType operationType, IOrder order)
        {
            var output = new StringBuilder();
            switch (operationType)
            {
                case OperationType.BUY:
                case OperationType.SELL:
                    Orders.Add(order);
                    break;
                case OperationType.CANCEL:
                    Orders.Remove(order);
                    break;
                case OperationType.MODIFY:
                    break;
                case OperationType.PRINT:
                    var groupedOrders = Orders.GroupBy(p => new { Type = p.OrderType, Price = p.Price, Quantity = p.Quantity });
                    var sellGroup = groupedOrders.Where(p => p.Key.Type == OperationType.SELL).GroupBy(p => p.Key.Price).Select(g => new { Price = g.Key, Quantity = g.Sum(p => p.Key.Quantity) });
                    if (sellGroup.Any())
                    {
                        output.AppendLine("SELL:");
                        foreach (var item in sellGroup.OrderByDescending(p => p.Quantity))
                        {
                            output.AppendLine(string.Format("{0} {1}", item.Price, item.Quantity));
                        }
                    }
                    var buyGroup = groupedOrders.Where(p => p.Key.Type == OperationType.BUY).GroupBy(p => p.Key.Price).Select(g => new { Price = g.Key, Quantity = g.Sum(p => p.Key.Quantity) });
                    if (buyGroup.Any())
                    {
                        output.AppendLine("BUY:");
                        foreach (var item in buyGroup.OrderByDescending(p => p.Quantity))
                        {
                            output.AppendLine(string.Format("{0} {1}", item.Price, item.Quantity));
                        }
                    }

                    break;
                default:
                    break;
            }

            return output.ToString();
        }
    }
}
