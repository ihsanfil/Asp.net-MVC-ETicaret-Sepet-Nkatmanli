using System.Web.Mvc;
using Northwind.Entities;
using Northwind.Interfaces;

namespace Northwind.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        public RedirectToRouteResult AddToCart(Cart cart,int productId)
        {
            Product product = _productService.Get(productId);

            cart.AddToCart(product, 1); //sepet varsa ürünü sepete ekle

            return RedirectToAction("Index",cart);
        }

        public ViewResult Index(Cart cart)
        {
            //Cart cart = (Cart)Session["cart"];
            return View(cart);
        }

        public ActionResult RemoveFromCart(Cart cart, int productId)
        {
            Product product = _productService.Get(productId);

            //Cart cart = (Cart)Session["cart"];
            //if (cart.Lines.Count == 0)
            //{
            //    //ModelState.AddModelError("","Sepetinizde ürün bulunmamaktadır");
            //}
            //else
            //{
              cart.RemoveFromCart(product);  //entities katmanında biz yazdık bu metodu 
            //}        

            return RedirectToAction("Index",cart);
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails shippingDetails)
        {
            if (ModelState.IsValid)
            {
                //ModelState.IsValid gelen modelde sorun yoksa demek
                //Manager'dan veri tabanına kayıt sağlanacak
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public PartialViewResult CartSummery(Cart cart)
        {
            //Cart cart = (Cart)Session["cart"];

            //if (cart==null) //boşsa yenisini oluştur
            //{
            //    cart= new Cart();
            //}

            return PartialView(cart);
        }
    }

}