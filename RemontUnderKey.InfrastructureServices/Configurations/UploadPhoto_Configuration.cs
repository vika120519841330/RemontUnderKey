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
    public class UploadPhoto_Configuration : IEntityTypeConfiguration<UploadPhoto_Infra>
    {
        public void Configure(EntityTypeBuilder<UploadPhoto_Infra> builder)
        {
            builder.ToTable("UploadPhotos");

            builder.HasKey(_ => _.Id);
        }
    }
}