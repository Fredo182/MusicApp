using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Data.Domain;

namespace MusicApp.Data.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder
                .HasKey(s => s.SongId);

            builder
                .Property(s => s.SongId)
                .UseIdentityColumn();

            builder
                .Property(s => s.SongId)
                .ValueGeneratedOnAdd();

            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .HasOne(s => s.Album)
                .WithMany(al => al.Songs)
                .HasForeignKey(s => s.AlbumId)
                .IsRequired();

            builder
                .HasIndex(s => new { s.Name, s.AlbumId })
                .IsUnique();

            builder
                .Property(s => s.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .Property(s => s.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(s => s.ConcurrencyStamp)
                .IsRequired()
                .IsRowVersion();

            builder
                .Property(s => s.ModifiedDateTime)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder
                .Property(s => s.CreatedDateTime)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder
                .ToTable("Songs");
        }
    }
}
