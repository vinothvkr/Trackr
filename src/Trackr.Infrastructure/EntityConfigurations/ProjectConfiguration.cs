using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Trackr.Infrastructure.Models;

namespace Trackr.Infrastructure.EntityConfigurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.CreatedBy);
        }
    }
}
