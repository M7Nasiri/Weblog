using App.Application.Interfaces;
using App.Domain.Interfaces;
using App.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace App.Application.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public int CreateUserByAdmin(int adminId, CreateUserByAdmin create)
        {
            return userRepository.CreateUserByAdmin(adminId, create);
        }

        public bool Delete(int id)
        {
            return userRepository.Delete(id);
        }

        public bool DeleteUserByAdmin(int adminId, DeleteUserByAdmin delete)
        {
            return userRepository.DeleteUserByAdmin(adminId,delete);
        }

        public int FindIdByUserName(string userName)
        {
            return userRepository.FindIdByUserName(userName);
        }

        public List<GetUserViewModel> GetAll()
        {
            return userRepository.GetAll();
        }

        public GetUserViewModel? GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }

        public bool IsUserExist(string userName)
        {
            return userRepository.IsUserExist(userName);    
        }

        public GetUserViewModel? Login(LoginUserViewModel login)
        {
            return userRepository.Login(login);
        }

        public bool Register(RegisterUserViewModel register)
        {
            return userRepository.Register(register);
        }

        public bool UpdatePassword(int id, UpdatePasswordUserViewModel model)
        {
            return userRepository.UpdatePassword(id,model);
        }

        public bool UpdateRememberMe(int id, bool rememberMe)
        {
            return userRepository.UpdateRememberMe(id, rememberMe);
        }

        public bool UpdateUserByAdmin(int adminId, int id, UpdateUserByAdminViewModel model)
        {
            return userRepository.UpdateUserByAdmin(adminId,id,model);  
        }
    }
}
