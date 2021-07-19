using System.Threading.Tasks;
using Demo.Api.Models;

namespace Demo.Api.Services
{
    public interface ICreateUserService
    {
        Task<User> Create(User user);
    }
}