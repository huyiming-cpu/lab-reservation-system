using System;
using System.Collections.Generic;
using LabReservationApp.Entity;
using LabReservationApp.DAO;
using LabReservationApp;

namespace LabManagementSystem.Service
{
    public class UserService
    {
        private UserDAO _userDAO = new UserDAO(); 

        
        public User Login(string username, string password)
        {
            var user = _userDAO.GetByUsername(username); 
            if (user == null || user.Password != password)
                throw new ArgumentException("用户名或密码错误");
                
            return user;
        }

        



        
        public List<User> GetTeacherList(int pageIndex, int pageSize)
        {
           
            return _userDAO.GetUserList(1, pageIndex, pageSize);
        }

        public bool SaveUser(User user)
        {
            try
            {
               
                return _userDAO.SaveUser(user);
            }
            catch (Exception ex)
            {
                
               
                return false;
            }
        }

        public User GetUserById(long id)
        {
            return _userDAO.GetById(id);
        }
    }
}