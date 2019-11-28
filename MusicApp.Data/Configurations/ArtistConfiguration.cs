using System;
using Microsoft.EntityFrameworkCore;
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
                .ToTable("Artists");
        }
    }
}
