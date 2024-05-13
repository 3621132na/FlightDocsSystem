using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagementService.Models;

namespace UserManagementService;

public class UserServiceImpl: IUserService
{
    private readonly UserDbContext _dbContext;
    private readonly IConfiguration _configuration;
    //private readonly PasswordHasher<User> _passwordHasher;

    public UserServiceImpl(UserDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
        //_passwordHasher = new PasswordHasher<User>();
    }

    public async Task<User> RegisterUserAsync(User user, string password)
    {
        var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == user.Username);
        if (existingUser != null)
            throw new Exception("Username is already taken.");
        if (!IsEmailInVietjetDomain(user.Email))
            throw new Exception("Email must belong to @vietjetair.com domain.");
        //user.Password = _passwordHasher.HashPassword(user, password);
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }
    private bool IsEmailInVietjetDomain(string email)
    {
        return !string.IsNullOrEmpty(email) && email.Trim().ToLower().EndsWith("@vietjetair.com");
    }
    public async Task<User> LoginAsync(string username, string password)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (user == null)
            throw new Exception("Invalid username or password.");
        //var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
        if (!(user.Username==username&&user.Password==password))
            throw new Exception("Invalid username or password.");
        return user;
    }
}