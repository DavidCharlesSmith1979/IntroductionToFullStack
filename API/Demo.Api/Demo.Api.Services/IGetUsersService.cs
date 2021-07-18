using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Api.Models;

namespace Demo.Api.Services
{
    public interface IGetUsersService
    {
        Task<List<User>> Get();
    }
}