using System.Collections.Generic;
using Backend.DAO.Interface;
using Backend.Models;
using Backend.Utils;
using System.Linq;

namespace Backend.DAO
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DBContext DBContext;

        public CategoryRepository(DBContext dBContext)
        {
            this.DBContext = dBContext;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = this.DBContext.Category.ToList();
            return categories;
        }
        public Category GetCategory(string categoryId)
        {
            Category category = this.DBContext.Category.Find(categoryId);
            return category;
        }

        public Category GetCategoryByCategoryName(string name)
        {
            Category category = this.DBContext.Category.FirstOrDefault(item => item.Name == name);
            return category;
        }
        public Category GetCategoryByCategoryId(string categoryId)
        {
            Category category = this.DBContext.Category.FirstOrDefault(item => item.CategoryId == categoryId);
            return category;
        }

        public bool CreateCategoryHandler(Category category)
        {
            this.DBContext.Category.Add(category);
            return this.DBContext.SaveChanges() > 0;
        }

        public bool UpdateCategoryHandler(Category category)
        {
            this.DBContext.Category.Update(category);
            return this.DBContext.SaveChanges() > 0;
        }
        public (List<Category>, int) GetAllCategoriesWithStatus(int pageIndex, int pageSize, string searchName, CategoryStatus searchStatus)
        {
            IEnumerable<Category> list = null;
            if (searchStatus == 0)
            {
                list = this.GetCategories().Where(item => item.Name.Contains(searchName));
            }
            else
            {
                list = this.GetCategories().Where(item => item.Name.Contains(searchName) && item.Status == searchStatus);
            }


            var count = list.Count();


            var pagelist = (List<Category>)list.Take((pageIndex + 1) * pageSize).Skip(pageIndex * pageSize).ToList();

            return (pagelist, count);
        }
    }
}