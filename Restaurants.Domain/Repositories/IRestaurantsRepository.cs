using Restaurants.Application.Common;
using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Restaurant>> GetAllAsync();
        Task<Restaurant?> GetByIdAsync(int id);
        Task<int> Create(Restaurant entity);
        Task Delete(Restaurant entity);
        Task Update(Restaurant entity);
        Task<(IEnumerable<Restaurant>, int)> GetAllMatchingAsync(string? searchPhrase,
            int PagaSize,
            int PageNumber,
            string? SortBy,
            SortDirection SortDirection
            );
    }
}
