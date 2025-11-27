using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<CommentAgg>
    {
        public void Configure(EntityTypeBuilder<CommentAgg> builder)
        {
            builder.HasQueryFilter(c => !c.Post.IsDelete);
        }
    }
}
