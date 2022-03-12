using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Joins_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerList = Customer.GetAllCustomer();
            Console.WriteLine("--------------- Customer Detail ------------------");
            var customertable = new ConsoleTable("CustomerId", "CustomerId", "CustomerId");

            foreach (var data in customerList)
            {
                customertable.AddRow(data.CustId, data.CustName, data.Contact);

            }
            customertable.Write(Format.Alternative);


            var productList = Product.GetAllProcuct();
            Console.WriteLine("\n--------------- Product Detail ------------------");
            var productTable = new ConsoleTable("ProductId", "ProductName");
            foreach (var data in productList)
            {
                productTable.AddRow(data.ProductId, data.ProductName);
            }
            productTable.Write(Format.Alternative);


            var orderList = Order.GetAllOrder();
            Console.WriteLine("\n--------------- Order Detail ------------------");
            var orderTable = new ConsoleTable("OrderId", "ProductId", "CustomerId", "Quantity", "Price");
            foreach (var data in orderList)
            {
                orderTable.AddRow(data.OrderId, data.ProductId, data.CustId, data.Quantity, data.Price);
            }
            orderTable.Write(Format.Alternative);

            Console.WriteLine("\n--------------- Menu ------------------");
            Console.WriteLine("Enter 1 for Inner Join ");
            Console.WriteLine("Enter 2 for Left Join ");
            Console.WriteLine("Enter 3 for Full Join");
            Console.WriteLine("Enter 4 for Cross Join");
            Console.WriteLine("Enter 5 for Inner Join with multiple datasource");

            int c = Convert.ToInt16(Console.ReadLine());

            switch (c)
            {
                case 1:
                    var innerJoin = (from prod in Product.GetAllProcuct()
                                     join order in Order.GetAllOrder()
                                     on prod.ProductId equals order.ProductId
                                     select new
                                     {
                                         ProductName = prod.ProductName,
                                         Price = prod.Price,
                                         OrderId = order.OrderId,
                                         Quantity = order.Quantity,
                                         TotalPrice = order.Price
                                     }).ToList();

                    Console.WriteLine("\n--------------- Inner Join Result  ------------------");
                    var innerJoinTable = new ConsoleTable("ProductName", "Price", "OrderId", "Quantity", "TotalPrice");
                    foreach (var employee in innerJoin)
                    {
                        innerJoinTable.AddRow(employee.ProductName, employee.Price, employee.OrderId, employee.Quantity, employee.TotalPrice);
                    }
                    innerJoinTable.Write(Format.Alternative);
                    break;
                case 2:
                    var leftJoin = (from prod in Product.GetAllProcuct()
                                    join od in Order.GetAllOrder() on prod.ProductId equals od.ProductId into t
                                    from rt in t.DefaultIfEmpty()
                                    select new
                                    {
                                        ProductName = prod.ProductName,
                                        Price = prod.Price,
                                        OrderId = rt?.OrderId,
                                        Quantity = rt?.Quantity,
                                        TotalPrice = rt?.Price
                                    }).ToList();

                    Console.WriteLine("\n--------------- Left Join Result  ------------------");
                    var leftJoinTable = new ConsoleTable("ProductName", "Price", "OrderId", "Quantity", "TotalPrice");
                    foreach (var employee in leftJoin)
                    {
                        leftJoinTable.AddRow(employee.ProductName, employee.Price, employee.OrderId, employee.Quantity, employee.TotalPrice);
                    }
                    leftJoinTable.Write(Format.Alternative);
                    break;
                case 3:
                    var result1 = from prod in Product.GetAllProcuct()
                                  join od in Order.GetAllOrder() on prod.ProductId equals od.ProductId into ordertable
                                  from rt in ordertable.DefaultIfEmpty()
                                  join cust in Customer.GetAllCustomer() on rt?.CustId equals cust.CustId into custtable
                                  from ct in custtable.DefaultIfEmpty()
                                  select new
                                  {
                                      CustomerName=ct?.CustName,
                                      ProductName = prod.ProductName,
                                      Price = prod.Price,
                                      OrderId = rt?.OrderId,
                                      Quantity = rt?.Quantity,
                                      TotalPrice = rt?.Price
                                  };

                    var result2 = from cust in Customer.GetAllCustomer()
                                  join od in Order.GetAllOrder() on cust.CustId equals od.CustId into ordertable
                                  from rt in ordertable.DefaultIfEmpty()
                                  join prod in Product.GetAllProcuct() on rt?.ProductId equals prod.ProductId into prodTable
                                  from pr in prodTable.DefaultIfEmpty()
                                  select new
                                  {
                                      CustomerName = cust.CustName,
                                      ProductName = pr?.ProductName,
                                      Price = pr?.Price,
                                      OrderId = rt?.OrderId,
                                      Quantity = rt?.Quantity,
                                      TotalPrice = rt?.Price
                                  };

                    result1 = result1.Union(result2);

                    Console.WriteLine("\n--------------- Full Join Result  ------------------");
                    var fullJoinTable = new ConsoleTable("Customer Name","ProductName", "Price", "OrderId", "Quantity", "TotalPrice");
                    foreach (var employee in result1)
                    {
                        fullJoinTable.AddRow(employee.CustomerName,employee.ProductName, employee.Price, employee.OrderId, employee.Quantity, employee.TotalPrice);
                    }
                    fullJoinTable.Write(Format.Alternative);
                    break;
                case 4:
                    var crossJoin = (from prod in Product.GetAllProcuct()
                                     from order in Order.GetAllOrder()
                                     select new
                                     {

                                         ProductName = prod.ProductName,
                                         Price = prod?.Price,
                                         OrderId = order.OrderId,
                                         Quantity = order.Quantity,
                                         TotalPrice = order.Price
                                     }).ToList();

                    Console.WriteLine("\n--------------- Cross Join Result  ------------------");
                    var crossJoinTable = new ConsoleTable("ProductName", "Price", "OrderId", "Quantity", "TotalPrice");
                    foreach (var employee in crossJoin)
                    {
                        crossJoinTable.AddRow(employee.ProductName, employee.Price, employee.OrderId, employee.Quantity, employee.TotalPrice);
                    }
                    crossJoinTable.Write(Format.Alternative);
                    break;
                case 5:
                    var multipleDataJoin = (from cust in Customer.GetAllCustomer()
                                            join order in Order.GetAllOrder() on cust.CustId equals order.CustId
                                            join prod in Product.GetAllProcuct() on order.ProductId equals prod.ProductId
                                            select new
                                            {
                                                CustomerName = cust.CustName,
                                                ProductName = prod.ProductName,
                                                Price = prod?.Price,
                                                OrderId = order.OrderId,
                                                Quantity = order.Quantity,
                                                TotalPrice = order.Price
                                            }).ToList();

                    Console.WriteLine("\n--------------- Inner Join with multiple Data Source  ------------------");
                    var multiTable = new ConsoleTable("Customer Name", "Product Name", "Price", "Quantity", "Total Price");
                    foreach (var employee in multipleDataJoin)
                    {
                        multiTable.AddRow(employee.CustomerName, employee.ProductName, employee.Price, employee.Quantity, employee.TotalPrice);
                    }
                    multiTable.Write(Format.Alternative);
                    break;
                default:
                    Console.WriteLine("Choose any one option ");
                    break;
            }
            Console.ReadLine();
        }
    }
}

