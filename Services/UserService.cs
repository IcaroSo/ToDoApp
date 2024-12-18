using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoApplication.Models;

namespace ToDoApplication.Services
{
    public class UserService
    {
        public User? User { get; set; }

        public DatabaseContext DatabaseContext { get; set; }

        
        public UserService(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public async Task<User> RegisterUser(User user)
        {
            var existingUser = await DatabaseContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if (existingUser != null)
                throw new InvalidOperationException("User with this email is already registered");

            user.Password = PasswordHash(user.Password);

            ToDo toDo = new ToDo(user);

            user.ToDoList = toDo;

            var userRegistered = user;

            DatabaseContext.ToDo.Add(toDo);
            DatabaseContext.Users.Add(userRegistered);
            await DatabaseContext.SaveChangesAsync();

            return userRegistered;
        }

        public string PasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }
    }
}
