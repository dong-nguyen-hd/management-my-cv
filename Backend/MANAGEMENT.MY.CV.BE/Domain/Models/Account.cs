using System.ComponentModel.DataAnnotations.Schema;
using MANAGEMENT.MY.CV.BE.Domain.Models.Base;

namespace MANAGEMENT.MY.CV.BE.Domain.Models;

public sealed class Account : BaseModel
{
    [Column("user_name")]
    public string UserName { get; set; } = null!;
    
    [Column("password")]
    public string Password { get; set; } = null!;
    
    [Column("name")]
    public string Name { get; set; } = null!;
    
    [Column("avatar")]
    public string? Avatar { get; set; }
    
    [Column("email")]
    public string? Email { get; set; }
    
    [Column("system_roles")]
    public List<string> SystemRoles { get; set; } = null!;

    public HashSet<Model.Token>? Tokens { get; set; }
}