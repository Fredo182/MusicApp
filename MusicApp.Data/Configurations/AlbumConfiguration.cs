using System;
using Microsoft.EntityFrameworkCore;
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

            //builder
            //    .HasOne(a => a.Artist)
            //    .WithMany(ar => ar.Albums)
            //    .HasForeignKey(a => a.ArtistId)
            //    .IsRequired();
                

            builder
                .ToTable("Albums");
        }
    }
}
