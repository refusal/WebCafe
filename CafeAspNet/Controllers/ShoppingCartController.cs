using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CafeAspNet.Models;
using CafeAspNet.ViewModels;
using System.Diagnostics.PerformanceData;

namespace MvcMusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems() ?? new List<Cart>(),
                CartTotal = cart.GetTotal()
            };

            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            var addedAlbum = CafeEntities.Dishs
                .Single(album => album.Id == id);

            if (CafeEntities.Carts != null)
                CafeEntities.Carts.Add(new Cart() { AlbumId = addedAlbum.Id, Album = addedAlbum, CartId = addedAlbum.Id.ToString(), Count = 1 });

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string albumName = CafeEntities.Carts
                .Single(item => item.RecordId == id).Album.Title;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(albumName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };

            return Json(results);
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();

            return PartialView("CartSummary");
        }
    }
}