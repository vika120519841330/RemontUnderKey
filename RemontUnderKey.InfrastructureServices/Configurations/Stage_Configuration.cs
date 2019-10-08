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
    public class Stage_Configuration : IEntityTypeConfiguration<Stage_Infra>
    {
        public void Configure(EntityTypeBuilder<Stage_Infra> builder)
        {
            builder.ToTable("Stages");

            builder.HasKey(_ => _.Id);
        }
    }
}