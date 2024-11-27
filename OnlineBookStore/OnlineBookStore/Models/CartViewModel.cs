using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBookStore.Models
{
    public class CartViewModel
    {
        public List<Book> SelectedBooks { get; set; }
        public double TotalPrice { get; set; }
    }
}