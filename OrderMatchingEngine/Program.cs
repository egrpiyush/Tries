using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMatchingEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "BUY IOC 100 10 1\r\n" +
                "BUY IOC 100 10 1\r\n" +
                "BUY IOC 200 20 1\r\n" +
                "SELL GFD 100 10 1\r\n" +
                "SELL GFD 100 20 2\r\n" +
                "SELL GFD 200 10 3\r\n" +
                "PRINT";

            var orderBook = new OrderBook();
            string[] splittedInput = input.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in splittedInput)
            {
                var splittedOrder = item.Split(' ');
                var order = OrderFactory.Build(splittedOrder);
                var output = orderBook.ProcessOrder((OperationType)Enum.Parse(typeof(OperationType), splittedOrder[0]), order);
                if (!string.IsNullOrWhiteSpace(output))
                    Console.WriteLine(output);
            }

            Console.Read();
        }
    }
}
