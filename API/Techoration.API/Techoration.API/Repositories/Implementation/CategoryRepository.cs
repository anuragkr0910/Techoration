using Microsoft.EntityFrameworkCore;
using Techoration.API.Data;
using Techoration.API.Models.Domain;
using Techoration.API.Repositories.Interface;

namespace Techoration.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext dbContext;

        public CategoryRepository(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryById(Guid id)
        {
           return await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
            var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);

            if (existingCategory != null)
            {
                // dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
                existingCategory.Name = category.Name;
                existingCategory.URLHandle = category.URLHandle;
                await dbContext.SaveChangesAsync();
                return existingCategory;
            }
            return null;
        }
    }
}
