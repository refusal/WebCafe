using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;

namespace CafeAspNet.Models
{
    [Bind(Exclude = "Id")]
    public class Dish
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DisplayName("Type")]
        public int TypeId { get; set; }

        [Required(ErrorMessage = "An Dish name is required")]
        [StringLength(160)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100.00,
            ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }

        [DisplayName("Album Art URL")]
        [StringLength(1024)]
        public string ArtUrl { get; set; }

        public virtual TypeOfDish Genre { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}