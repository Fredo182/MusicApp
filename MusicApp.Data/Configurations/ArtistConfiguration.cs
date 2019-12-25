using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Data.Domain;

namespace MusicApp.Data.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder
                .HasKey(a => a.ArtistId);

            builder
                .Property(a => a.ArtistId)
                .UseIdentityColumn();

            builder
                .Property(a => a.ArtistId)
                .ValueGeneratedOnAdd();

            builder
                .HasIndex(a => a.Name)
                .IsUnique();

            builder
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(a => a.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .Property(a => a.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(a => a.ConcurrencyStamp)
                .IsRequired()
                .IsRowVersion();

            builder
                .Property(a => a.ModifiedDateTime)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder
                .Property(a => a.CreatedDateTime)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder
                .ToTable("Artists");
        }
    }
}
