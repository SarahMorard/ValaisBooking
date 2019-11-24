using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using DAL;
using BLL;
using DTO;

namespace ValaisRestaurants
{
    class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
           .Build();
        static void Main(string[] args)
        {
            var order_dishesManager = new Order_DishesManager(Configuration);

            var order_dishes = order_dishesManager.GetOrder_Dishes();

            Console.WriteLine(" -- NEW ORDER_DISHES -- ");
            var newOrder_dishes = order_dishesManager.AddOrder_Dishes(new Order_Dishes { idOrder_Dishes = 2, quantity = 2, customers_id = 3, dishes_id = 2, orders_id=7 }); ;
            Console.WriteLine($"ID: {newOrder_dishes.idOrder_Dishes} Quantity: {newOrder_dishes.quantity}");
            order_dishes = order_dishesManager.GetOrder_Dishes();
            foreach (var order_dish in order_dishes)
            {
                Console.WriteLine(order_dish.ToString());
            }

        }
    }
}
