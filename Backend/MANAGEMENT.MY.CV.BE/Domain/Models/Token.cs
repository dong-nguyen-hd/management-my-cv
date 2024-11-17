using System.ComponentModel.DataAnnotations.Schema;
using MANAGEMENT.MY.CV.BE.Domain.Models.Base;

namespace MANAGEMENT.MY.CV.BE.Domain.Models;

public sealed class Token : BaseModel
{
    [Column("refresh_token")]
    public string RefreshToken { get; set; } = null!;
    
    [Column("is_used")]
    public bool IsUsed { get; set; }
    
    [Column("expired_datetime_utc")]
    public DateTime ExpiredDatetimeUtc { get; set; }
    
    [Column("user_agent")]
    public string? UserAgent { get; set; }
    
    [Column("account_id")]
    public string AccountId { get; set; } = null!;
    public Model.Account Account { get; set; } = null!;
}