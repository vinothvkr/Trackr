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
                new IssueType { Id = "c2028ff9-9143-4a64-9ac8-763f61357305", Name = "Bug" },
                new IssueType { Id = "e085a41b-0205-44d4-b86f-6ac09ef8b960", Name = "Feature" });
        }
    }
}
