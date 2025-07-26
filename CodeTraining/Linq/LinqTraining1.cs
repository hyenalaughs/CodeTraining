namespace Leetcode.Linq
{
    internal class LinqTraining1
    {
        public void Execute()
        {
            List<Order> orders = new List<Order>
            {
                new Order { Id = 1, CustomerName = "Alice", OrderDate = new DateTime(2024, 2, 1),
                            Items = new List<OrderItem> { new OrderItem
                            { ProductName = "Laptop", Quantity = 1, Price = 1200 },
                              new OrderItem { ProductName = "Mouse", Quantity = 2, Price = 25 } }
                },
                new Order { Id = 2, CustomerName = "Bob", OrderDate = new DateTime(2024, 2, 3),
                            Items = new List<OrderItem> { new OrderItem
                            { ProductName = "Keyboard", Quantity = 1, Price = 75 },
                              new OrderItem { ProductName = "Monitor", Quantity = 1, Price = 300 },
                              new OrderItem { ProductName = "Mouse", Quantity = 1, Price = 32 }
                            }
                },
                new Order { Id = 3, CustomerName = "Alice", OrderDate = new DateTime(2024, 2, 5),
                            Items = new List<OrderItem> { new OrderItem
                            { ProductName = "Laptop", Quantity = 1, Price = 1150 },
                              new OrderItem { ProductName = "Headphones", Quantity = 1, Price = 100 } }
                }
            };


            var summaryCost = orders.SelectMany(x => x.Items.Select(p => p.Price * p.Quantity)).Sum();
            Console.WriteLine("Общая сумма заказов: " + summaryCost);

            var maxPrice = orders.SelectMany(x => x.Items.Select(p => p.Price * p.Quantity)).Max();
            Console.WriteLine("Максимальная сумма: " + maxPrice + "\r\n");

            // Этот вариант работает, но я хочу короче.
            var orderWithMaxPrice = orders.OrderBy(x => x.Items.Select(p => p.Price).Sum()).First();
            var orderWithMaxPrice2 = orders.Select(x => x.Items.Select(p => p.Price).Sum()).Max();
            //Console.WriteLine(orderWithMaxPrice2.CustomerName);
            // Это проходит
            var orderWithMaxPrice3 = orders.MaxBy(x => x.Items.Select(p => p.Price).Sum());
            Console.WriteLine(orderWithMaxPrice3?.CustomerName + ". Заказ с самой большой суммой: "
                                + orderWithMaxPrice3.Id);

            var consumerWithMaxCount = orders.MaxBy(x => x.Items.Count());
            Console.WriteLine("Заказчик с самым большим количеством товаров в заказе: " +
                consumerWithMaxCount?.CustomerName + "\r\n");

            var consumerWithMaxOrders = orders.GroupBy(x => x.CustomerName).Select(g => new { Name = g.Key, Count = g.Count() }).ToList();
            foreach (var consumer in consumerWithMaxOrders)
            {
                Console.WriteLine(consumer.Name + " Количество: " + consumer.Count);
            }

            var consumerWithMaxOrder2 = orders.GroupBy(x => x.CustomerName)
                                              .Select(g => new { Name = g.Key, Count = g.Count() })
                                              .ToList().MaxBy(x => x.Count);
            Console.WriteLine("Заказчик с самым большим количество заказов: " +
                                 consumerWithMaxOrder2?.Name +
                                 $" (Количество заказов {consumerWithMaxOrder2?.Count})" + "\r\n");

            // Список всех уникальных товаров
            var uniqueProducts = orders.SelectMany(x => x.Items.Select(p => p.ProductName)).Distinct();
            Console.WriteLine("Список всех уникальных товаров: ");
            foreach (var product in uniqueProducts)
            {
                Console.WriteLine(product);
            }

            //var averageOrdersCount = orders.SelectMany(x => x.Items.Select(p => p.Price));
            //var averageOrdersPrice = orders.Average(x => x.Items.Select(p => p.Price * p.Quantity).Sum());
            var averageOrdersPrice = orders.Average(x => x.Items.Sum(p => p.Price * p.Quantity));
            Console.WriteLine(Math.Round(averageOrdersPrice, 2));

            var firstOrderMoreThan = orders.FirstOrDefault(x => x.Items.Sum(p => p.Price) > 1000);
            Console.WriteLine("Перый заказ, сумма которого превышает 1000$: " + firstOrderMoreThan?.Id);

            //Сгруппировать заказы по клиентам и посчитать общую сумму заказов каждого клиента
            var grouped = orders.GroupBy(x => x.CustomerName)
                                .Select(order => new
                                {
                                    Customer = order.Key,
                                    TotalPrice = order.Sum(p => p.Items.Sum(x => x.Price * x.Quantity))
                                });

            foreach (var order in grouped)
            {
                Console.WriteLine(order.Customer + " " + order.TotalPrice);
            }
        }

        class Order
        {
            public int Id { get; set; }
            public string CustomerName { get; set; }
            public List<OrderItem> Items { get; set; }
            public DateTime OrderDate { get; set; }
        }

        class OrderItem
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
        }
    }
}
