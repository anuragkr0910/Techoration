using Techoration.API.Models.Domain;

namespace Techoration.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);

        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category?> GetCategoryById(Guid id);

        Task<Category?> UpdateAsync(Category category);
    }
}
