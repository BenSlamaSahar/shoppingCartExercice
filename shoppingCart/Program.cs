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
                new CouponToEachItem(5),
                new Product("pen", 10),
                new Product("book", 15),
                new CouponToTypeItem ("pen",3,5),
                new CouponToNextItem(50),
                new Product("pen", 10),
                new Product("notebook", 18),
                new CouponToTypeItem ("pen",2,2),
                new Product("pen", 16),
                new Product("pen", 10),
            };
                
            var cart = new Cart();
            cart.SetItems(itemList);
            var totalPrice = cart.TotalPrice();
            Console.WriteLine("$"+ totalPrice);
            Thread.Sleep(300);

        }
    }
}
