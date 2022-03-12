using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Joins_Demo
{
   public class Product
    {
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int? Price { get; set; }
        public static List<Product> GetAllProcuct()
        {
            return new List<Product>()
            {
                new Product { ProductId = 1, ProductName = "KeyBoard", Price = 500 },
                new Product { ProductId = 2, ProductName = "Mouse", Price = 100 },
                new Product { ProductId = 3, ProductName = "Monitor", Price = 7000 },
                new Product { ProductId = 4, ProductName = "CPU", Price =  12000},
                new Product { ProductId = 5, ProductName = "Printer", Price =  9000}
            };
        }
    }
}
    