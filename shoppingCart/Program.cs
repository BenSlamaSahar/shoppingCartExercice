using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace shoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Cart();
            var t =c.TotalPrice();
            Console.WriteLine(t);
            Thread.Sleep(300);

        }
    }
}
