using Domain.Entities;

namespace Domain.Interfaces.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetUserAsync(string username, string password);
    }
}