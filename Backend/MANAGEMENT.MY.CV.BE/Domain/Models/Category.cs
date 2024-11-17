using System.ComponentModel.DataAnnotations.Schema;
using MANAGEMENT.MY.CV.BE.Domain.Models.Base;

namespace MANAGEMENT.MY.CV.BE.Domain.Models;

public sealed class Category : BaseModel
{
    [Column("name")]
    public string Name { get; set; } = null!;
    
    [Column("description")]
    public string? Description { get; set; }

    public HashSet<Model.Keyword>? Keywords { get; set; }
    public HashSet<Model.Template>? Templates { get; set; }
}