using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace shoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            var cart = new Cart();
            var totalPrice = cart.TotalPrice();
            Console.WriteLine("$"+ totalPrice);
            Thread.Sleep(300);

        }
    }
}
