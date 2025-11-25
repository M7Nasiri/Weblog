using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        List<Category> GetAll(int userId);
        Category? Get(int categoryId);
        bool Create(Category category);
        bool Update(int id, Category category);
        bool Delete(int id,int userId);
    }
}
