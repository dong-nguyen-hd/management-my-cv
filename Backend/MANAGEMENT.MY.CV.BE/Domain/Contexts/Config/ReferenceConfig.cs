using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MANAGEMENT.MY.CV.BE.Domain.Contexts.Config;

/// <summary>
/// Setting schema for Reference table
/// </summary>
public class ReferenceConfig : IEntityTypeConfiguration<Model.Reference>
{
    public void Configure(EntityTypeBuilder<Model.Reference> entity)
    {
        entity.ToTable("tbl_reference");

        entity.Property(x => x.CreatedDatetimeUtc).HasColumnType("timestamp without time zone");
        entity.Property(x => x.UpdatedDatetimeUtc).HasColumnType("timestamp without time zone");

        entity.HasKey(x => x.Id);
        entity.HasQueryFilter(x => x.Active);
    }
}