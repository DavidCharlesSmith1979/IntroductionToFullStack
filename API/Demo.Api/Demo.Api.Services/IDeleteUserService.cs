using System.Threading.Tasks;

namespace Demo.Api.Services
{
    public interface IDeleteUserService
    {
        Task<bool> Delete(long id);
    }
}