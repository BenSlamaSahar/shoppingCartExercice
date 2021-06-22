using System;
using System.Collections.Generic;
using System.Text;

namespace shoppingCart.Model
{
    public class CouponToTypeItem : Coupon
    {
        public string productName;
        public int productIndex;
        public decimal priceOff;

        public CouponToTypeItem(string productName , int productIndex, decimal priceOff)
        {
            this.productName = productName;
            this.productIndex = productIndex;
            this.priceOff = priceOff;
        }

        public override void Discount(ref Product product)
        {
            product._price = product._price - priceOff;
        }
    }
}
