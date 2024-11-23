using System.ComponentModel.DataAnnotations.Schema;
using MANAGEMENT.MY.CV.BE.Domain.Models.Base;

namespace MANAGEMENT.MY.CV.BE.Domain.Models;

public sealed class Template : BaseModel
{
    [Column("name")]
    public string Name { get; set; } = null!;
    
    [Column("query_term")]
    public string QueryTerm { get; set; } = null!;
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Column("thumbnail")]
    public string? Thumbnail { get; set; }
    
    [Column("key")]
    public string Key { get; set; } = null!;
    
    [Column("weight")]
    public float Weight { get; set; }
    
    [Column("category_id")]
    public Guid CategoryId { get; set; }
    public Model.Category Category { get; set; } = null!;
    public HashSet<Model.TemplateInstance>? TemplateInstances { get; set; }
}