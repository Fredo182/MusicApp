using System;
using Microsoft.EntityFrameworkCore;
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
                .ToTable("Songs");
        }
    }
}
