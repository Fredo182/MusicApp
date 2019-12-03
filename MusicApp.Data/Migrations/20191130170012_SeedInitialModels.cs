using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicApp.Data.Migrations
{
    public partial class SeedInitialModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Artists
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('Blink 182')");
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('Green Day')");
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('Sum 41')");
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('New Found Glory')");
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('Taking Back Sunday')");
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('Sugarcult')");
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('A Day To Remember')");
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('Senses Fail')");
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('The Used')");
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('The Main')");
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('Mayday Parade')");
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('We The Kings')");
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('Yellow Card')");
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('Fall Out Boy')");
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('Valencia')");
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('Forever The Sickest Kids')");

            // Genres
            migrationBuilder
                .Sql("INSERT INTO Genres (Name) Values ('Rock')");
            migrationBuilder
                .Sql("INSERT INTO Genres (Name) Values ('Punk')");
            migrationBuilder
                .Sql("INSERT INTO Genres (Name) Values ('Alternative')");
            migrationBuilder
                .Sql("INSERT INTO Genres (Name) Values ('Country')");
            migrationBuilder
                .Sql("INSERT INTO Genres (Name) Values ('Classic')");
            migrationBuilder
                .Sql("INSERT INTO Genres (Name) Values ('Rap')");
            migrationBuilder
                .Sql("INSERT INTO Genres (Name) Values ('Hip Hop')");


            // Artist Genres
            migrationBuilder
                .Sql("INSERT INTO ArtistGenres (ArtistId, GenreId) Values ((SELECT ArtistId FROM Artists WHERE Name = 'Blink 182'), (SELECT GenreId FROM Genres WHERE Name = 'Rock'))");
            migrationBuilder
                .Sql("INSERT INTO ArtistGenres (ArtistId, GenreId) Values ((SELECT ArtistId FROM Artists WHERE Name = 'Blink 182'), (SELECT GenreId FROM Genres WHERE Name = 'Punk'))");
            migrationBuilder
                .Sql("INSERT INTO ArtistGenres (ArtistId, GenreId) Values ((SELECT ArtistId FROM Artists WHERE Name = 'Blink 182'), (SELECT GenreId FROM Genres WHERE Name = 'Alternative'))");
            migrationBuilder
                .Sql("INSERT INTO ArtistGenres (ArtistId, GenreId) Values ((SELECT ArtistId FROM Artists WHERE Name = 'Sum 41'), (SELECT GenreId FROM Genres WHERE Name = 'Punk'))");
            migrationBuilder
                .Sql("INSERT INTO ArtistGenres (ArtistId, GenreId) Values ((SELECT ArtistId FROM Artists WHERE Name = 'Sum 41'), (SELECT GenreId FROM Genres WHERE Name = 'Rock'))");
            migrationBuilder
                .Sql("INSERT INTO ArtistGenres (ArtistId, GenreId) Values ((SELECT ArtistId FROM Artists WHERE Name = 'Green Day'), (SELECT GenreId FROM Genres WHERE Name = 'Punk'))");



            //Albums
            migrationBuilder
                .Sql("INSERT INTO Albums (Name, ArtistId) Values ('Cheshire Cat', (SELECT ArtistId FROM Artists WHERE Name = 'Blink 182'))");
            migrationBuilder
                .Sql("INSERT INTO Albums (Name, ArtistId) Values ('Buddha', (SELECT ArtistId FROM Artists WHERE Name = 'Blink 182'))");
            migrationBuilder
                .Sql("INSERT INTO Albums (Name, ArtistId) Values ('Dude Ranch', (SELECT ArtistId FROM Artists WHERE Name = 'Blink 182'))");
            migrationBuilder
                .Sql("INSERT INTO Albums (Name, ArtistId) Values ('Enema Of The State', (SELECT ArtistId FROM Artists WHERE Name = 'Blink 182'))");
            migrationBuilder
                .Sql("INSERT INTO Albums (Name, ArtistId) Values ('Take Off Your Pants And Jacket', (SELECT ArtistId FROM Artists WHERE Name = 'Blink 182'))");
            migrationBuilder
                .Sql("INSERT INTO Albums (Name, ArtistId) Values ('blink-182', (SELECT ArtistId FROM Artists WHERE Name = 'Blink 182'))");
            migrationBuilder
                .Sql("INSERT INTO Albums (Name, ArtistId) Values ('Neighborhoods', (SELECT ArtistId FROM Artists WHERE Name = 'Blink 182'))");
            migrationBuilder
                .Sql("INSERT INTO Albums (Name, ArtistId) Values ('California', (SELECT ArtistId FROM Artists WHERE Name = 'Blink 182'))");
            migrationBuilder
                .Sql("INSERT INTO Albums (Name, ArtistId) Values ('NINE', (SELECT ArtistId FROM Artists WHERE Name = 'Blink 182'))");
            migrationBuilder
                .Sql("INSERT INTO Albums (Name, ArtistId) Values ('All Killer, No Filler', (SELECT ArtistId FROM Artists WHERE Name = 'Sum 41'))");
            migrationBuilder
                .Sql("INSERT INTO Albums (Name, ArtistId) Values ('Does This Look Infected?', (SELECT ArtistId FROM Artists WHERE Name = 'Sum 41'))");
            migrationBuilder
                .Sql("INSERT INTO Albums (Name, ArtistId) Values ('Chuck', (SELECT ArtistId FROM Artists WHERE Name = 'Sum 41'))");
            migrationBuilder
                .Sql("INSERT INTO Albums (Name, ArtistId) Values ('Underclass Hero', (SELECT ArtistId FROM Artists WHERE Name = 'Sum 41'))");
            migrationBuilder
                .Sql("INSERT INTO Albums (Name, ArtistId) Values ('American Idiot', (SELECT ArtistId FROM Artists WHERE Name = 'Green Day'))");
            migrationBuilder
                .Sql("INSERT INTO Albums (Name, ArtistId) Values ('Dookie', (SELECT ArtistId FROM Artists WHERE Name = 'Green Day'))");

            //Songs
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Feeling This', (SELECT AlbumId FROM Albums WHERE Name = 'blink-182'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Obvious', (SELECT AlbumId FROM Albums WHERE Name = 'blink-182'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Down', (SELECT AlbumId FROM Albums WHERE Name = 'blink-182'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Always', (SELECT AlbumId FROM Albums WHERE Name = 'blink-182'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('I Miss You', (SELECT AlbumId FROM Albums WHERE Name = 'blink-182'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Easy Target', (SELECT AlbumId FROM Albums WHERE Name = 'blink-182'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Go', (SELECT AlbumId FROM Albums WHERE Name = 'blink-182'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Dumpweed', (SELECT AlbumId FROM Albums WHERE Name = 'Enema Of The State'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Dont Leave Me', (SELECT AlbumId FROM Albums WHERE Name = 'Enema Of The State'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Going Away To College', (SELECT AlbumId FROM Albums WHERE Name = 'Enema Of The State'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Anthem', (SELECT AlbumId FROM Albums WHERE Name = 'Enema Of The State'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Whats My Age Again?', (SELECT AlbumId FROM Albums WHERE Name = 'Enema Of The State'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Aliens Exist', (SELECT AlbumId FROM Albums WHERE Name = 'Enema Of The State'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Fat Lip', (SELECT AlbumId FROM Albums WHERE Name = 'All Killer, No Filler'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Motivation', (SELECT AlbumId FROM Albums WHERE Name = 'All Killer, No Filler'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('In Too Deep', (SELECT AlbumId FROM Albums WHERE Name = 'All Killer, No Filler'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Heart Attack', (SELECT AlbumId FROM Albums WHERE Name = 'All Killer, No Filler'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Pain For Pleasure', (SELECT AlbumId FROM Albums WHERE Name = 'All Killer, No Filler'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Hell Song', (SELECT AlbumId FROM Albums WHERE Name = 'Does This Look Infected?'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Over My Head', (SELECT AlbumId FROM Albums WHERE Name = 'Does This Look Infected?'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Still Waiting', (SELECT AlbumId FROM Albums WHERE Name = 'Does This Look Infected?'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Thanks For Nothing', (SELECT AlbumId FROM Albums WHERE Name = 'Does This Look Infected?'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Were All To Blame', (SELECT AlbumId FROM Albums WHERE Name = 'Chuck'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('No Reason', (SELECT AlbumId FROM Albums WHERE Name = 'Chuck'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Pieces', (SELECT AlbumId FROM Albums WHERE Name = 'Chuck'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('American Idiot', (SELECT AlbumId FROM Albums WHERE Name = 'American Idiot'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Holiday', (SELECT AlbumId FROM Albums WHERE Name = 'American Idiot'))");
            migrationBuilder
                .Sql("INSERT INTO Songs (Name, AlbumId) Values ('Boulevard Of Broken Dreams', (SELECT AlbumId FROM Albums WHERE Name = 'American Idiot'))");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("DELETE FROM ArtistGenres");

            migrationBuilder
                .Sql("DELETE FROM Genres");

            migrationBuilder
                .Sql("DELETE FROM Songs");

            migrationBuilder
                .Sql("DELETE FROM Albums");

            migrationBuilder
                .Sql("DELETE FROM Artists");
        }
    }
}
