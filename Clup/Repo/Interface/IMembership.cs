using Clup.Models;

namespace Clup.Repo.Interface
{
    public interface IMembership :IGenericRepo<Membership>
    {
        Task<ICollection<Membership>> GetActiveMembershipsAsync();
        Task<bool> RenewMembershipAsync(int id);
    }
}
