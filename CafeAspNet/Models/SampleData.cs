using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CafeAspNet.Models
{
    public static class SampleData
    {
        public static void SetDefaultData()
        {
            var dishTypes = new List<TypeOfDish>
            {
                new TypeOfDish { Name = "Pizza" , Id=1},
                new TypeOfDish { Name = "Hot Dishs", Id =2 },
                new TypeOfDish { Name = "Drinks" , Id=3 }
            };
            MusicStoreEntities.Genres = dishTypes;


            var dish = new List<Dish>
            {
                new Dish(){ Id=1, Title="Pizza Margarita", TypeId = 1 , Price = 12},
                new Dish(){ Id=2, Title="Beaf Meat", TypeId = 2, Price = 11 },
                new Dish(){ Id=3, Title="Pasta", TypeId = 2, Price = 10 },
                new Dish(){ Id=4, Title="Bear", TypeId = 3, Price = 5 },
                new Dish(){ Id=5, Title="Water", TypeId = 3, Price = 1 }
            };

            MusicStoreEntities.Dishs = dish;
        }
    }
}