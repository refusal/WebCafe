using System.Collections.Generic;
using CafeAspNet.Models;

namespace CafeAspNet.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}