using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BindingBooks.Models;

namespace BindingBooks.Extensions
{
    public static class ThumbnailExtension
    {
        public static IEnumerable<ThumbnailModel> GetBookThumbnail(this List<ThumbnailModel> thumbnails, ApplicationDbContext db = null, string search = null)
        {
            try
            {
                if (db == null)
                {
                    db = ApplicationDbContext.Create();
                }

                thumbnails = (from b in db.Books
                    select new ThumbnailModel
                    {
                        BookId = b.Id,
                        Title = b.Title,
                        Description = b.Description,
                        ImageUrl = b.ImageUrl,
                        Link = "../Book/Details/" + b.Id

                    }).ToList();

                if (search != null)
                {
                    return thumbnails.Where(t => t.Title.ToLower().Contains(search.ToLower())).OrderBy(t => t.Title);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return thumbnails.OrderBy(b => b.Title);

        }
    }
}