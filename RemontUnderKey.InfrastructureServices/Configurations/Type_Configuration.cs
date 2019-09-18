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
    public class Type_Configuration : IEntityTypeConfiguration<TypeOfObject_Infra>
    {
        public void Configure(EntityTypeBuilder<TypeOfObject_Infra> builder)
        {
            builder.ToTable("Types");

            builder.HasKey(_ => _.Id);
        }
    }
}