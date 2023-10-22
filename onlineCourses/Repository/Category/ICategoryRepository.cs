using onlineCourses.Models;

namespace onlineCourses.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Task<Category> GetById(int id);
        Task<List<Course>?> GetCategoryCourses(string categoryName);
        Task Create(Category category);
        Task Edit(Category category);
        Task Delete(Category category);
    }
}
