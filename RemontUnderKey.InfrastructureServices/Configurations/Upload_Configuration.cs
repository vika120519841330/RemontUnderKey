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
    public class Upload_Configuration : IEntityTypeConfiguration<Upload_Infra>
    {
        public void Configure(EntityTypeBuilder<Upload_Infra> builder)
        {
            builder.ToTable("Uploads");

            builder.HasKey(_ => _.Id);
        }
    }
}