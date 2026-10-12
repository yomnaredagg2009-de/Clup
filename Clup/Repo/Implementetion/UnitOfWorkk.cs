using Clup.AppDbContext;
using Clup.Models;
using Clup.Repo.Interface;

namespace Clup.Repo.Implementetion
{
    public class UnitOfWorkk : IUnitOfWork
    {
        private readonly ClupDbContext _context;
        public IMemberRepo Members { get; }
        public IGenericRepo<Membership> Memberships { get; }
        public IGenericRepo<Facility> Facilities { get; }
        public IPayment Payment { get; }
        public IMembership Membership { get; }
        public UnitOfWorkk(ClupDbContext context , IMemberRepo memberRepo, IGenericRepo<Membership> memberships, IGenericRepo<Facility> facilities, IPayment payment, IMembership membership)
        {
            _context = context;
            Members = memberRepo;
            Memberships = memberships;
            Facilities = facilities;
            Payment = payment;
            this.Membership = membership;   
        }



        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
