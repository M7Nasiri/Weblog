using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category? Get(int categoryId);
        bool Create(Category category);
        bool Update(int id, Category category);
        bool Delete(int id,int userId);
        List<Category> GetAll(int userId);
    }
}
