using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clup.Models
{
    public class Membership
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        [Range(100,10000)]
        public decimal Price { get; set; }
        [Required]
        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public Member Member { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; } 

        public ICollection<Payment> Payments { get; set; }
    }
}
