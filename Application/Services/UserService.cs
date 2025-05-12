using Application.Contract;
using Applications.DTOs;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDTO Register(User user)
        {
            var existingUser = _userRepository.GetAll()
                .FirstOrDefault(u => u.Username == user.Username || u.Email == user.Email);
            if (existingUser != null)
            {
                if (existingUser.Username == user.Username)
                    throw new Exception("Username is already taken.");
                if (existingUser.Email == user.Email)
                    throw new Exception("Email is already in use.");
            }

            user.Password = HashPassword(user.Password);
            user.DateCreated = DateTime.Now;
            user.IsActive = true;
            _userRepository.Create(user);
            _userRepository.SaveChanges();
            return user.Adapt<UserDTO>();
        }

        public UserDTO Login(string username, string password)
        {
            var user = _userRepository.GetAll()
                .FirstOrDefault(u => u.Username == username && u.IsActive);
            if (user == null || !VerifyPassword(password, user.Password))
                throw new Exception("Invalid username or password.");

            user.LastLoginDate = DateTime.Now;
            _userRepository.Update(user);
            _userRepository.SaveChanges();
            return user.Adapt<UserDTO>();
        }

        public UserDTO GetUserById(int userId)
        {
            var user = _userRepository.GetById(userId);
            return user?.Adapt<UserDTO>();
        }

        public UserDTO UpdateUser(User user)
        {
            var existingUser = _userRepository.GetById(user.UserID);
            if (existingUser == null)
                throw new Exception("User not found.");

            var usernameTaken = _userRepository.GetAll()
                .Any(u => u.Username == user.Username && u.UserID != user.UserID);
            if (usernameTaken)
                throw new Exception("Username is already taken.");

            var emailTaken = _userRepository.GetAll()
                .Any(u => u.Email == user.Email && u.UserID != user.UserID);
            if (emailTaken)
                throw new Exception("Email is already in use.");

            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            if (!string.IsNullOrEmpty(user.Password))
                existingUser.Password = HashPassword(user.Password);
            _userRepository.Update(existingUser);
            _userRepository.SaveChanges();
            return existingUser.Adapt<UserDTO>();
        }

        public List<UserDTO> GetAllClients()
        {
            return _userRepository.GetAll()
                .Where(u => u.Role == UserRole.Client)
                .ProjectToType<UserDTO>()
                .ToList();
        }

        public List<UserDTO> GetAllAdmins()
        {
            return _userRepository.GetAll()
                .Where(u => u.Role == UserRole.Admin)
                .ProjectToType<UserDTO>()
                .ToList();
        }

        public void ActivateUser(int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new Exception("User not found.");

            user.IsActive = true;
            _userRepository.Update(user);
            _userRepository.SaveChanges();
        }

        public void DeactivateUser(int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new Exception("User not found.");

            user.IsActive = false;
            _userRepository.Update(user);
            _userRepository.SaveChanges();
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            var hash = HashPassword(password);
            return hash == hashedPassword;
        }
    }
}