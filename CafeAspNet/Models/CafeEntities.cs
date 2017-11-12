using System.Data.Entity;
using System.Collections;
using System.Collections.Generic;

namespace CafeAspNet.Models
{
    public class CafeEntities
    {
        private static CafeEntities instance;

        private CafeEntities()
        { }

        public static CafeEntities getInstance()
        {
            if (instance == null)
                instance = new CafeEntities();
            return instance;
        }

        public static IList<Dish> Dishs { get; set; }
        public static IList<TypeOfDish> Genres { get; set; }
        public static IList<Cart> Carts { get; set; } = new List<Cart>();
        public static IList<Order> Orders { get; set; }
        public static IList<OrderDetail> OrderDetails { get; set; }
    }
}