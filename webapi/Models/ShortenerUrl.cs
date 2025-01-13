using System.ComponentModel.DataAnnotations.Schema;

namespace webapi;

public class ShortenerUrl
{
    public Guid Id { get; set; }
    public string FullUrl { get; set; }
    public string ?ShortUrl { get; set; }
    public DateTime? CreatedDate { get; set; }=null;

    [ForeignKey("User")]
    public Guid UserId { get; set; }
}
