using System.ComponentModel.DataAnnotations.Schema;
using MANAGEMENT.MY.CV.BE.Domain.Models.Base;

namespace MANAGEMENT.MY.CV.BE.Domain.Models;

public sealed class Reference : BaseModel
{
    [Column("organization")]
    public string Organization { get; set; } = null!;
    
    [Column("full_name")]
    public string FullName { get; set; } = null!;
    
    [Column("position")]
    public string? Position { get; set; }
    
    [Column("email")]
    public string? Email { get; set; }
    
    [Column("phone")]
    public string? Phone { get; set; }

    [Column("person_id")]
    public string PersonId { get; set; } = null!;
    public Model.Person Person { get; set; } = null!;
}