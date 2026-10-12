using Clup.AppDbContext;
using Clup.Models;
using Clup.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace Clup.Repo.Implementetion
{
    public class PaymentRepo : GenericRepo<Payment>, IPayment
    {
        private readonly ClupDbContext _dbContext;
        public PaymentRepo(ClupDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<object> GetPaymentStatisticsAsync()
        {
            var payments = await _dbContext.Payments.ToListAsync();
            var s = new
            {
                TotalPayments = payments.Count,
                TotalRevenue = payments.Sum(w => w.Amount),
                AveragePayment = payments.Any() ? payments.Average(p => p.Amount) : 0,
                MaxAmount = payments.Max(p => p.Amount),
                MinAmount = payments.Min(p => p.Amount)
            };
            return s;
             

        }
    }
}
