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
    public class Job_Configuration : IEntityTypeConfiguration<Job_Infra>
    {
        public void Configure(EntityTypeBuilder<Job_Infra> builder)
        {
            builder.ToTable("Jobs");

            builder.HasKey(_ => _.Id);
        }
    }
}