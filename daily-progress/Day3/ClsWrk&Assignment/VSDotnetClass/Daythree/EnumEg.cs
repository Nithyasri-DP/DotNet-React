using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSDotnetClass.Daythree
{
    enum OrderStatus
    {
        Pending = 1,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }

    class Order
    {
        public int OrderId { get; set; }
        public string ? CustomerName { get; set; }
        public OrderStatus Status { get; set; }

        public void DisplayOrder()
        {
            Console.WriteLine($"Order ID: {OrderId}, Customer: {CustomerName}, Status: {Status}");
        }
    }

    static class EnumEg
    {
        public static void Enumrun()
        {
            Order order = new Order()
            {
                OrderId = 1001,
                CustomerName = "Tina",
                Status = OrderStatus.Shipped
            };

            order.DisplayOrder();

            Console.WriteLine("Update the Status");
            Console.WriteLine("1. Pending\n2. Processing\n3. Shipped\n4. Delivered\n5. Cancelled");
            Console.Write("Enter the choice (1-5): ");

            if (int.TryParse(Console.ReadLine(), out int choice) &&
                Enum.IsDefined(typeof(OrderStatus), choice))
            {
                order.Status = (OrderStatus)choice;
                Console.WriteLine("Order status updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid choice selection.");
            }

            order.DisplayOrder();
        }
    }
}