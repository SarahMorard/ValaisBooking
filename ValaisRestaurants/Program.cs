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

            /* CITIES */

            // List the cities 
            var CitiesManager = new CitiesManager(Configuration);

            var cities = CitiesManager.GetCities();

            foreach (var city in cities)
            {
                Console.WriteLine(city.ToString());
            }

            // Get one city
            var cities2 = CitiesManager.GetCityId(1);
            if (cities2 == null)
            {
                Console.WriteLine("Invalid ID");
            }
            else
            {
                Console.WriteLine(cities2.ToString());
            }


            // Add a new city
            Console.WriteLine(" -- NEW CITY -- ");
            var newCity = CitiesManager.AddCity(new Cities { idCities= 1, zip_code =3960, name = "Sierre"});
            Console.WriteLine($"ID: {newCity.idCities} Zip_Code: {newCity.zip_code} Name: {newCity.name}");
            cities = CitiesManager.GetCities();
            foreach (var city in cities)
            {
                Console.WriteLine(city.ToString());
            }

            //Update a city
            Console.WriteLine(" -- UPDATE CITY -- ");
            newCity.name= "Sion";
            CitiesManager.UpdateCity(newCity);
            cities = CitiesManager.GetCities();
            foreach (var city in cities)
            {
                Console.WriteLine($"ID: {city.idCities} Zip_Code: {city.zip_code} Name: {city.name}");
            }

            //Delete city
            Console.WriteLine(" -- DELETE CITY -- ");
            CitiesManager.DeleteCity(newCity.idCities);
            cities = CitiesManager.GetCities();

            foreach (var city in cities)
            {
                Console.WriteLine($"ID: {city.idCities} Zip_Code: {city.zip_code} Name: {city.name}");
            }

            /*==================================================================================================*/

            /*  CUSTOMER */


            // List the customer 
            var customersManager = new CustomersManager(Configuration);

            var customers = customersManager.GetCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }

            // Get one customer
            var customers2 = customersManager.GetCustomerId(1);
            if (customers2 == null)
            {
                Console.WriteLine("Invalid ID");
            }
            else
            {
                Console.WriteLine(customers2.ToString());
            }


            // Add a new customer
            Console.WriteLine(" -- NEW CUSTOMER -- ");
            var newCustomer = customersManager.AddCustomer(new Customers { idCustomers = 1,  firstName = "Morard", lastName="Sarah", address="Route du Bisse Neuf Ouest 2", phone_number = 0799177233, email = "sarah.morard@hes-so.ch"  });
            Console.WriteLine($"ID: {newCustomer.idCustomers} firstname = {newCustomer.firstName} lastname = {newCustomer.lastName} address = {newCustomer.address} phone number: {newCustomer.phone_number} email = {newCustomer.email}");
            customers = customersManager.GetCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }

            //Update a customer
            Console.WriteLine(" -- UPDATE CUSTOMER -- ");
            newCustomer.firstName = "Scott";
            customersManager.UpdateCustomer(newCustomer);
            customers = customersManager.GetCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {newCustomer.idCustomers} firstname = {newCustomer.firstName} lastname = {newCustomer.lastName} address = {newCustomer.address} phone number: {newCustomer.phone_number} email = {newCustomer.email}");
            }

            //Delete customer
            Console.WriteLine(" -- DELETE CUSTOMER -- ");
            customersManager.DeleteCustomer(newCustomer.idCustomers);
            customers = customersManager.GetCustomers();

            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {newCustomer.idCustomers} firstname = {newCustomer.firstName} lastname = {newCustomer.lastName} address = {newCustomer.address} phone number: {newCustomer.phone_number} email = {newCustomer.email}");
            }

            /*==================================================================================================*/

            /* DISHES */

            // List the dishes 
            var dishManager = new DishesManager(Configuration);

            var dishes = dishManager.GetDishes();
            foreach (var dish in dishes)
            {
                Console.WriteLine(dish.ToString());
            }

            // Get one dishes
            var dishes2 = dishManager.GetDishId(1);
            if (dishes2 == null)
            {
                Console.WriteLine("Invalid ID");
            }
            else
            {
                Console.WriteLine(dishes2.ToString());
            }


            // Add a new dishes
            Console.WriteLine(" -- NEW DISHES -- ");
            var newDish = dishManager.AddDish(new Dishes { idDishes = 1,  name = "VisualBurger", price = 11.50});
            Console.WriteLine($"ID: {newDish.idDishes} name: {newDish.name} price: {newDish.price}");
            dishes = dishManager.GetDishes();
            foreach (var dish in dishes)
            {
                Console.WriteLine(dish.ToString());
            }

            //Update a dishes
            Console.WriteLine(" -- UPDATE DISHES -- ");
            newDish.name = "VisualBigBurger";
            dishManager.UpdateDish(newDish);
            dishes = dishManager.GetDishes();
            foreach (var dish in dishes)
            {
                Console.WriteLine($"ID: {newDish.idDishes} name: {newDish.name} price: {newDish.price}");
            }

            //Delete dishes
            Console.WriteLine(" -- DELETE DISHES -- ");
            dishManager.DeleteDish(newDish.idDishes);
            dishes = dishManager.GetDishes();

            foreach (var dish in dishes)
            {
                Console.WriteLine($"ID: {newDish.idDishes} name: {newDish.name} price: {newDish.price}");
            }

            /*==================================================================================================*/

            /* LOGIN */

            // List the logins 
            var loginManager = new LoginManager(Configuration);

            var logins = loginManager.GetLogins();
            foreach (var login in logins)
            {
                Console.WriteLine(login.ToString());
            }

            // Get one login
            var logins2 = loginManager.GetLoginId(1);
            if (logins2 == null)
            {
                Console.WriteLine("Invalid ID");
            }
            else
            {
                Console.WriteLine(logins2.ToString());
            }


            // Add a new login
            Console.WriteLine(" -- NEW LOGIN -- ");
            var newLogin = loginManager.AddLogin(new Login { idLogin = 1, login =  "MissBurger", password = "IloveC#" });
            Console.WriteLine($"ID: {newLogin.idLogin} login:  {newLogin.login} password: {newLogin.password}");
            logins = loginManager.GetLogins();
            foreach (var login in logins)
            {
                Console.WriteLine(login.ToString());
            }

            //Update a login
            Console.WriteLine(" -- UPDATE LOGIN -- ");
            newLogin.password = "IPreferJava";
            loginManager.UpdateLogin(newLogin);
            logins = loginManager.GetLogins();
            foreach (var login in logins)
            {
                Console.WriteLine($"ID: {newLogin.idLogin} login: {newLogin.login} password: {newLogin.password}");
            }

            //Delete login
            Console.WriteLine(" -- DELETE LOGIN -- ");
            loginManager.DeleteLogin(newLogin.idLogin);
            logins = loginManager.GetLogins();

            foreach (var login in logins)
            {
                Console.WriteLine($"ID: {newLogin.idLogin} login: {newLogin.login} password: {newLogin.password}");
            }

            /*==================================================================================================*/

            /* ORDER_DISHES */

            // List the order_dishes 
            var order_dishesManager = new Order_DishesManager(Configuration);

            var order_dishes = order_dishesManager.GetOrder_Dishes();
            foreach (var order_dish in order_dishes)
            {
                Console.WriteLine(order_dish.ToString());
            }

            // Get one order_dishes
            var order_dishes2 = order_dishesManager.GetOrder_DishesId(1);
            if (order_dishes2 == null)
            {
                Console.WriteLine("Invalid ID");
            }
            else
            {
                Console.WriteLine(order_dishes2.ToString());
            }


            // Add a new order_dishes
            Console.WriteLine(" -- NEW ORDER_DISHES -- ");
            var newOrder_dishes = order_dishesManager.AddOrder_Dishes(new Order_Dishes { idOrder_Dishes = 1, quantity = 2 });
            Console.WriteLine($"ID: {newOrder_dishes.idOrder_Dishes} Quantity: {newOrder_dishes.quantity}");
            order_dishes = order_dishesManager.GetOrder_Dishes();
            foreach (var order_dish in order_dishes)
            {
                Console.WriteLine(order_dish.ToString());
            }

            //Update a order_dishes
            Console.WriteLine(" -- UPDATE ORDER_DISHES -- ");
            newOrder_dishes.quantity = 3;
            order_dishesManager.UpdateOrder_Dishes(newOrder_dishes);
            order_dishes = order_dishesManager.GetOrder_Dishes();
            foreach (var order_dish in order_dishes)
            {
                Console.WriteLine($"ID: {newOrder_dishes.idOrder_Dishes} Quantity: {newOrder_dishes.quantity}");
            }

            //Delete order_dishes
            Console.WriteLine(" -- DELETE ORDER_DISHES -- ");
            order_dishesManager.DeleteOrder_Dishes(newOrder_dishes.idOrder_Dishes);
            order_dishes = order_dishesManager.GetOrder_Dishes();

            foreach (var order_dish in order_dishes)
            {
                Console.WriteLine($"ID: {newOrder_dishes.idOrder_Dishes} Quantity: {newOrder_dishes.quantity}");
            }

            /*==================================================================================================*/

            /* ORDERS */

            // List the orders 
            var ordersManager = new OrdersManager(Configuration);

            var orders = ordersManager.GetOrders();
            foreach (var order in orders)
            {
                Console.WriteLine(order.ToString());
            }

            // Get one order
            var orders2 = ordersManager.GetOrdersId(1);
            if (orders2 == null)
            {
                Console.WriteLine("Invalid ID");
            }
            else
            {
                Console.WriteLine(orders2.ToString());
            }


            // Add a new order
            Console.WriteLine(" -- NEW ORDER -- ");
            var newOrder = ordersManager.AddOrders(new Orders { idOrders = 1 });
            Console.WriteLine($"ID: {newOrder.idOrders}");
            orders = ordersManager.GetOrders();
            foreach (var order in orders)
            {
                Console.WriteLine(order.ToString());
            }

            //Update a order
            Console.WriteLine(" -- UPDATE ORDER -- ");
            newOrder.idOrders = 2;
            ordersManager.UpdateOrders(newOrder);
            orders = ordersManager.GetOrders();
            foreach (var order in orders)
            {
                Console.WriteLine($"ID: {order.idOrders} ");
            }

            //Delete order
            Console.WriteLine(" -- DELETE ORDER -- ");
            ordersManager.DeleteOrders(newOrder.idOrders);
            orders = ordersManager.GetOrders();

            foreach (var order in orders)
            {
                Console.WriteLine($"ID: {newOrder.idOrders}");
            }

            /*==================================================================================================*/

            /* RESTAURANTS */

            // List the restaurants 
            var restaurantManager = new RestaurantManager(Configuration);

            var restaurants = restaurantManager.GetRestaurants();
            foreach (var restaurant in restaurants)
            {
                Console.WriteLine(restaurant.ToString());
            }

            // Get one restaurant
            var restaurants2 = restaurantManager.GetRestaurantsId(1);
            if (restaurants2 == null)
            {
                Console.WriteLine("Invalid ID");
            }
            else
            {
                Console.WriteLine(restaurants2.ToString());
            }


            // Add a new restaurant
            Console.WriteLine(" -- NEW RESTAURANT -- ");
            var newRestaurant = restaurantManager.AddRestaurants(new Restaurants { idRestaurant = 1, name = "ChezLesProgrammeurs" });
            Console.WriteLine($"ID: {newRestaurant.idRestaurant} Name: {newRestaurant.name}");
            restaurants = restaurantManager.GetRestaurants();
            foreach (var restaurant in restaurants)
            {
                Console.WriteLine(restaurants.ToString());
            }

            //Update a restaurant
            Console.WriteLine(" -- UPDATE RESTAURANT -- ");
            newRestaurant.name = "ChezLesRedoublants";
            restaurantManager.UpdateRestaurants(newRestaurant);
            restaurants = restaurantManager.GetRestaurants();
            foreach (var restaurant in restaurants)
            {
                Console.WriteLine($"ID: {newRestaurant.idRestaurant} Name: {newRestaurant.name}");
            }

            //Delete restaurant
            Console.WriteLine(" -- DELETE RESTAURANT -- ");
            restaurantManager.DeleteRestaurant(newRestaurant.idRestaurant);
            restaurants = restaurantManager.GetRestaurants();

            foreach (var restaurant in restaurants)
            {
                Console.WriteLine($"ID: {newRestaurant.idRestaurant} Name: {newRestaurant.name}");
            }

            /*==================================================================================================*/

            /* STAFF */

            // List the staffs 
            var staffManager = new StaffManager(Configuration);

            var staffs = staffManager.GetStaff();
            foreach (var staff in staffs)
            {
                Console.WriteLine(staff.ToString());
            }

            // Get one staff
            var staffs2 = staffManager.GetStaffId(1);
            if (staffs2 == null)
            {
                Console.WriteLine("Invalid ID");
            }
            else
            {
                Console.WriteLine(staffs2.ToString());
            }


            // Add a new staff
            Console.WriteLine(" -- NEW STAFF -- ");
            var newStaff = staffManager.AddStaff(new Staff {idStaff = 1,  firstName = "Follonier",  lastName = "Grego", address = "Verco", phone_number = 157943681,  email = "Grego.Follonier@hes-so.ch" });
            Console.WriteLine($"ID: {newStaff.idStaff} firstname: {newStaff.firstName} lastname: {newStaff.lastName} address: {newStaff.address} phone_number: {newStaff.phone_number} email: {newStaff.email}");
            staffs = staffManager.GetStaff();
            foreach (var staff in staffs)
            {
                Console.WriteLine(staff.ToString());
            }

            //Update a staff
            Console.WriteLine(" -- UPDATE STAFF -- ");
            newStaff.firstName = "Follo";
            staffManager.UpdateStaff(newStaff);
            staffs = staffManager.GetStaff();
            foreach (var staff in staffs)
            {
                Console.WriteLine($"ID: {newStaff.idStaff} firstname: {newStaff.firstName} lastname: {newStaff.lastName} address: {newStaff.address} phone_number: {newStaff.phone_number} email: {newStaff.email}");
            }

            //Delete staff
            Console.WriteLine(" -- DELETE STAFF -- ");
            staffManager.DeleteStaff(newStaff.idStaff);
            staffs = staffManager.GetStaff();

            foreach (var staff in staffs)
            {
                Console.WriteLine($"ID: {newStaff.idStaff} firstname: {newStaff.firstName} lastname: {newStaff.lastName} address: {newStaff.address} phone_number: {newStaff.phone_number} email: {newStaff.email}");
            }

            /*==================================================================================================*/

            /* STATUS */

            // List the status 
            var statusManager = new StatusManager(Configuration);

            var status = statusManager.GetStatus();
            foreach (var stat in status)
            {
                Console.WriteLine(stat.ToString());
            }

            // Get one status
            var status2 = statusManager.GetStatusId(1);
            if (status2 == null)
            {
                Console.WriteLine("Invalid ID");
            }
            else
            {
                Console.WriteLine(status2.ToString());
            }


            // Add a new status
            Console.WriteLine(" -- NEW STATUS -- ");
            var newStatus = statusManager.AddStatus(new Status { idStatus = 1, status_name = "Status" });
            Console.WriteLine($"ID: {newStatus.idStatus} Status: {newStatus.status_name} ");
            status = statusManager.GetStatus();
            foreach (var stat in status)
            {
                Console.WriteLine(stat.ToString());
            }

            //Update a status
            Console.WriteLine(" -- UPDATE STATUS -- ");
            newStatus.status_name = "Prêt";
            statusManager.UpdateStatus(newStatus);
            status = statusManager.GetStatus();
            foreach (var stat in status)
            {
                Console.WriteLine($"ID: {newStatus.idStatus} Status: {newStatus.status_name} ");
            }

            //Delete status
            Console.WriteLine(" -- DELETE STATUS -- ");
            statusManager.DeleteStatus(newStatus.idStatus);
            status = statusManager.GetStatus();

            foreach (var stat in status)
            {
                Console.WriteLine($"ID: {newStatus.idStatus} Status: {newStatus.status_name}");
            }

            /*==================================================================================================*/


            Console.ReadKey();
        }
    }
}
