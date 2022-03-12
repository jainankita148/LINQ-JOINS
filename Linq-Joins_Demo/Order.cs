using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Joins_Demo
{
    public class Order
    {
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? CustId { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public static List<Order> GetAllOrder()
        {
            return new List<Order>()
            {
                new Order { OrderId = 1, ProductId = 1 ,CustId=1,Quantity=5,Price=2500},
                new Order { OrderId = 2, ProductId = 2 ,CustId=2,Quantity=5,Price=500},
                new Order { OrderId = 3, ProductId = 2 ,CustId=3,Quantity=7,Price=700},
                new Order { OrderId = 4, ProductId = 4 ,CustId=4,Quantity=2,Price=24000}
            };
        }
    }
}
