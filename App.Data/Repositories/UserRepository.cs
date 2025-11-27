using App.Data.Persistence;
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Domain.ViewModels.User;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Repositories
{
    public class UserRepository(AppDbContext context,IMapper mapper) : IUserRepository
    {
        public int CreateUserByAdmin(int adminId, CreateUserByAdmin create)
        {
            var user = mapper.Map<AppUser>(create);
            context.Add(user);
            context.SaveChanges();
            var adminLog = new AdminOperationLog
            {
                AdminId = adminId,
                UserId = user.Id
            };
            return user.Id;

        }

        public bool DeleteUserByAdmin(int adminId, DeleteUserByAdmin delete)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == delete.Id);
            if(user != null)
            {
                var adminLog = new AdminOperationLog
                {
                    AdminId = adminId,
                    UserId = user.Id
                };
                return context.Users.Where(u => u.Id == delete.Id).ExecuteUpdate(setters => setters.SetProperty((u => u.IsDelete), true)) > 0;
            }
            return false;
        }
        public bool Delete(int id)
        {
            return context.Users.Where(u=>u.Id == id).ExecuteUpdate(setters=>setters.SetProperty((u=>u.IsDelete),true)) > 0;
        }


        public int FindIdByUserName(string userName)
        {
            return context.Users.Where(u=>u.UserName == userName).Select(u=>u.Id).FirstOrDefault();
        }

        public List<GetUserViewModel> GetAll()
        {
            return mapper.Map<List<GetUserViewModel>>(context.Users.ToList());
        }

        public GetUserViewModel? GetUserById(int id)
        {
            return mapper.Map<GetUserViewModel>(context.Users.FirstOrDefault(u => u.Id == id));
        }

        public bool IsUserExist(string userName)
        {
            return context.Users.Any(u => u.UserName == userName);
        }

        public GetUserViewModel? Login(LoginUserViewModel login)
        {
            var user = context.Users.Where(u => u.UserName == login.UserName && u.Password == login.Password).FirstOrDefault();
            if(user != null)
            {
                if (login.RememberMe)
                    context.Users.Where(u => u.UserName == login.UserName)
                        .ExecuteUpdate(setters => setters.SetProperty((u => u.RememberMe), true));
                return mapper.Map<GetUserViewModel>(user);
            }
            return null;
        }

        public bool Register(RegisterUserViewModel register)
        {
            var user = mapper.Map<AppUser>(register);
            if (context.Users.Any(u => u.UserName == register.UserName))
                return false;
            context.Add(user);
            return context.SaveChanges() > 0;
        }

        public bool UpdatePassword(int id, UpdatePasswordUserViewModel model)
        {
            return context.Users.Where(u => u.Id == id)
                        .ExecuteUpdate(setters => setters.SetProperty((u => u.Password), model.Password)) > 0;
        }

        public bool UpdateRememberMe(int id, bool rememberMe)
        {
            return context.Users.Where(u => u.Id == id)
                        .ExecuteUpdate(setters => setters.SetProperty((u => u.RememberMe), rememberMe)) > 0;
        }

        public bool UpdateUserByAdmin(int adminId,int id,UpdateUserByAdminViewModel model)
        {
            var adminLog = new AdminOperationLog
            {
                AdminId = adminId,
                UserId = id
            };
            context.Add(adminLog);
           return context.Users.Where(u => u.Id == id)
                        .ExecuteUpdate(setters => setters
                        .SetProperty((u => u.UserName), model.UserName)
                        .SetProperty((u => u.Password), model.Password)
                        .SetProperty((u=>u.Role),model.Role)) > 0;
        }

        public List<UserInfoForAdmin> GetUserInfosForAdmin(int userId)
        {
            return mapper.Map<List<UserInfoForAdmin>>(context.Users.Where(u=>u.Id!=userId).Include(u=>u.WrittenPosts).Include(u=>u.VerifiednPosts).ToList());
        }
    }
}
