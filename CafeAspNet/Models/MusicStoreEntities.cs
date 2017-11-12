using System.Data.Entity;
using System.Collections;
using System.Collections.Generic;

namespace CafeAspNet.Models
{
    public class MusicStoreEntities
    {
        private static MusicStoreEntities instance;

        private MusicStoreEntities()
        { }

        public static MusicStoreEntities getInstance()
        {
            if (instance == null)
                instance = new MusicStoreEntities();
            return instance;
        }

        public static IList<Dish> Dishs { get; set; }
        public static IList<TypeOfDish> Genres { get; set; }
        public static IList<Cart> Carts { get; set; } = new List<Cart>();
        public static IList<Order> Orders { get; set; }
        public static IList<OrderDetail> OrderDetails { get; set; }
    }
}