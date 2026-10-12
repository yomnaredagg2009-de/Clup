using System.Security.Policy;
using Clup.AppDbContext;
using Clup.Models;
using Clup.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace Clup.Repo.Implementetion
{
    public class MembershipRepo : GenericRepo<Membership>, IMembership
    {
        private readonly ClupDbContext _db;
        public MembershipRepo(ClupDbContext context) : base(context)
        {
            _db = context;
        }

        public async Task<ICollection<Membership>> GetActiveMembershipsAsync()
        {
            return await _db.Memberships
                .Where(e => e.Status.ToLower() == "active")
                .ToListAsync();
        }
        public async Task<bool> RenewMembershipAsync(int id)
        {
            var membership = await _db.Memberships.FindAsync(id);
            if (membership == null) return false;
            if(membership.Type == "Gold")
            {
                membership.EndDate = DateTime.Now.AddYears(1);
            }
            else if (membership.Type == "Silver")
            {
                membership.EndDate = DateTime.Now.AddMonths(3);
            }
            if (membership.Type == "Basic")
            {
                membership.EndDate = DateTime.Now.AddMonths(1);
            }
            membership.Status = "Active";

            return true;
        }
    }
}
