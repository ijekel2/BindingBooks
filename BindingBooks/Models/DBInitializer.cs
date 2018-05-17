using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BindingBooks.Models
{
    public class DBInitializer<T> : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            IList<MembershipType> membershipTypes = new List<MembershipType>();
            IList<Genre> genres = new List<Genre>();
            IList<Book> books = new List<Book>();

            //
            // Add Membership Types
            membershipTypes.Add(new MembershipType
            {
                Name = "Non-member",
                SignUpFee = 0,
                ChargeRateOneMonth = 25,
                ChargeRateSixMonth = 50
            });
            
            membershipTypes.Add(new MembershipType
            {
                Name = "Member",
                SignUpFee = 150,
                ChargeRateOneMonth = 10,
                ChargeRateSixMonth = 20
            });
            
            membershipTypes.Add(new MembershipType
            {
                Name = "SuperAdmin",
                SignUpFee = 0,
                ChargeRateOneMonth = 0,
                ChargeRateSixMonth = 0
            });

            foreach (var membershipType in membershipTypes)
                db.MembershipTypes.Add(membershipType);
            
            db.SaveChanges();

            
            //
            // Add Genres
            genres.Add(new Genre
            {
                Name = "Fantasy"
            });
            
            genres.Add(new Genre
            {
                Name = "Psychological Fiction"
            });
            
            genres.Add(new Genre
            {
                Name = "Romantic Fiction"
            });
            
            genres.Add(new Genre
            {
                Name = "Historical Fiction"
            });
            
            genres.Add(new Genre
            {
                Name = "Science Fiction"
            });

            foreach (var genre in genres)
                db.Genres.Add(genre);
            
            db.SaveChanges();

            
            //
            // Add Books
            books.Add(new Book
            {
                Title = "The Name of the Wind",
                ISBN = "0756404746",
                Author = "Patrick Rothfuss",
                Description = "Kvothe, a lute-wielding polymath, seeks to avenge himself upon his family's murderers.",
                ImageUrl = "/Content/Images/Nameofthewindcover.png",
                Availability = "In Stock",
                Price = 21.70,
                DateAdded = DateTime.Today,
                GenreId = 1,
                PublicationDate = new DateTime(2007, 04, 30),
                Pages = 722,
                ProductDimensions = "4.5 x 1.5 x 7.2",
                Publisher = "DAW Books"             
            });
            
            books.Add(new Book
            {
                Title = "Crime and Punishment",
                ISBN = "1613826397",
                Author = "Fyodor Dostoevsky",
                Description = "Raskolnikov, a young nihilist, contemplates the murder of an evil woman.",
                ImageUrl = "/Content/Images/Crimeandpunishmentcover.png",
                Availability = "In Stock",
                Price = 17.40,
                DateAdded = DateTime.Today,
                GenreId = 2,
                PublicationDate = new DateTime(2016, 09, 07),
                Pages = 370,
                ProductDimensions = "6.0 x 0.9 x 9.0",
                Publisher = "Simon & Brown"             
            });
            
            books.Add(new Book
            {
                Title = "Anne of Green Gables",
                ISBN = "0486410250",
                Author = "Lucy Maud Montgomery",
                Description = "Anne, a red-headed orphan, faces the challenges of entering a new family.",
                ImageUrl = "/Content/Images/Anneofgreengablescover.png",
                Availability = "In Stock",
                Price = 14.90,
                DateAdded = DateTime.Today,
                GenreId = 3,
                PublicationDate = new DateTime(2000, 03, 10),
                Pages = 320,
                ProductDimensions = "5.2 x 1.0 x 8.5",
                Publisher = "Dover Publications"             
            });
            
            books.Add(new Book
            {
                Title = "The Book Thief",
                ISBN = "0375842209",
                Author = "Markus Zusak",
                Description = "Liesel, a foster girl living in Nazi Germany, defies the regime by concealing a Jewish man in her house.",
                ImageUrl = "/Content/Images/Bookthiefcover.png",
                Availability = "In Stock",
                Price = 13.90,
                DateAdded = DateTime.Today,
                GenreId = 4,
                PublicationDate = new DateTime(2007, 09, 11),
                Pages = 592,
                ProductDimensions = "5.2 x 1.2 x 8.1",
                Publisher = "Alfred A. Knopf"             
            });
            
            books.Add(new Book
            {
                Title = "Dune",
                ISBN = "0441172717",
                Author = "Frank Herbert",
                Description = "A young boy named Paul Atreides discovers his destiny to forever change the fortunes of mankind.",
                ImageUrl = "/Content/Images/Dunecover.png",
                Availability = "In Stock",
                Price = 20.40,
                DateAdded = DateTime.Today,
                GenreId = 5,
                PublicationDate = new DateTime(1990, 09, 01),
                Pages = 896,
                ProductDimensions = "4.4 x 1.9 x 7.6",
                Publisher = "Ace"             
            });
           
            foreach (var book in books)
                db.Books.Add(book);
            
            //
            //Save changes to database
            db.SaveChanges();
            base.Seed(db);
            
        }
            
    }
}