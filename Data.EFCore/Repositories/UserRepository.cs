using Data.EFCore.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Data.EFCore.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository, IDisposable
    {
        public UserRepository(KUSYSContext context) : base(context)
        {
        }

        public async Task<User?> GetUserAsync(string username, string password)
        {
            return await FirstOrDefault(f => f.Username == username && f.Password == password);
        }
    }
}