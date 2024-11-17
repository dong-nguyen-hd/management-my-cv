using System.ComponentModel.DataAnnotations.Schema;
using MANAGEMENT.MY.CV.BE.Domain.Models.Base;

namespace MANAGEMENT.MY.CV.BE.Domain.Models;

public sealed class SocialNetwork : BaseModel
{
    [Column("code")]
    public MyEnum.SocialNetwork Code { get; set; }
    
    [Column("value")]
    public string Value { get; set; } = null!;
    
    [Column("icon")]
    public string? Icon { get; set; }
    
    [Column("person_id")]
    public string PersonId { get; set; } = null!;
    public Model.Person Person { get; set; } = null!;
}