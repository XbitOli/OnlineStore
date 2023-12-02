using System;
using System.Runtime.InteropServices;

namespace OnlineStore
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var iphone12 = new Good("IPhone12");
            var iphone11 = new Good("IPhone11");

            var warehouse = new Warehouse();
            warehouse.Delive(iphone11, 10);
            warehouse.Delive(iphone12, 1);
            
            Show(warehouse);
            
            var shop = new Shop(warehouse);
            Cart cart = shop.Cart();
            cart.Add(iphone12, 4);
            cart.Add(iphone11, 3);
            
            Show(cart);
            
            Console.WriteLine("Оплата: " + cart.CreateOrder().Paylink);
            
            cart.Add(iphone12, 7);
            Console.WriteLine(cart.CreateOrder().Paylink);
            Show(cart);
            Show(warehouse);
            Console.ReadLine();
        }

        public static void Show(IShowable showable)
        {
            if (showable == null)
                throw new ArgumentNullException("Argument is null", nameof(showable));
            
            showable.Show();
        }
        
    }
}