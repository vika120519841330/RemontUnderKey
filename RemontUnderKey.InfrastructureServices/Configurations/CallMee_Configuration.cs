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
    public class CallMee_Configuration : IEntityTypeConfiguration<CallMee_Infra>
    {
        public void Configure(EntityTypeBuilder<CallMee_Infra> builder)
        {
            builder.ToTable("Calls");

            builder.HasKey(_ => _.Id);
        }
    }
}