using System;
using Microsoft.EntityFrameworkCore;
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
                .ToTable("Playlists");
        }
    }
}
