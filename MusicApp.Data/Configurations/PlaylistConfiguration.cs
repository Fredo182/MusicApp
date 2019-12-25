using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Data.Domain;

namespace MusicApp.Data.Configurations
{
    public class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder
                .HasKey(p => p.PlaylistId);

            builder
                .Property(p => p.PlaylistId)
                .UseIdentityColumn();

            builder
                .Property(p => p.PlaylistId)
                .ValueGeneratedOnAdd();

            builder
                .HasIndex(p => p.Name);

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(p => p.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .Property(p => p.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(p => p.ConcurrencyStamp)
                .IsRequired()
                .IsRowVersion();

            builder
                .Property(p => p.ModifiedDateTime)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder
                .Property(p => p.CreatedDateTime)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder
                .ToTable("Playlists");
        }
    }
}
