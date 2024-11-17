using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MANAGEMENT.MY.CV.BE.Domain.Contexts.Config;

/// <summary>
/// Setting schema for SocialNetwork table
/// </summary>
public class SocialNetworkConfig : IEntityTypeConfiguration<Model.SocialNetwork>
{
    public void Configure(EntityTypeBuilder<Model.SocialNetwork> entity)
    {
        entity.ToTable("tbl_social_network");

        entity.Property(x => x.CreatedDatetimeUtc).HasColumnType("timestamp without time zone");
        entity.Property(x => x.UpdatedDatetimeUtc).HasColumnType("timestamp without time zone");

        entity.HasKey(x => x.Id);
        entity.HasQueryFilter(x => x.Active);
    }
}