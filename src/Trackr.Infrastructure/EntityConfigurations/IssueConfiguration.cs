using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Trackr.Infrastructure.Models;

namespace Trackr.Infrastructure.EntityConfigurations
{
    public class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.HasOne(x => x.Project)
                .WithMany(x => x.Issues)
                .HasForeignKey(x => x.ProjectId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Issues)
                .HasForeignKey(x => x.CreatedBy);

            builder.HasOne(x => x.IssueType)
                .WithMany(x => x.Issues)
                .HasForeignKey(x => x.IssueTypeId);
        }
    }
}
