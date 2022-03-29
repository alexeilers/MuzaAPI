using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Muza.Data;
using Muza.Data.Entities;
using Muza.Models.User;

namespace Muza.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        //Create
        public async Task<bool> RegisterUserAsync(UserRegister model)
        {
            //Check for Duplicate Username/Email
            if(await GetUserByEmailAsync(model.Email) !=null || GetUserByUsernameAsync(model.Username) !=null)
            {
                return false;
            }

            var user = new UserEntity
            {
                Email = model.Email,
                Username = model.Username,
                DateCreated = DateTime.Now

            };

            var passwordHasher = new PasswordHasher<UserEntity>();
            user.Password = passwordHasher.HashPassword(user, model.Password);

            _context.Users.Add(user);
            var numberofChanges = await _context.SaveChangesAsync();

            return numberofChanges == 1;
        }
        //Read
        public async Task<UserDetail> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if(user is null)
            {
                return null;
            }

            var userDetail = new UserDetail{
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                DateCreated = user.DateCreated
            };

            return userDetail;
        }

        //Delete
        public async Task<bool> DeleteUserAsync(int userId)
        {
            //Find user by Id
            var user = await _context.Users.FindAsync(userId);

            //Delete the user
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync() == 1;
        }

        //Helper Methods
        private async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email.ToLower() == email.ToLower());
        }

        private async Task<UserEntity> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Username.ToLower() == username.ToLower());
        }
    }
}