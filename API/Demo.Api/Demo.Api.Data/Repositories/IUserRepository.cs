using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Api.Data
{
    public interface IUserRepository
    {
        Task<bool> Create(User user);
        Task<bool> Delete(long id);
        Task<List<User>> Get();
        Task<User> Get(long id);
        Task<bool> Update(User user);
    }
}