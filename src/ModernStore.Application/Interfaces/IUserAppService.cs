using ModernStore.Application.ViewModels;
using System.Threading.Tasks;

namespace ModernStore.Application.Interfaces
{
    public interface IUserAppService
    {
        AuthenticateUserViewModel AuthenticatedUser(string userName, string password);
    }
}
