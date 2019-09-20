using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RemontUnderKey.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.InfrastructureServices.Configurations
{
    public class Comment_Configuration : IEntityTypeConfiguration<Comment_Infra>
    {
        public void Configure(EntityTypeBuilder<Comment_Infra> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(_ => _.Id);
        }
    }
}