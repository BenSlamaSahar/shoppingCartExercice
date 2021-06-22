using shoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace shoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            List<item> itemList = new List<item> {
                new CouponToTypeItem("pen", 2, 10),
                new Product("pen", 100),
                new Product("pen", 100),
                new CouponToEachItem(10),
                new Product("pen", 100)
            };
                
            var cart = new Cart();
            cart.SetItems(itemList);
            var totalPrice = cart.TotalPrice();
            Console.WriteLine("$"+ totalPrice);
            Thread.Sleep(300);

        }
    }
}
