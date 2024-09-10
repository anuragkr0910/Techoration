using Techoration.API.Models.Domain;

namespace Techoration.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
    }
}
