using System;
using System.Collections.Generic;
using System.Text;

namespace shoppingCart.Model
{
    public class CouponToTypeItem : Coupon
    {
        public string productName;
        public int productIndex;
        public float priceOff;

        public CouponToTypeItem(string productName , int productIndex, float priceOff)
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
