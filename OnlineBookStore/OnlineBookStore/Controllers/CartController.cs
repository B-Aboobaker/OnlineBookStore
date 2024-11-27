using Newtonsoft.Json;
using OnlineBookStore.Models;
using System.Web.Mvc;
using System.Linq;
using System.Web;

public class CartController : Controller
{
    private readonly Cart _cart = new Cart();

    // GET: Cart
    public ActionResult Index()
    {
        var cart = GetCartFromSession();
        var selectedBooks = cart.SelectedBooks;
        var totalPrice = CalculateTotalPrice(cart); // Pass the cart to the CalculateTotalPrice method

        var viewModel = new CartViewModel
        {
            SelectedBooks = selectedBooks,
            TotalPrice = totalPrice
        };

        return View("Cart", viewModel);
    }


    private Cart GetCartFromSession()
    {
        var cart = Session["Cart"] as Cart;
        if (cart == null)
        {
            cart = new Cart();
            Session["Cart"] = cart;
        }
        return cart;
    }

    private double CalculateTotalPrice(Cart cart)
    {
        return cart.SelectedBooks.Sum(book => book.Price);
    }

    private Cart DeserializeCart(string cartJson)
    {
        return JsonConvert.DeserializeObject<Cart>(cartJson);
    }

    private Cart GetCartFromCookie()
    {
        var cartCookie = Request.Cookies["Cart"];
        if (cartCookie != null)
        {
            var cartJson = cartCookie.Value;
            return DeserializeCart(cartJson);
        }

        return new Cart();
    }

    private void UpdateCartFromCookie()
    {
        var cart = GetCartFromCookie();
        Session["Cart"] = cart;
    }

    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        UpdateCartFromCookie();
        base.OnActionExecuting(filterContext);
    }

    public ActionResult RemoveFromCart(int id)
    {
        var cart = GetCartFromSession();
        var bookToRemove = cart.SelectedBooks.FirstOrDefault(b => b.Id == id);

        if (bookToRemove != null)
        {
            bookToRemove.IsSelected = false;
            cart.SelectedBooks.Remove(bookToRemove);

            // Update the cart in session or cookie

            var cartJson = SerializeCart(cart);
            var cartCookie = new HttpCookie("Cart", cartJson);
            Response.Cookies.Add(cartCookie);
        }

        return RedirectToAction("Index");
    }

    private string SerializeCart(Cart cart)
    {
        return JsonConvert.SerializeObject(cart);
    }

}
