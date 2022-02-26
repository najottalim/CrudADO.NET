using CrudADO.NET.Data.IRepositories;
using CrudADO.NET.Domain;
using GenericCrudADO.NET.Data;

namespace CrudADO.NET.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DbContext dbContext;
        public UserRepository()
        {
            dbContext = new DbContext();
        }
        public async Task CreateAsync(User user)
        {
            await dbContext.ConnectionAsync($"INSERT INTO users (firstname, lastname, birthday, address, phone_number, email) " +
                $"VALUES ('{user.FirstName}', '{user.LastName}', '{user.Birthday}', '{user.Address}', '{user.PhoneNumber}', '{user.Email},)");
        }

        public async Task DeleteAsync(int id)
        {
            await dbContext.ConnectionAsync($"DELETE FROM users WHERE id = {id};");
        }

        public async Task<IList<User>> GetAllAsync()
        {
            IList<User> users = new List<User>();
            var reader = await dbContext.ConnectionAsync("SELECT * FROM users;");

            while (reader.Read())
            {
                users.Add(new User
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Birthday = reader.GetDateTime(3),
                    Address = reader.GetString(4),
                    PhoneNumber = reader.GetString(5),
                    Email = reader.GetString(6)
                });
            }

            return users;
        }

        public async Task<User> GetAsync(int id)
        {
            User user = new User();

            var reader = await dbContext.ConnectionAsync($"SELECT * FROM users WHERE id = {id};");

            while (reader.Read())
            {
                user.Id = reader.GetInt32(0);
                user.FirstName = reader.GetString(1);
                user.LastName = reader.GetString(2);
                user.Birthday = reader.GetDateTime(3);
                user.Address = reader.GetString(4);
                user.PhoneNumber = reader.GetString(5);
                user.Email = reader.GetString(6);
            }

            return user;
        }

        public async Task UpdateAsync(User user)
        {
            await dbContext.ConnectionAsync($"ALTER TABLE users SET " +
                $"firstname = '{user.FirstName}', " +
                $"lastname = '{user.LastName}', " +
                $"birthday = '{user.Birthday}', " +
                $"address = '{user.Address}', " +
                $"phone_number = '{user.PhoneNumber}', " +
                $"email = '{user.Email}' WHERE id = {user.Id};");
        }
    }
}
