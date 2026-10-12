using System.ComponentModel.DataAnnotations;

namespace Clup.Models
{
    public class Facility
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(1, 1000)]
        public int Capacity { get; set; }
        [Required]
        [Range(50,10000)]
        public decimal HourlyPrice { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
