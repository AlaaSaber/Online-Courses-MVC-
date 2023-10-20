using onlineCourses.Models;

namespace onlineCourses.Repository.Categories
{
    public interface ICategoryRepository
    {
        List<Category> getAllCategorys ();
        Category getCategoryByID (int ID);
        void UpdateCategory (Category category);
        void DeleteCategory (Category category);
        void AddCategory (Category category);
        int saveDB ();
    }
}
