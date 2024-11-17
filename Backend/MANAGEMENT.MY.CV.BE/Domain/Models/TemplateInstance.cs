using System.ComponentModel.DataAnnotations.Schema;
using MANAGEMENT.MY.CV.BE.Domain.Models.Base;
using MANAGEMENT.MY.CV.BE.Domain.Models.ToJson;

namespace MANAGEMENT.MY.CV.BE.Domain.Models;

public sealed class TemplateInstance : BaseModel
{
    [Column("name")]
    public string Name { get; set; } = null!;
    
    [Column("thumbnail")]
    public string? Thumbnail { get; set; }
    
    [Column("data")]
    public TemplateData? Data { get; set; }
    
    [Column("person_id")]
    public string PersonId { get; set; } = null!;
    public Model.Person Person { get; set; } = null!;
    
    [Column("template_id")]
    public string TemplateId { get; set; } = null!;
    public Model.Template Template { get; set; } = null!;
}