using Clup.AppDbContext;
using Clup.Models;
using Clup.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace Clup.Repo.Implementetion
{
    public class MemberRepo : GenericRepo<Member>, IMemberRepo
    {
        private readonly ClupDbContext _context;
        public MemberRepo(ClupDbContext context) : base(context)
        {
            _context = context;
        }

        //Query: pageNumber, pageSize, sortBy



        public async Task<ICollection<Member>> GetPageAsync(int pageNumber, int pageSize)
        {
            return await _context.Members
              .Include(m => m.Membership)
              .OrderBy(m => m.Id)
              .Skip((pageNumber - 1) * pageSize)
              .Take(pageSize)
              .ToListAsync();
        }

        

        public async Task<Member> SearchByNameAsync(string name)
        {
            return await _context.Members
                .Include(m => m.Membership)
                .FirstOrDefaultAsync(m => m.FullName.Contains(name));
        }
    }
}
