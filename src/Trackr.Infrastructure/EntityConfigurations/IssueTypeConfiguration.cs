using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Trackr.Infrastructure.Models;

namespace Trackr.Infrastructure.EntityConfigurations
{
    public class IssueTypeConfiguration : IEntityTypeConfiguration<IssueType>
    {
        public void Configure(EntityTypeBuilder<IssueType> builder)
        {
            builder.HasData(
                new IssueType { Id = Guid.NewGuid().ToString(), Name = "Bug" },
                new IssueType { Id = Guid.NewGuid().ToString(), Name = "Feature" });
        }
    }
}
