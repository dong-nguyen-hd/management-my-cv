using System.ComponentModel.DataAnnotations.Schema;
using MANAGEMENT.MY.CV.BE.Domain.Models.Base;

namespace MANAGEMENT.MY.CV.BE.Domain.Models;

public sealed class Keyword : BaseModel
{
    [Column("name")]
    public string Name { get; set; } = null!;
    
    [Column("query_term")]
    public string QueryTerm { get; set; } = null!;
    
    [Column("weight")]
    public float Weight { get; set; }

    [Column("category_id")]
    public string CategoryId { get; set; } = null!;
    public Model.Category Category { get; set; } = null!;
}