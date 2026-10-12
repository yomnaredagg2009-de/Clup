using Clup.Models;

namespace Clup.Repo.Interface
{
    public interface IFacilityRepository : IGenericRepo<Facility>
    {
        Task<IEnumerable<Facility>> GetSortedFacilitiesAsync(string? sortBy);
    }
}
