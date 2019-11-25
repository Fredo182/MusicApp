using System;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data.Configurations;
using MusicApp.Data.Domain;

namespace MusicApp.Data
{
    public class MusicAppDbContext : DbContext
    {

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Song> Songs { get; set; }


        public MusicAppDbContext(DbContextOptions<MusicAppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new ArtistConfiguration());
            builder
                .ApplyConfiguration(new AlbumConfiguration());
            builder
                .ApplyConfiguration(new SongConfiguration());
        }
        

    }
}
