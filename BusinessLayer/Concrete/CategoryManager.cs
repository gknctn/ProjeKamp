using BusinessLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        EfCategoryRepository efCategoryRepository;
        public CategoryManager()
        {
            efCategoryRepository = new EfCategoryRepository();
        }

        public void CategoryAdd(Category category)
        {
            efCategoryRepository.Insert(category);
        }

        public void CategoryRemove(Category category)
        {
            efCategoryRepository.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            efCategoryRepository.Update(category);
        }

        public List<Category> GetAllCategories()
        {
            return efCategoryRepository.GetListAll();
        }

        public Category GetCategory(Guid id)
        {
            return efCategoryRepository.getById(id);
        }
    }
}
