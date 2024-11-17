using System.ComponentModel.DataAnnotations.Schema;
using MANAGEMENT.MY.CV.BE.Domain.Models.Base;

namespace MANAGEMENT.MY.CV.BE.Domain.Models;

public sealed class WorkHistory :BaseModel
{
    [Column("name")]
    public string Name { get; set; } = null!;
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Column("required_skills")]
    public string? RequiredSkills { get; set; }
    
    [Column("team_size")]
    public short? TeamSize { get; set; }
    
    [Column("position")]
    public string? Position { get; set; }
    
    [Column("responsibilities")]
    public string? Responsibilities { get; set; }
    
    [Column("start_date")]
    public DateOnly StartDate { get; set; }
    
    [Column("end_date")]
    public DateOnly? EndDate { get; set; }
    
    [Column("company_id")]
    public string CompanyId { get; set; } = null!;
    public Model.Company Company { get; set; } = null!;
}