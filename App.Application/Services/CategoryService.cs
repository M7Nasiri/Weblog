using App.Application.Interfaces;
using App.Domain.Entities;
using App.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Services
{
    public class CategoryService(ICategoryRepository categoryRepo) : ICategoryService
    {
        public bool Create(Category category)
        {
            return categoryRepo.Create(category);
        }

        public bool Delete(int id,int userId)
        {
            return categoryRepo.Delete(id,userId);
        }

        public Category? Get(int categoryId)
        {
            return categoryRepo.Get(categoryId);
        }

        public List<Category> GetAll()
        {
            return categoryRepo.GetAll();
        }

        public List<Category> GetAll(int userId)
        {
            return categoryRepo.GetAll(userId);
        }

        public bool Update(int id, Category category)
        {
            return categoryRepo.Update(id, category);
        }
    }
}
