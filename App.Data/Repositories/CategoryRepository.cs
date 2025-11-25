using App.Data.Persistence;
using App.Domain.Entities;
using App.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Repositories
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {
        public bool Create(Category category)
        {
            context.Add(category);
            return context.SaveChanges() > 0;
        }

        public bool Delete(int id,int userId)
        {
            var category = context.Categories.Include(c=>c.Posts).Where(c => c.Id == id).FirstOrDefault();
            if (category != null && category.Posts.Count() == 0  && category.UserId == userId)
                return context.Categories.Where(c => c.Id == id).
                    ExecuteUpdate(setters => setters.SetProperty((c => c.IsDelete), true)) > 0;
            return false;
        }

        public Category? Get(int categoryId)
        {
            return context.Categories.FirstOrDefault(c => c.Id == categoryId);
        }

        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public List<Category> GetAll(int userId)
        {
            return context.Categories.Where(u => u.UserId == userId).ToList();
        }

        public bool Update(int id, Category category)
        {
            return context.Categories.Where(c => c.Id == id)
                .ExecuteUpdate(setters => setters
                .SetProperty((c => c.Title), category.Title)
            .SetProperty((c => c.Description), category.Description)) > 0;
        }
    }
}
