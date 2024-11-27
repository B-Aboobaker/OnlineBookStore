using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using OnlineBookStore.Models;

namespace OnlineBookStore.Controllers
{
    public class BookController : Controller
    {
        private List<Book> _books; // A list to store the books (Replace it with your own data source)
        private readonly Cart _cart = new Cart(); // Create an instance of the Cart

        public BookController()
        {
            // Initialize the list of books (Replace it with your own data source)
            _books = new List<Book>
            {
                new Book { Id = 1, Title = "I Know Why The Caged Bird Sings", Author = "Maya Angelou", Price = 349.99 },
                new Book { Id = 2, Title = "East of Eden", Author = "John Steinbeck", Price = 369.99 },
                new Book { Id = 3, Title = "The Sun Also Rises", Author = "Ernest Hemingway", Price = 444.99 },
                new Book { Id = 4, Title = "Do Androids Dream of Electric Sheep", Author = "Philip K. Dick", Price = 199.99 },
                new Book { Id = 5, Title = "The Curious Incident of the Dog in the Night-Time", Author = "Mark Haddon", Price = 364.99 },
                new Book { Id = 6, Title = "Cloudy with a chance of Meatballs", Author = "Judi Berrett", Price = 262.99 },
                new Book { Id = 7, Title = "Pride and Prejudice and Zombies", Author = "Seth Grahame-Smith", Price = 294.99 },
                new Book { Id = 8, Title = "The House of Mirth", Author = "Edith Wharton", Price = 329.99 },
                new Book { Id = 9, Title = "Are You There, Vodka? It's Me, Chelsea", Author = "Chelsea Handler", Price = 483.99 },
                new Book { Id = 10, Title = "And Then There Were None", Author = "Agatha Christie", Price = 559.99 },
                new Book { Id = 11, Title = "Their Eyes Were Watching God", Author = "Zora Neale Hurston", Price = 404.99 },
                new Book { Id = 12, Title = "The Devil Wears Prada", Author = "Lauren Weisberger", Price = 369.99 },
                new Book { Id = 13, Title = "Brand New World", Author = "Aldous Huxley", Price = 327.99 },
                new Book { Id = 14, Title = "Burn My Heart at Wounded Knee", Author = "Dee Brown", Price = 407.99 },
                new Book { Id = 15, Title = "The Man Who Was Thursday", Author = "G.K. Chesterton", Price = 329.99 }
            };
        }

        // GET: Book/Index
        public ActionResult Index()
        {
            var viewModel = new BookViewModel
            {
                Books = _books.ToList()
            };

            return View(viewModel);
        }

        // GET: Book/Search
        public ActionResult Search()
        {
            return View("~/Views/Book/Search.cshtml");
        }

        // POST: Book/Search
        [HttpPost]
        public ActionResult Search(string searchTerm)
        {
            // Perform the search based on the searchTerm and retrieve the search results
            List<Book> searchResults = _books
                .Where(book => book.Title.Contains(searchTerm) || book.Author.Contains(searchTerm))
                .ToList();

            // Create an instance of BookViewModel and assign the search results
            BookViewModel viewModel = new BookViewModel
            {
                Books = searchResults
            };

            return View("Search", viewModel);
        }

        // POST: Book/AddToCart/5
        [HttpPost]
        public ActionResult AddToCart(int id, int quantity)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);

            if (book != null && quantity > 0)
            {
                book.IsSelected = true;
                var cart = GetCartFromSession();

                // Add the specified quantity of the book to the cart
                for (int i = 0; i < quantity; i++)
                {
                    cart.SelectedBooks.Add(book);
                }

                // Serialize the cart object into a JSON string
                var cartJson = SerializeCart(cart);

                // Create a cookie to store the cart data
                var cartCookie = new HttpCookie("Cart", cartJson);
                Response.Cookies.Add(cartCookie);
            }

            return RedirectToAction("Index", "Cart");
        }

        private string SerializeCart(Cart cart)
        {
            return JsonConvert.SerializeObject(cart);
        }


        // GET: Book/Cart
        public ActionResult Cart(double totalPrice)
        {
            var selectedBooks = _cart.SelectedBooks;

            var viewModel = new CartViewModel
            {
                SelectedBooks = selectedBooks,
                TotalPrice = totalPrice
            };

            return View("~/Views/Cart/Cart.cshtml", viewModel);
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

        [HttpPost]
        public ActionResult UpdateBookQuantity(int bookId, int quantity)
        {
            var book = _books.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {
                book.Quantity = quantity;
            }

            return Json(new { success = true });
        }

    }
}
