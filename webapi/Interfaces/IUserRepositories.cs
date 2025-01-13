namespace webapi.Repositories;

public interface IUserRepositories
{
    Task<string> AddNewUserAsync(User user);
    Task<string> ChangeUserAsync(User user);
    Task<string> DeleteUserAsync(Guid userId);
    Task<User> GetUserByIdAsync(Guid userId);
    Task<User> AuthenticationAsync(string login,string password);

}
