namespace Leetcode.Linq
{
    internal class LinqTraining2
    {
        public static List<Order>? Orders { get; set; }
        public static void Execute()
        {
            Fill();

            // Самый дорогой покупатель
            var richConsumer = Orders?.GroupBy(x => x.CustomerName)
                                      .Select(order => new 
                                      {
                                          Name = order.Key, 
                                          Price = order.Sum(p => 
                                            p.Items.Sum(q => q.Price * q.Quantity))
                                      }).First();
            if (richConsumer is null)
                return;
            Console.WriteLine(richConsumer.Name + " " + richConsumer.Price + "\r\n");


            // Найти самые популярные товары
            var popularProducts = Orders?.SelectMany(order => order.Items)
                                         .GroupBy(x => x.ProductName)
                                         .Select(p => new
                                         {
                                             Name = p.Key,
                                             Count = p.Sum( x => x.Quantity),
                                         })
                                         .OrderByDescending( p => p.Count)
                                         .Take(3);

            Console.WriteLine("Самые популярные товары:");
            foreach ( var popularProduct in popularProducts)
            {
                Console.WriteLine(popularProduct.Name + " " + popularProduct.Count);
            }


            // Найти самый дорогой заказ.
            var mostExpensiveOrder = Orders?.MaxBy(x => x.Items.Sum( p => p.Price * p.Quantity));
            var mostExpensiveOrder2 = Orders?.Select( x => new { Id = x.Id, Price = x.Items.Sum(p => p.Price * p.Quantity) }).MaxBy(x => x.Price);
            Console.WriteLine(mostExpensiveOrder2?.Id + " " + mostExpensiveOrder2?.Price + "\r\n");

            // Найти клиентов, которые сделали более 1 заказа
            var clients = Orders?.GroupBy(x => x.CustomerName)
                                .Select(g => new
                                {
                                    Name = g.Key,
                                    Count = g.Count()
                                }).Where(x => x.Count > 1).ToList();

            foreach (var item in clients)
            {
                Console.WriteLine(item.Name + " " + item.Count);
            }


            // Найти месяц с наибольшим количеством заказов 
            var month = Orders.GroupBy(x => new { x.OrderDate.Year, x.OrderDate.Month })
                              .Select(order => new
                              {
                                  Month = order.Key,
                                  Count = order.Count()
                              }).MaxBy(c => c.Count);

            Console.WriteLine("\r\n Месяц: " + month?.Month + " Количество заказов: " + month?.Count);


            // Найти клиентов, которые купили хотя бы 1 товар дороже 1000$ 
            var clientsAtLeast = Orders.SelectMany(x => x.Items).Where(x => x.Price > 1000).ToList();
            foreach (var item in clientsAtLeast)
            {
                Console.WriteLine(item);
            }


            // Найти процент заказов, содержащих более 3 товаров
            var totalCount = Orders.Count();
            var percentageOrders = Orders.Count(x => x.Items.Count() > 3);
            double percentage = (double)percentageOrders / totalCount * 100;
            Console.WriteLine(percentage + "\r\n");

            // Найти все товары, которые не покупал клиент Alice
            var allProducts = Orders.SelectMany(x => x.Items)
                                    .Select(x => x.ProductName)
                                    .Distinct();
            var aliceProducts = Orders.Where(x => x.CustomerName == "Alice")
                                      .SelectMany(x => x.Items)
                                      .Select(x => x.ProductName)
                                      .Distinct();

            var productWithoutAliceTest = allProducts.Except(aliceProducts);

            foreach (var item in aliceProducts)
            {
                Console.WriteLine(item);
            }

            // Найти сумму всех покупок за последнюю неделю( 7 дней )
            var currentDate = DateTime.Now.Date;
            var latestOrders = Orders.Where(x => (currentDate - x.OrderDate).Days < 7);
            foreach(var order in latestOrders)
            {
                Console.WriteLine(order);
            }


            // Найти среднюю сумму заказа за месяц
            var averageSumPerMonth = Orders.GroupBy(x => new { x.OrderDate.Month, x.OrderDate.Year })
                                           .Select(x => new
                                           {
                                               Month = x.Key,
                                               Price = x.Sum(l => l.Items.Sum(d => d.Price * d.Quantity)),
                                               Average = x.Average(p => p.Items.Sum(q => q.Price * q.Quantity))
                                           });

            Console.WriteLine();
            foreach (var item in averageSumPerMonth)
            {
                Console.WriteLine($"Месяц: {item.Month}, Общая сумма: {item.Price}, " +
                    $"Средняя сумма заказа: {item.Average}");
            }
        }

        public static void Fill()
        {
            Orders = new List<Order>
            {
                new Order
                {
                    Id = 1, CustomerName = "Alice", OrderDate = new DateTime(2024, 1, 10),
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductName = "Laptop", Quantity = 1, Price = 1200 },
                        new OrderItem { ProductName = "Mouse", Quantity = 2, Price = 25 }
                    }
                },
                new Order
                {
                    Id = 2, CustomerName = "Bob", OrderDate = new DateTime(2024, 1, 15),
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductName = "Keyboard", Quantity = 1, Price = 100 },
                        new OrderItem { ProductName = "Monitor", Quantity = 1, Price = 300 }
                    }
                },
                new Order
                {
                    Id = 3, CustomerName = "Alice", OrderDate = new DateTime(2024, 2, 5),
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductName = "Phone", Quantity = 1, Price = 800 },
                        new OrderItem { ProductName = "Headphones", Quantity = 1, Price = 150 }
                    }
                },
                new Order
                {
                    Id = 4, CustomerName = "Charlie", OrderDate = new DateTime(2024, 2, 20),
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductName = "Tablet", Quantity = 1, Price = 500 },
                        new OrderItem { ProductName = "Charger", Quantity = 2, Price = 20 }
                    }
                },
                new Order
                {
                    Id = 5, CustomerName = "Bob", OrderDate = new DateTime(2024, 3, 1),
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductName = "Laptop", Quantity = 1, Price = 1500 },
                        new OrderItem { ProductName = "Mouse", Quantity = 1, Price = 30 },
                        new OrderItem { ProductName = "Charger", Quantity = 1, Price = 20 },
                        new OrderItem { ProductName = "Android", Quantity = 1, Price = 2000 },
                    }
                },
                new Order
                {
                    Id = 6, CustomerName = "Place", OrderDate = new DateTime(2025, 2, 25),
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductName = "Laptop", Quantity = 1, Price = 1500 },
                        new OrderItem { ProductName = "Mouse", Quantity = 1, Price = 30 },
                        new OrderItem { ProductName = "Charger", Quantity = 1, Price = 20 }
                    }
                }
            };
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } // Имя клиента
        public DateTime OrderDate { get; set; } // Дата заказа
        public List<OrderItem> Items { get; set; } // Список товаров в заказе
    }

    public class OrderItem
    {
        public string ProductName { get; set; } // Название товара
        public int Quantity { get; set; } // Количество
        public decimal Price { get; set; } // Цена за штуку
    }
}
