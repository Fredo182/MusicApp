using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Data.Domain.Authorization;

namespace MusicApp.Data.Configurations.Authorization
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Each User can have many UserClaims
            builder
                .HasMany(u => u.Claims)
                .WithOne(u => u.User)
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();

            // Each User can have many UserLogins
            builder
                .HasMany(u => u.Logins)
                .WithOne(u => u.User)
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();

            // Each User can have many UserTokens
            builder
                .HasMany(u => u.Tokens)
                .WithOne(u => u.User)
                .HasForeignKey(ut => ut.UserId)
                .IsRequired();

            // Each User can have many entries in the UserRole join table
            builder
                .HasMany(u => u.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            // Each User can have many RefreshTokens
            builder
                .HasMany(u => u.RefreshTokens)
                .WithOne(ut => ut.User)
                .HasForeignKey(ut => ut.UserId)
                .IsRequired();

            //Overwrite the table name
            builder
                .ToTable("Users");

            //Overwrite column names
            builder
                .Property(u => u.Id).HasColumnName("UserId");

            builder
                .Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(u => u.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .Property(u => u.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(u => u.ModifiedDateTime)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder
                .Property(u => u.CreatedDateTime)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}
