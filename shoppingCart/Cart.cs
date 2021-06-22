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
        private Guid _idCart;
        private List<item> _cartItems = new List<item>();
        private List<Product> _products = new List<Product>();
        private List<Coupon> _coupons = new List<Coupon>();

        public decimal TotalPrice()
        {
            this.CartAnalyse();

            _products.ForEach(product => product.CalculatePrice(product));

            return  _products.Sum(product => product._price);
        }

        private void CartAnalyse()
        {

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

        private void SaveCoupon(CouponToTypeItem coupon)
        {
            var isProductTypeExist = _products.Exists(elt => elt.productName.Equals(coupon.productName));
            var productsList = _products.FindAll(elt => elt.productName.Equals(coupon.productName));
            var productsNombre = productsList.Count();

            if (!isProductTypeExist)
                _coupons.Add(coupon);

            else if (productsNombre >= coupon.productIndex)
                productsList.ElementAt(coupon.productIndex - 1)._ownCoupons.Add(coupon);

            else
            {    coupon.productIndex -= productsNombre;
                _coupons.Add(coupon);
            }
        }

        public void SetItems(List<item> items)
        {
            _cartItems = items;
        }
    }
}
