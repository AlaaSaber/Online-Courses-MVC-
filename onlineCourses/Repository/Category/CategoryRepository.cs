using Microsoft.EntityFrameworkCore;
using onlineCourses.Models;

namespace onlineCourses.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DBContext _dbContext;
        public CategoryRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Category> GetAll()
        {
            return  _dbContext.Categories.AsNoTracking().ToList();
        }

        public async Task<Category> GetById(int id)
        {
            Category category = await _dbContext.Categories.SingleOrDefaultAsync(c => c.Id == id);

            return category;
        }

        public async Task<List<Course>?> GetCategoryCourses(string categoryName)
        {
            var category = await _dbContext.Categories.SingleOrDefaultAsync(c => c.Name.Equals(categoryName));
            if(category == null)
            {
                return null;
            }

            var courses = await _dbContext.Courses
                .Where(c => c.cat_id == category.Id)
                .ToListAsync();

            return courses;
        }
        public async Task Create(Category category)
        {
            _dbContext.Categories.Add(category);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Edit(Category category)
        {
            _dbContext.Categories.Update(category);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Category category)
        {
            _dbContext.Categories.Remove(category);

            await _dbContext.SaveChangesAsync();
        }
    }
}
