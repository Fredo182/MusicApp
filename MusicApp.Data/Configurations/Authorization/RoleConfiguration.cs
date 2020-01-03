using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Data.Domain.Authorization;

namespace MusicApp.Data.Configurations.Authorization
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // Each Role can have many entries in the UserRole join table
            builder
                .HasMany(r => r.UserRoles)
                .WithOne(r => r.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            // Each Role can have many associated RoleClaims
            builder
                .HasMany(r => r.RoleClaims)
                .WithOne(r => r.Role)
                .HasForeignKey(rc => rc.RoleId)
                .IsRequired();

            //Overwrite the table name
            builder
                .ToTable("Roles");

            //Overwrite column names
            builder
                .Property(r => r.Id).HasColumnName("RoleId");

            builder
                .Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(r => r.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .Property(r => r.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(r => r.ModifiedDateTime)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder
                .Property(r => r.CreatedDateTime)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}
