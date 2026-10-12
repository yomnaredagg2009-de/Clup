
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clup.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public Member Member { get; set; } 
        [Required]
        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        public Facility Facility { get; set; } = new Facility();
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; } 
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        [Range(1, 100)]
        public int GroupSize { get; set; }
        [Required]
        public sbyte Status { get; set; } // 0 = Pending, 1 = Confirmed, 2 = Cancelled


    }
}
