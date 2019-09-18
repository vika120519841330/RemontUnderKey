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
    public class Kind_Configuration : IEntityTypeConfiguration<KindOfJob_Infra>
    {
        public void Configure(EntityTypeBuilder<KindOfJob_Infra> builder)
        {
            builder.ToTable("Kinds");

            builder.HasKey(_ => _.Id);
        }
    }
}