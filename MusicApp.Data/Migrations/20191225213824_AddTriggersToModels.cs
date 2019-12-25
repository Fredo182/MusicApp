using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicApp.Data.Migrations
{
    public partial class AddTriggersToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TRIGGER [dbo].[Album_UPDATE] ON [dbo].[Albums] " +
                "FOR INSERT, UPDATE AS " +
                "BEGIN " +
                    "SET NOCOUNT ON; " +

                    "IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN; " +

                    "DECLARE @Id INT " +

                    "SELECT @Id = INSERTED.AlbumId " +
                    "FROM INSERTED " +

                    "UPDATE dbo.Albums " +
                    "SET ModifiedDateTime = SYSDATETIMEOFFSET() " +
                    "WHERE AlbumId = @Id " +
                "END"
                );

            migrationBuilder.Sql("CREATE TRIGGER [dbo].[Artist_UPDATE] ON [dbo].[Artists] " +
                "FOR INSERT, UPDATE AS " +
                "BEGIN " +
                    "SET NOCOUNT ON; " +

                    "IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN; " +

                    "DECLARE @Id INT " +

                    "SELECT @Id = INSERTED.ArtistId " +
                    "FROM INSERTED " +

                    "UPDATE dbo.Artists " +
                    "SET ModifiedDateTime = SYSDATETIMEOFFSET() " +
                    "WHERE ArtistId = @Id " +
                "END"
                );

            migrationBuilder.Sql("CREATE TRIGGER [dbo].[ArtistGenre_UPDATE] ON [dbo].[ArtistGenres] " +
                "FOR INSERT, UPDATE AS " +
                "BEGIN " +
                    "SET NOCOUNT ON; " +

                    "IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN; " +

                    "DECLARE @Id INT " +

                    "SELECT @Id = INSERTED.ArtistGenreId " +
                    "FROM INSERTED " +

                    "UPDATE dbo.ArtistGenres " +
                    "SET ModifiedDateTime = SYSDATETIMEOFFSET() " +
                    "WHERE ArtistGenreId = @Id " +
                "END"
                );

            migrationBuilder.Sql("CREATE TRIGGER [dbo].[Genre_UPDATE] ON [dbo].[Genres] " +
                "FOR INSERT, UPDATE AS " +
                "BEGIN " +
                    "SET NOCOUNT ON; " +

                    "IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN; " +

                    "DECLARE @Id INT " +

                    "SELECT @Id = INSERTED.GenreId " +
                    "FROM INSERTED " +

                    "UPDATE dbo.Genres " +
                    "SET ModifiedDateTime = SYSDATETIMEOFFSET() " +
                    "WHERE GenreId = @Id " +
                "END"
                );

            migrationBuilder.Sql("CREATE TRIGGER [dbo].[Playlist_UPDATE] ON [dbo].[Playlists] " +
                "FOR INSERT, UPDATE AS " +
                "BEGIN " +
                    "SET NOCOUNT ON; " +

                    "IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN; " +

                    "DECLARE @Id INT " +

                    "SELECT @Id = INSERTED.PlaylistId " +
                    "FROM INSERTED " +

                    "UPDATE dbo.Playlists " +
                    "SET ModifiedDateTime = SYSDATETIMEOFFSET() " +
                    "WHERE PlaylistId = @Id " +
                "END"
                );

            migrationBuilder.Sql("CREATE TRIGGER [dbo].[Song_UPDATE] ON [dbo].[Songs] " +
                "FOR INSERT, UPDATE AS " +
                "BEGIN " +
                    "SET NOCOUNT ON; " +

                    "IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN; " +

                    "DECLARE @Id INT " +

                    "SELECT @Id = INSERTED.SongId " +
                    "FROM INSERTED " +

                    "UPDATE dbo.Songs " +
                    "SET ModifiedDateTime = SYSDATETIMEOFFSET() " +
                    "WHERE SongId = @Id " +
                "END"
                );



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER [dbo].[Album_UPDATE]");
            migrationBuilder.Sql("DROP TRIGGER [dbo].[Artist_UPDATE]");
            migrationBuilder.Sql("DROP TRIGGER [dbo].[ArtistGenre_UPDATE]");
            migrationBuilder.Sql("DROP TRIGGER [dbo].[Genre_UPDATE]");
            migrationBuilder.Sql("DROP TRIGGER [dbo].[Playlist_UPDATE]");
            migrationBuilder.Sql("DROP TRIGGER [dbo].[Song_UPDATE]");
        }
    }
}
