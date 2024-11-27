using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookStore.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter an author.")]
        public string Author { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a valid price.")]
        public double Price { get; set; }

        public int Quantity { get; set; } // Add the Quantity property

        public bool IsSelected { get; set; }
    }

    public class BookViewModel
    {
        public List<Book> Books { get; set; }
    }
}
