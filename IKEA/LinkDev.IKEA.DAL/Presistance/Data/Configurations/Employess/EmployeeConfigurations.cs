using LinkDev.IKEA.DAL.Common.Enums;
using LinkDev.IKEA.DAL.Entites.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Presistance.Data.Configurations.Employess
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("VarChar(50)").IsRequired();
            builder.Property(E => E.Address).HasColumnType("VarChar(50)");
            builder.Property(E => E.Salary).HasColumnType("Decimal(8,2)");
            builder.Property(E => E.Gender).HasConversion(
                (gender) => gender.ToString(),
                (gender) => (Gender) Enum.Parse(typeof(Gender), gender)
            );
            builder.Property(E => E.EmployeeType).HasConversion(
               (empType) => empType.ToString(),
               (empType) => (EmployeeType) Enum.Parse(typeof(EmployeeType), empType)
           );
            builder.Property(E => E.CreatedOn).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
