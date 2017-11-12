using System.Collections.Generic;
using System.Linq;

namespace CafeAspNet.Models
{
    public partial class TypeOfDish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Dish> Dishs => CafeEntities.Dishs.Where(Dish => Dish.TypeId == Id).ToList();
    }
}
