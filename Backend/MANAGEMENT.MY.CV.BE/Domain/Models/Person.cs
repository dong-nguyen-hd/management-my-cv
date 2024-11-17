using System.ComponentModel.DataAnnotations.Schema;
using MANAGEMENT.MY.CV.BE.Domain.Models.Base;

namespace MANAGEMENT.MY.CV.BE.Domain.Models;

public sealed class Person : BaseModel
{
    [Column("first_name")]
    public string FirstName { get; set; } = null!;
    
    [Column("last_name")]
    public string LastName { get; set; } = null!;
    
    [Column("avatar")]
    public string? Avatar { get; set; }
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Column("address")]
    public string? Address { get; set; }
    
    [Column("phone")]
    public string? Phone { get; set; }
    
    [Column("date_of_birth")]
    public DateOnly DateOfBirth { get; set; }
    
    [Column("gender")]
    public MyEnum.Gender Gender { get; set; }

    [Column("account_id")]
    public string AccountId { get; set; } = null!;
    public HashSet<Model.Company>? Companies { get; set; }
    public HashSet<Model.TemplateInstance>? TemplateInstances { get; set; }
    public HashSet<Model.Reference>? References { get; set; }
    public HashSet<Model.SocialNetwork>? SocialNetworks { get; set; }
    public HashSet<Model.Achievement>? Achievements { get; set; }
}