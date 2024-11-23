using System.ComponentModel.DataAnnotations.Schema;
using MANAGEMENT.MY.CV.BE.Domain.Models.Base;

namespace MANAGEMENT.MY.CV.BE.Domain.Models;

public sealed class Company : BaseModel
{
    [Column("name")]
    public string Name { get; set; } = null!;
    
    [Column("icon")]
    public string? Icon { get; set; }
    
    [Column("work_type")]
    public MyEnum.WorkType WorkType { get; set; }
    
    [Column("start_date")]
    public DateOnly StartDate { get; set; }
    
    [Column("end_date")]
    public DateOnly? EndDate { get; set; }

    [Column("person_id")]
    public Guid PersonId { get; set; }
    public Model.Person Person { get; set; } = null!;
    public HashSet<Model.WorkHistory>? WorkHistories { get; set; }
}