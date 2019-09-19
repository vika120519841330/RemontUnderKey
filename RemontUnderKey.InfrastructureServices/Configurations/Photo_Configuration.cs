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
    public class Photo_Configuration : IEntityTypeConfiguration<Photo_Infra>
    {
        public void Configure(EntityTypeBuilder<Photo_Infra> builder)
        {
            builder.ToTable("Photos");

            builder.HasKey(_ => _.Id);
        }
    }
}