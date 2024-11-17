using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MANAGEMENT.MY.CV.BE.Domain.Contexts.Config;

/// <summary>
/// Setting schema for Token table
/// </summary>
public class TokenConfig : IEntityTypeConfiguration<Model.Token>
{
    public void Configure(EntityTypeBuilder<Model.Token> entity)
    {
        entity.ToTable("tbl_token");

        entity.Property(x => x.CreatedDatetimeUtc).HasColumnType("timestamp without time zone");
        entity.Property(x => x.UpdatedDatetimeUtc).HasColumnType("timestamp without time zone");
        entity.Property(x => x.ExpiredDatetimeUtc).HasColumnType("timestamp without time zone");

        entity.HasKey(x => x.Id);
        entity.HasQueryFilter(x => x.Active);
    }
}