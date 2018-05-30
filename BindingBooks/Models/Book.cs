using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BindingBooks.Models
{
    public class Book
    {
        [Key]
        [Required] public int Id { get; set; }

        [Required] public string ISBN { get; set; }

        [Required] public string Title { get; set; }

        [Required] public string Author { get; set; }

        [Required] 
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Image URL")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        public string Availability { get; set; }
        
        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayName("Date Added")]
        [DisplayFormat(DataFormatString = "{0: MM dd yyyy}")]
        public DateTime DateAdded { get; set; }
        
        [Required]  
        [DisplayName("Genre Id")]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Pubication Date")]
        [DisplayFormat(DataFormatString = "{0: MM dd yyyy}")]
        public DateTime PublicationDate { get; set; }
        
        [Required] public int Pages { get; set; }
        
        [Required] 
        [DisplayName("Dimensions")]
        public string ProductDimensions { get; set; }
        
        [Required] public string Publisher { get; set; }
        


}
}