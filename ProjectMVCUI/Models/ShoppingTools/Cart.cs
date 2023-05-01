using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMVCUI.Models.ShoppingTools
{
    public class Cart
    {
        Dictionary<int, CartItem> _sepetim;

        public Cart() 
        {
            _sepetim = new Dictionary<int, CartItem>();
        }


        public List<CartItem> sepetim
        {
            get
            {
                return _sepetim.Values.ToList();
            }
        }



        public void SepetEkle(CartItem item)
        {
            if(_sepetim.ContainsKey(item.Id))
            {
                _sepetim[item.Id].Amount++;
                return;
            }
            _sepetim.Add(item.Id, item);
        }
        public void SepettenCikar(int id)
        {
            if (_sepetim[id].Amount > 1)
            {
                _sepetim[id].Amount--;
                return;
            }
            _sepetim.Remove(id);
        }

        public decimal TotalPrice
        {
            get 
            {
                return _sepetim.Sum(x => x.Value.SubTotal);
            }
        }
             
    }
}