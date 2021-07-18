using System.Threading.Tasks;
using Demo.Api.Models;

namespace Demo.Api.Services
{
    public interface IUpdateUserService
    {
        Task<bool> Update(User user);
    }
}