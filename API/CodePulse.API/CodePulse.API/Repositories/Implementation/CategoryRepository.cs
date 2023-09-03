using CodePulse.API.Models.Context;
using CodePulse.API.Models.Domain;
using CodePulse.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            _applicationDbContext.Categories.Add(category);
            await _applicationDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _applicationDbContext.Categories.ToListAsync();
        }
    }
}
