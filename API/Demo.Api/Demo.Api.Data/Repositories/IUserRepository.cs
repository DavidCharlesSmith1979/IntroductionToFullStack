using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Api.Data
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<bool> Delete(long id);
        Task<List<User>> Get();
        Task<User> Get(long id);
        Task<User> Update(User user);
    }
}