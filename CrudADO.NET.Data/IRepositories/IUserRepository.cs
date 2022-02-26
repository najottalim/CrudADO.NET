using CrudADO.NET.Domain;

namespace CrudADO.NET.Data.IRepositories
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);

        Task UpdateAsync(User user);

        Task DeleteAsync(int id);

        Task<IList<User>> GetAllAsync();

        Task<User> GetAsync(int id);
    }
}
