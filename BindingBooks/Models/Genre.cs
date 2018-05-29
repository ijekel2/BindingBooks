using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BindingBooks.Models
{
    public class Genre
    {
        [Key]
        [Required] public int Id { get; set; }
        
        [Required] 
        [DisplayName("Genre")]
        public string Name { get; set; }
    }
}