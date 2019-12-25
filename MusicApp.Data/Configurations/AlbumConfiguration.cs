using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Data.Domain;

namespace MusicApp.Data.Configurations
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder
                .HasKey(a => a.AlbumId);

            builder
                .Property(a => a.AlbumId)
                .UseIdentityColumn();

            builder
                .Property(a => a.AlbumId)
                .ValueGeneratedOnAdd();

            builder
                .HasIndex(a => new { a.ArtistId, a.Name })
                .IsUnique();
            
            builder
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .HasOne(a => a.Artist)
                .WithMany(ar => ar.Albums)
                .HasForeignKey(a => a.ArtistId)
                .IsRequired();

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
                .ToTable("Albums");
        }
    }
}
