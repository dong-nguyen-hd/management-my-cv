using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MANAGEMENT.MY.CV.BE.Domain.Contexts.Config;

/// <summary>
/// Setting schema for Person table
/// </summary>
public class PersonConfig : IEntityTypeConfiguration<Model.Person>
{
    public void Configure(EntityTypeBuilder<Model.Person> entity)
    {
        entity.ToTable("tbl_person");

        entity.Property(x => x.CreatedDatetimeUtc).HasColumnType("timestamp without time zone");
        entity.Property(x => x.UpdatedDatetimeUtc).HasColumnType("timestamp without time zone");

        entity.HasKey(x => x.Id);
        entity.HasQueryFilter(x => x.Active);
    }
}