using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

namespace webapi.Repositories;

public class ShortenerRepositories : IShortenerRepositories
{
    private MySqlDbContext _context { get; set; }

    public ShortenerRepositories(MySqlDbContext context)              // DBcontext init
    {
        _context = context;
    }
    public async Task<string> AddNewUrlAsync(ShortenerUrl sUrl)
    {
        if (sUrl == null)
        {
            throw new ArgumentNullException(nameof(sUrl));
        }
        try
        {
            sUrl.ShortUrl = ConvertUrl(sUrl.FullUrl);
            sUrl.Id=Guid.NewGuid();
            sUrl.CreatedDate = DateTime.Now;

            await _context.ShortenerUrlEntities.AddAsync(sUrl);        // Add new entity to Set
            var u = await _context.UserEntities.Where(x => x.Id == sUrl.UserId).FirstOrDefaultAsync();
            u.ShortenerUrls.Add(sUrl);
            _context.SaveChanges();
            return sUrl.Id.ToString();
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<string> ChangeUrlAsync(ShortenerUrl sUrl)
    {
        if (sUrl.Id == Guid.Empty)
        {
            throw new ArgumentNullException();
        }
        var s = _context.ShortenerUrlEntities.Where(u => u.Id == sUrl.Id).FirstOrDefault();    // Get and change info for hall
        s.FullUrl = sUrl.FullUrl;
        s.ShortUrl = ConvertUrl(sUrl.FullUrl); 
        await _context.SaveChangesAsync();
        return "Updated";
    }

    public async Task<string> DeleteUrlAsync(Guid sUrlId)
    {
        if (sUrlId == Guid.Empty)
        {
            throw new ArgumentNullException();
        }
        var s = _context.ShortenerUrlEntities.Where(u => u.Id == sUrlId).FirstOrDefault();   // Find and remove information
        _context.ShortenerUrlEntities.Remove(s);
        _context.SaveChanges();
        return "Deleted succesfully";
    }
    public async Task<string> DeleteAllUrlAsync()
    {
        var s = await _context.ShortenerUrlEntities.ToListAsync();
        _context.ShortenerUrlEntities.RemoveRange(s);
        _context.SaveChanges();
        return "Deleted succesfully";
    }
    public async Task<List<ShortenerUrl>> GetUrlAsync()
    {
        var s = await _context.ShortenerUrlEntities.ToListAsync();
        return s;
    }
    public async Task<List<ShortenerUrl>> GetUrlByUserIdAsync(Guid userId)
    {
        var s = await _context.ShortenerUrlEntities.Where(u=>u.UserId== userId).ToListAsync();
        return s;
    }

    private string ConvertUrl(string fullUrl)
    {
        var hashCode = String.Format("{0:X}", fullUrl.GetHashCode());
        return hashCode;
    }
}
