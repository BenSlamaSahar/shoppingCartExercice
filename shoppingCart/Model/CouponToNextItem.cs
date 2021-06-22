using System;
using System.Collections.Generic;
using System.Text;

namespace shoppingCart.Model
{
    public class CouponToNextItem : Coupon
    {
        private decimal discountValue;

        public CouponToNextItem(decimal discountValue)
        {
            this.discountValue = discountValue;
        }
        public override void Discount(ref Product product)
        {
            product._price -= (product._price / 100) * discountValue;
        }
    }
}
