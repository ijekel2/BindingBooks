using System.Collections;
using System.Collections.Generic;
using BindingBooks.Models;

namespace BindingBooks.ViewModels
{
    public class BookViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Book Book { get; set; }
    }
}