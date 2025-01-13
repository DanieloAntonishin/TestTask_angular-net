using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;

namespace webapi.Repositories;

public class UserRepositories : IUserRepositories
{
    private MySqlDbContext _context { get; set; }
    public UserRepositories(MySqlDbContext context)              // DBcontext init
    {
        _context = context;
    }
    public async Task<string> AddNewUserAsync(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        try
        {
            await _context.UserEntities.AddAsync(user);        // Add new entity to Set
            _context.SaveChanges();
            return user.Id.ToString();
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<string> ChangeUserAsync(User user)
    {
        if (user.Id == Guid.Empty)
        {
            throw new ArgumentNullException();
        }
        else if(_context.UserEntities.Select(u=>u.Login==user.Login).FirstOrDefault())
        {
            throw new Exception("Login allready picked");
        }
        var s = _context.UserEntities.Where(u => u.Id == user.Id).FirstOrDefault();    // Get and change info for hall
        s.Login = user.Login;
        s.Password = user.Password;
        await _context.SaveChangesAsync();
        return "Updated";
    }

    public async Task<string> DeleteUserAsync(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentNullException();
        }
        var s = await _context.UserEntities.Where(u => u.Id == userId).FirstOrDefaultAsync();   // Find and remove information
        _context.UserEntities.Remove(s);
        _context.SaveChanges();
        return "Deleted succesfully";
    }

    public async Task<User> GetUserByIdAsync(Guid userId)
    {
        var s = await _context.UserEntities.Where(u => u.Id == userId).FirstOrDefaultAsync();  
        return s;
    }
    public async Task<User> AuthenticationAsync(string login,string password)
    {
        var s = await _context.UserEntities.Where(u => u.Login == login && u.Password == password).FirstOrDefaultAsync();
        return s;
    }
}
