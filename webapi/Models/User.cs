namespace webapi;

public class User
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public short Role { get; set; }
    public virtual ICollection<ShortenerUrl> ShortenerUrls { get; } = new List<ShortenerUrl>();

}
