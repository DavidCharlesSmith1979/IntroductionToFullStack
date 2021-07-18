using System.Threading.Tasks;
using Demo.Api.Models;

namespace Demo.Api.Services
{
    public interface IGetUserService
    {
        Task<User> Get(long id);
    }
}