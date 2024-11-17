using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace MANAGEMENT.MY.CV.BE.Domain.Contexts;

public class CoreContext(DbContextOptions<CoreContext> options) : DbContext(options)
{
    #region Properties

    public DbSet<Model.Account> Accounts { get; set; }
    public DbSet<Model.Achievement> Achievements { get; set; }
    public DbSet<Model.Category> Categories { get; set; }
    public DbSet<Model.Company> Companies { get; set; }
    public DbSet<Model.Keyword> Keywords { get; set; }
    public DbSet<Model.Person> People { get; set; }
    public DbSet<Model.Reference> References { get; set; }
    public DbSet<Model.SocialNetwork> SocialNetworks { get; set; }
    public DbSet<Model.Template> Templates { get; set; }
    public DbSet<Model.TemplateInstance> TemplateInstances { get; set; }
    public DbSet<Model.Token> Tokens { get; set; }
    public DbSet<Model.WorkHistory> WorkHistories { get; set; }

    #endregion

    #region Method

    // Use Fluent API
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Finds and runs all your configuration classes in the same assembly as the DbContext
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    #endregion
}