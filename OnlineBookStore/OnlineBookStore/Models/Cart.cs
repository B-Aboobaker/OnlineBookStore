using System.Collections.Generic;
using System.Linq;

namespace OnlineBookStore.Models
{
    public class Cart
    {
        public List<Book> SelectedBooks { get; set; }
        public double TotalPrice { get; set; }

        public Cart()
        {
            SelectedBooks = new List<Book>();
            TotalPrice = 0;
        }
    }
}
