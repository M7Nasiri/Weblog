using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasQueryFilter(u => !u.IsDelete);

            builder.HasMany(u => u.WrittenPosts)
            .WithOne(p => p.Writer)
            .HasForeignKey(p => p.WriterUserId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.VerifiednPosts)
                .WithOne(p => p.Verifier)
                .HasForeignKey(p => p.VerifierUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
