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

        public DbSet<Genre> Genres { get; set; }

        public DbSet<ArtistGenre> ArtistGenres { get; set; }

        public DbSet<Playlist> Playlists { get; set; }


        public MusicAppDbContext(DbContextOptions<MusicAppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API model configuration below. Some things can only be configured through Fluent API.
            // Check Documention for these scenarios such as indexes

            // e.g
            //...
            //...

            modelBuilder
                .ApplyConfiguration(new ArtistConfiguration());

            modelBuilder
                .ApplyConfiguration(new AlbumConfiguration());

            modelBuilder
                .ApplyConfiguration(new SongConfiguration());

            modelBuilder
                .ApplyConfiguration(new GenreConfiguration());

            modelBuilder
                .ApplyConfiguration(new ArtistGenreConfiguration());

            modelBuilder
                .ApplyConfiguration(new PlaylistConfiguration());

        }
        

    }
}
