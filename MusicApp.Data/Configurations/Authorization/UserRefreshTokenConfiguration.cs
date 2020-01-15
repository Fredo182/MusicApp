using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Data.Domain.Authorization;

namespace MusicApp.Data.Configurations.Authorization
{
    public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder
                .HasKey(ut => ut.UserRefreshTokenId);

            builder
                .Property(ut => ut.UserRefreshTokenId)
                .UseIdentityColumn();

            builder
                .Property(ut => ut.UserRefreshTokenId)
                .ValueGeneratedOnAdd();

            builder
                .HasIndex(ut => new { ut.RefreshToken, ut.JwtId })
                .IsUnique();

            builder
                .Property(ut => ut.RefreshToken)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(ut => ut.JwtId)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(ut => ut.ExpiryDate)
                .IsRequired();

            builder
                .HasOne(u => u.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey( ut => ut.UserId)
                .IsRequired();

            builder
                .Property(ut => ut.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .Property(ut => ut.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(ut => ut.ConcurrencyStamp)
                .IsRequired()
                .IsRowVersion();

            builder
                .Property(ut => ut.ModifiedDateTime)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder
                .Property(ut => ut.CreatedDateTime)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);


            builder
                .ToTable("UserRefreshTokens");
        }
    }
}
