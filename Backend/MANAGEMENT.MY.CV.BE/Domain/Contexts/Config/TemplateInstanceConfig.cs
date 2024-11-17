using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MANAGEMENT.MY.CV.BE.Domain.Contexts.Config;

/// <summary>
/// Setting schema for TemplateInstance table
/// </summary>
public class TemplateInstanceConfig : IEntityTypeConfiguration<Model.TemplateInstance>
{
    public void Configure(EntityTypeBuilder<Model.TemplateInstance> entity)
    {
        entity.ToTable("tbl_template_instance");

        entity.Property(x => x.CreatedDatetimeUtc).HasColumnType("timestamp without time zone");
        entity.Property(x => x.UpdatedDatetimeUtc).HasColumnType("timestamp without time zone");

        entity.HasKey(x => x.Id);
        entity.HasQueryFilter(x => x.Active);

        entity.OwnsOne(c => c.Data, d => d.ToJson());
    }
}