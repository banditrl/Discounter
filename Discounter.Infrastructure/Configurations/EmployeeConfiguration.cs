using Discounter.Domain.Entities;
using Discounter.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Discounter.Infrastructure.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.Property(e => e.EmployeeType)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnType("varchar(11)")
                .HasConversion(v =>
                    v.ToString(),
                    v => (EmployeeType)Enum.Parse(typeof(EmployeeType), v)
                );
        }
    }
}
