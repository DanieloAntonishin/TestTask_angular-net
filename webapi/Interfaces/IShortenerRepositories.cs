namespace webapi.Repositories;

public interface IShortenerRepositories
{
    Task<string> AddNewUrlAsync(ShortenerUrl sUrl);
    Task<string> ChangeUrlAsync(ShortenerUrl sUrl);
    Task<string> DeleteUrlAsync(Guid sUrlId);
    Task<string> DeleteAllUrlAsync();
    Task<List<ShortenerUrl>> GetUrlAsync();
    Task<List<ShortenerUrl>> GetUrlByUserIdAsync(Guid userId);
}
