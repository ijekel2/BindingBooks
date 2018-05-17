using System.Collections.Generic;
using BindingBooks.Models;

namespace BindingBooks.ViewModels
{
    public class ThumbnailBoxViewModel
    {
        public IEnumerable<ThumbnailModel> Thumbnails { get; set; }
        
    }
}