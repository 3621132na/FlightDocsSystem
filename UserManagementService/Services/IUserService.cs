using UserManagementService.Models;

namespace UserManagementService;

public interface IUserService
{
    Task<User> RegisterUserAsync(User user, string password);
    Task<User> LoginAsync(string username, string password);
}