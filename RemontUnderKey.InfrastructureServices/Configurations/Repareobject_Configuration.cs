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
    public class Repareobject_Configuration : IEntityTypeConfiguration<Repareobject_Infra>
    {
        public void Configure(EntityTypeBuilder<Repareobject_Infra> builder)
        {
            builder.ToTable("Repareobjects");

            builder.HasKey(_ => _.Id);
        }
    }
}