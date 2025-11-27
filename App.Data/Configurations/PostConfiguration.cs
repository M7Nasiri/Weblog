using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace App.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<PostAgg>
    {
        public void Configure(EntityTypeBuilder<PostAgg> builder)
        {
            builder.HasQueryFilter(p => !p.IsDelete);
        }
    }
}
