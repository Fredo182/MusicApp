using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Data.Domain;

namespace MusicApp.Data.Configurations
{
    public class ArtistGenreConfiguration : IEntityTypeConfiguration<ArtistGenre>
    {
        public void Configure(EntityTypeBuilder<ArtistGenre> builder)
        {
            builder
                .HasKey(ag => new { ag.ArtistId, ag.GenreId });

            builder
                .HasOne(ag => ag.Artist)
                .WithMany(a => a.ArtistGenres)
                .HasForeignKey(ag => ag.ArtistId)
                .IsRequired();

            builder
                .HasOne(ag => ag.Genre)
                .WithMany(g => g.ArtistGenres)
                .HasForeignKey(ag => ag.GenreId)
                .IsRequired();

            builder
                .HasIndex(ag => new { ag.ArtistId, ag.GenreId })
                .IsUnique();

            builder
                .ToTable("ArtistGenres");
        }
    }
}
