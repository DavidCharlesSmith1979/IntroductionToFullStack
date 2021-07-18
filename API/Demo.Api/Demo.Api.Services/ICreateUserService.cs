using System.Threading.Tasks;
using Demo.Api.Models;

namespace Demo.Api.Services
{
    public interface ICreateUserService
    {
        Task<bool> Create(User user);
    }
}