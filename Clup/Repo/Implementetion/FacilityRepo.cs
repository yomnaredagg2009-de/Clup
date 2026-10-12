namespace Clup.Repo.Implementetion
{
    using Clup.AppDbContext;
    using Clup.Models;
    using Clup.Repo.Interface;
    using Microsoft.EntityFrameworkCore;

    public class FacilityRepository : GenericRepo<Facility>//, IFacilityRepository
    {
        private readonly ClupDbContext _dbContext;
        public FacilityRepository(ClupDbContext context) : base(context) 
        {
            _dbContext = context;
        }

        //public async Task<IEnumerable<Facility>> GetSortedFacilitiesAsync(string? sortBy)
        //{
        //    _dbContext.Facilities.
            
        //}
    }
}
