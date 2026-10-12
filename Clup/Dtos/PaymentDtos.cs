namespace Clup.Dtos
{
    public class CreatePaymentDto
    {
        public int MembershipId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
    }

    public class GetPaymentDto
    {
        public int Id { get; set; }
        public int MembershipId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }

    }
}