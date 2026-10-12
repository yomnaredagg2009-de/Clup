using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clup.Models
{
    public class Payment
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Membership")]
        public int MembershipId { get; set; }
        public Membership Membership { get; set; } 
        [Required]
        [Range(100, 10000)]
        public decimal Amount { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public string PaymentMethod { get; set; } 
    }
}
