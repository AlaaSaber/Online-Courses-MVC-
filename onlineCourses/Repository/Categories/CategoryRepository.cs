using Microsoft.EntityFrameworkCore;
using System.Linq;
using onlineCourses.Repository.Categories;
using onlineCourses.Models;

namespace onlineCategorys.Repository.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private DBContext dBContext;

        public CategoryRepository(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public void AddCategory(Category category)
        {
            dBContext.Add(category);
        }

        public void DeleteCategory(Category category)
        {
            dBContext.Remove(category);
        }

        public List<Category> getAllCategorys()
        {
            return dBContext.Categories.ToList();
        }

        public Category getCategoryByID(int ID)
        {
            return dBContext.Categories.FirstOrDefault(c=>c.Id == ID);
        }

        public int saveDB()
        {
            return dBContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            dBContext.Update(category);
        }
    }
}
