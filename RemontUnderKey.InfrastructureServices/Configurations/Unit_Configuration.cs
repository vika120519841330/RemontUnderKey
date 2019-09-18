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
    public class Unit_Configuration : IEntityTypeConfiguration<UnitOfJob_Infra>
    {
        public void Configure(EntityTypeBuilder<UnitOfJob_Infra> builder)
        {
            builder.ToTable("Units");

            builder.HasKey(_ => _.Id);
        }
    }
}