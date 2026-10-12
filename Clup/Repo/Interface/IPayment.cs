using Clup.Models;

namespace Clup.Repo.Interface
{
    public interface IPayment : IGenericRepo<Payment>
    {
        Task<object> GetPaymentStatisticsAsync();

    }
}
