using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Data.Domain;

namespace MusicApp.Data.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder
                .HasKey(g => g.GenreId);

            builder
                .Property(g => g.GenreId)
                .UseIdentityColumn();

            builder
                .Property(g => g.GenreId)
                .ValueGeneratedOnAdd();

            builder
                .HasIndex(g => g.Name)
                .IsUnique();

            builder
                .Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(g => g.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .Property(g => g.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(g => g.ConcurrencyStamp)
                .IsRequired()
                .IsRowVersion();

            builder
                .Property(g => g.ModifiedDateTime)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder
                .Property(g => g.CreatedDateTime)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder
                .ToTable("Genres");
        }
    }
}
