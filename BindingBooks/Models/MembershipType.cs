using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BindingBooks.Models
{
    public class MembershipType
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.Currency)]
        public double SignUpFee { get; set; }

        [Required]
        [DisplayName("Rental Rate")]
        [DataType(DataType.Currency)]
        public double ChargeRateOneMonth { get; set; }
        
        [Required]
        [DataType(DataType.Currency)]
        public double ChargeRateSixMonth { get; set; }
        
    }
}