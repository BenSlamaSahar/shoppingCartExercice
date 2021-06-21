using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using shoppingCart.Model;

namespace shoppingCart
{
    public class Cart
    {
        private List<item> _cartItems = new List<item>();
        private List<Product> _products = new List<Product>();
        private List<Coupon> _coupons = new List<Coupon>();

        public float TotalPrice()
        {
            this.CartAnalyse();

            _products.ForEach(product => product.CalculatePrice(product));

            return  _products.Sum(product => product._price);
        }

        void CartAnalyse()
        {
            var c1= new CouponToTypeItem("pen",2,10);
            var pro = new Product(new List<Coupon>(),"pen",100);
            var pro1 = new Product(new List<Coupon>(), "pen", 100);
            var c2 = new CouponToEachItem( 10);
            var pro2 = new Product(new List<Coupon>(), "pen", 100);
            _cartItems.Add(c1);
            _cartItems .Add(pro);
            _cartItems.Add(pro1);
            _cartItems.Add(c2);
            _cartItems.Add(pro2);

            _cartItems.ForEach(e =>
            {
                 SaveItem((dynamic)e);
                
            });

        }

        private void SaveItem(item cartItem)
        {
            AddItemToList((dynamic) cartItem);
        }

        private void AddItemToList(item cartItem)
        { }

        private void AddItemToList(Coupon cartItem)
        {
            SaveCoupon((dynamic) cartItem);}

        private void AddItemToList(Product cartItem)
        {
             cartItem.GetCoupons(_coupons);
            _products.Add(cartItem);
        }

        private void SaveCoupon(Coupon coupon)
         {
            _coupons.Add(coupon);
         }
     
        private void SaveCoupon(CouponToEachItem coupon)
         {
            this._products.ForEach(product => product._ownCoupons.Add(coupon));
            _coupons.Add(coupon);
         }
    }
}
