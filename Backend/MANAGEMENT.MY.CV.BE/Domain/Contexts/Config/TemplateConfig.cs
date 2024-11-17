using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MANAGEMENT.MY.CV.BE.Domain.Contexts.Config;

/// <summary>
/// Setting schema for Template table
/// </summary>
public class TemplateConfig : IEntityTypeConfiguration<Model.Template>
{
    public void Configure(EntityTypeBuilder<Model.Template> entity)
    {
        entity.ToTable("tbl_template");

        entity.Property(x => x.CreatedDatetimeUtc).HasColumnType("timestamp without time zone");
        entity.Property(x => x.UpdatedDatetimeUtc).HasColumnType("timestamp without time zone");

        entity.HasKey(x => x.Id);
        entity.HasQueryFilter(x => x.Active);

        // Indexing
        entity.HasIndex(x => new { x.QueryTerm, x.Weight, x.Active })
            .IncludeProperties(x =>
                new
                {
                    x.Id,
                    x.CategoryId
                });
    }
}