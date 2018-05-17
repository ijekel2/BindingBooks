using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BindingBooks.Models;
using BindingBooks.ViewModels;
using EntityState = System.Data.Entity.EntityState;


namespace BindingBooks.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        // GET: Book
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Genre);
            return View(books.ToList());
        }
        
        // GET: Book
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Book book = db.Books.Find(id);

            if (book == null)
            {
                return HttpNotFound();
            }

            var bookModel = new BookViewModel
            {
                Book = book,
                Genres = db.Genres.ToList()
            };
            
            return View(bookModel);
        }
        
        // GET: Book
        public ActionResult Create()
        {
            var genres = db.Genres.ToList();
            var bookModel = new BookViewModel
            {
                Genres = genres
            };
            
            return View(bookModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel bookVM)
        {
            var book = new Book
            {
                Author = bookVM.Book.Author,
                Availability = bookVM.Book.Availability,
                DateAdded = bookVM.Book.DateAdded,
                Description = bookVM.Book.Description,
                Genre = bookVM.Book.Genre,
                GenreId = bookVM.Book.GenreId,
                ImageUrl = bookVM.Book.ImageUrl,
                ISBN = bookVM.Book.ISBN,
                Pages = bookVM.Book.Pages,
                Price = bookVM.Book.Price,
                ProductDimensions = bookVM.Book.ProductDimensions,
                PublicationDate = bookVM.Book.PublicationDate,
                Publisher = bookVM.Book.Publisher,
                Title = bookVM.Book.Title
            };

            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            bookVM.Genres = db.Genres.ToList();
            return View(bookVM);

        }
        
        // GET: Book
        public ActionResult Edit(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Book book = db.Books.Find(id);

            if (book == null)
            {
                return HttpNotFound();
            }

            var bookModel = new BookViewModel
            {
                Genres = db.Genres.ToList(),
                Book = book
            };
            return View(bookModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(BookViewModel bookVM)
        {
            var book = new Book
            {
                Id = bookVM.Book.Id,
                Author = bookVM.Book.Author,
                Availability = bookVM.Book.Availability,
                DateAdded = bookVM.Book.DateAdded,
                Description = bookVM.Book.Description,
                Genre = bookVM.Book.Genre,
                GenreId = bookVM.Book.GenreId,
                ImageUrl = bookVM.Book.ImageUrl,
                ISBN = bookVM.Book.ISBN,
                Pages = bookVM.Book.Pages,
                Price = bookVM.Book.Price,
                ProductDimensions = bookVM.Book.ProductDimensions,
                PublicationDate = bookVM.Book.PublicationDate,
                Publisher = bookVM.Book.Publisher,
                Title = bookVM.Book.Title
            };

          
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }


            bookVM.Genres = db.Genres.ToList();
            return View(bookVM);

        }
        
        // GET: Book
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Book book = db.Books.Find(id);

            if (book == null)
            {
                return HttpNotFound();
            }
            
            var bookModel = new BookViewModel
            {
                Genres = db.Genres.ToList(),
                Book = book
            };
            
            return View(bookModel);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
                var book = db.Books.Find(id);
                db.Books.Remove(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            

        }


        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}