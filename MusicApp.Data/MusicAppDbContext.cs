using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data.Configurations;
using MusicApp.Data.Configurations.Authorization;
using MusicApp.Data.Domain;
using MusicApp.Data.Domain.Authorization;

namespace MusicApp.Data
{
    public class MusicAppDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<ArtistGenre> ArtistGenres { get; set; }

        public DbSet<Playlist> Playlists { get; set; }


        public MusicAppDbContext(DbContextOptions<MusicAppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Call the OnModelCreating for the base Identity tables
            base.OnModelCreating(builder);

            // Fluent API model configuration below. Some things can only be configured through Fluent API.
            // Check Documention for these scenarios such as indexes

            // e.g
            //...
            //...

            // Authorization
            builder
                .ApplyConfiguration(new UserConfiguration());
            builder
                .ApplyConfiguration(new RoleConfiguration());
            builder
                .ApplyConfiguration(new UserRoleConfiguration());
            builder
                .ApplyConfiguration(new UserClaimConfiguration());
            builder
                .ApplyConfiguration(new UserLoginConfiguration());
            builder
                .ApplyConfiguration(new UserTokenConfiguration());
            builder
                .ApplyConfiguration(new RoleClaimConfiguration());
            builder
                .ApplyConfiguration(new UserRefreshTokenConfiguration());


            builder
                .ApplyConfiguration(new ArtistConfiguration());
            builder
                .ApplyConfiguration(new AlbumConfiguration());
            builder
                .ApplyConfiguration(new SongConfiguration());
            builder
                .ApplyConfiguration(new GenreConfiguration());
            builder
                .ApplyConfiguration(new ArtistGenreConfiguration());
            builder
                .ApplyConfiguration(new PlaylistConfiguration());
        }
        

    }
}
