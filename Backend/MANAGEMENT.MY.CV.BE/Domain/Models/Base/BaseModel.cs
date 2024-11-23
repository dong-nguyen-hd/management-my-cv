using System.ComponentModel.DataAnnotations.Schema;

namespace MANAGEMENT.MY.CV.BE.Domain.Models.Base;

public abstract class BaseModel
{
    [Column("id")]
    public Guid Id { get; set; } = Guid.CreateVersion7();
    
    [Column("active")]
    public bool Active { get; set; }
    
    [Column("created_datetime_utc")]
    public DateTime CreatedDatetimeUtc { get; set; }
    
    [Column("updated_datetime_utc")]
    public DateTime UpdatedDatetimeUtc { get; set; }
}