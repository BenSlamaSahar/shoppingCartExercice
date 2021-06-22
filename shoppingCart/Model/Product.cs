using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shoppingCart.Model
{
    public class Product : item
    {
         public List<Coupon> _ownCoupons = new List<Coupon>();
         public string productName;
         public decimal _price;

          public Product(string productName, decimal _price)
          {          
            this.productName = productName;
            this._price = _price;
          }
        public void GetCoupons(List<Coupon> couponsList)
        {
            
            foreach (var coupon in couponsList.ToList())
            {
                var couponType = coupon.GetType();

                if (couponType == typeof(CouponToNextItem))
                {
                    _ownCoupons.Add(coupon);
                    couponsList.Remove(coupon);

                }
                else if (couponType == typeof(CouponToTypeItem))
                {
                    var _coupon = (CouponToTypeItem) coupon;
                    if (_coupon.productName.Equals(productName) && _coupon.productIndex != 1)
                    {
                        _coupon.productIndex -= 1;
                    }
                    else
                    {
                        _ownCoupons.Add(coupon);
                        couponsList.Remove(coupon);
                    }
                }
                else

                    _ownCoupons.Add(coupon);
            }
        }

        public decimal CalculatePrice(Product product)
        {
            foreach (var elt in product._ownCoupons)
            {
                ApplyCoupon((dynamic)elt , ref product);
            }

            return product._price;

        }


        private void ApplyCoupon(Coupon coupon, ref Product p)
        {  }

         private void ApplyCoupon(CouponToEachItem coupon, ref Product p)
        { coupon.Discount(ref p); }

        private void ApplyCoupon(CouponToNextItem coupon, ref Product p)
        { coupon.Discount(ref p); }

        private void ApplyCoupon(CouponToTypeItem coupon, ref Product p)
        { coupon.Discount(ref p); }

    }
}

