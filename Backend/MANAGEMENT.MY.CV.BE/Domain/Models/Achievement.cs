using System.ComponentModel.DataAnnotations.Schema;
using MANAGEMENT.MY.CV.BE.Domain.Models.Base;

namespace MANAGEMENT.MY.CV.BE.Domain.Models;

public sealed class Achievement : BaseModel
{
    [Column("name")]
    public string Name { get; set; } = null!;
    
    [Column("type")]
    public MyEnum.AchievementType Type { get; set; }
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Column("result")]
    public string? Result { get; set; }
    
    [Column("start_date")]
    public DateOnly StartDate { get; set; }
    
    [Column("end_date")]
    public DateOnly? EndDate { get; set; }

    [Column("person_id")]
    public string PersonId { get; set; } = null!;
    public Model.Person Person { get; set; } = null!;
}