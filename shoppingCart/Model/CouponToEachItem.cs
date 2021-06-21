using System;
using System.Collections.Generic;
using System.Text;

namespace shoppingCart.Model
{
    public class CouponToEachItem : Coupon
    {
         float discountValue;

         public CouponToEachItem(float discountValue)
         {
             this.discountValue = discountValue;
         }

         public  override void Discount(ref Product product)
        {
            product._price -= (product._price /100)* discountValue;
        }
    }
}
