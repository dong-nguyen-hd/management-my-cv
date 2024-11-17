using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MANAGEMENT.MY.CV.BE.Domain.Contexts.Config;

/// <summary>
/// Setting schema for Category table
/// </summary>
public class CategoryConfig : IEntityTypeConfiguration<Model.Category>
{
    public void Configure(EntityTypeBuilder<Model.Category> entity)
    {
        entity.ToTable("tbl_category");

        entity.Property(x => x.CreatedDatetimeUtc).HasColumnType("timestamp without time zone");
        entity.Property(x => x.UpdatedDatetimeUtc).HasColumnType("timestamp without time zone");

        entity.HasKey(x => x.Id);
        entity.HasQueryFilter(x => x.Active);
    }
}