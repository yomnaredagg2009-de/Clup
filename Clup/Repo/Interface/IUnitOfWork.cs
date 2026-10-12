using Clup.Models;

namespace Clup.Repo.Interface
{
    public interface IUnitOfWork
    {
        IMemberRepo Members { get; }
        IGenericRepo<Membership> Memberships { get; }
        IGenericRepo<Facility> Facilities { get; }
        IPayment Payment { get; }
        IMembership Membership { get; }
        Task Save();
    }
}
