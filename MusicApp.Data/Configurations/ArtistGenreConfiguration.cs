using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Data.Domain;

namespace MusicApp.Data.Configurations
{
    public class ArtistGenreConfiguration : IEntityTypeConfiguration<ArtistGenre>
    {
        public void Configure(EntityTypeBuilder<ArtistGenre> builder)
        {

            builder
                .HasKey(ag => ag.ArtistGenreId);

            builder
                .Property(ag => ag.ArtistGenreId)
                .UseIdentityColumn();

            builder
                .Property(ag => ag.ArtistGenreId)
                .ValueGeneratedOnAdd();

            builder
                .HasIndex(ag => new { ag.ArtistId, ag.GenreId })
                .IsUnique();

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
                .Property(ag => ag.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .Property(ag => ag.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(ag => ag.ConcurrencyStamp)
                .IsRequired()
                .IsRowVersion();

            builder
                .Property(ag => ag.ModifiedDateTime)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder
                .Property(ag => ag.CreatedDateTime)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder
                .ToTable("ArtistGenres");
        }
    }
}
