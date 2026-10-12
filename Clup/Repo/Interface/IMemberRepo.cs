using Clup.Dtos;
using Clup.Models;

namespace Clup.Repo.Interface
{
    public interface IMemberRepo : IGenericRepo<Member>
    {
        Task<ICollection<Member>> GetPageAsync(int pageNumber, int pageSize);
        Task<Member> SearchByNameAsync(string name);
 


    }
}
