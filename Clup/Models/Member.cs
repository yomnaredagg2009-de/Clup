using System.ComponentModel.DataAnnotations;

namespace Clup.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public Membership Membership { get; set; }
    }
}
