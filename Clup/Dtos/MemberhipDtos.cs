using System.ComponentModel.DataAnnotations;

namespace Clup.Dtos
{
    public class GetMembershipDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
    public class CreateMembershipDto
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
    }
    public class PatchMembershipDto
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
    }
}
