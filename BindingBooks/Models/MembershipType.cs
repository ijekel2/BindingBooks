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
        [DisplayName("Membership")]
        public string Name { get; set; }
        
        [Required]
        [DisplayName("Sign-up Fee")]
        [DataType(DataType.Currency)]
        public double SignUpFee { get; set; }

        [Required]
        [DisplayName("1 Month Rate")]
        [DataType(DataType.Currency)]
        public double ChargeRateOneMonth { get; set; }
        
        [Required]
        [DisplayName("6 Month Rate")]
        [DataType(DataType.Currency)]
        public double ChargeRateSixMonth { get; set; }
        
    }
}