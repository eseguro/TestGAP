using TestGAP.Infrastructure.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGAP.Infrastructure
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            
            builder.Entity<RiskType>(entity =>
            {
                entity.ToTable("RiskType");
                entity.HasMany(x => x.InsurancePolicies).WithOne(x => x.RiskType).OnDelete(DeleteBehavior.Cascade);

                entity.HasData(new RiskType() { RiskTypeId = 1, Description = "Bajo" },
                               new RiskType() { RiskTypeId = 2, Description = "Medio" },
                               new RiskType() { RiskTypeId = 3, Description = "Medio-Alto" },
                               new RiskType() { RiskTypeId = 4, Description = "Alto" });
            });

            builder.Entity<CoverageType>(entity =>
            {
                entity.ToTable("CoverageType");
                entity.HasData(new CoverageType() { CoverageTypeId = 1, Description = "Terremoto" },
                               new CoverageType() { CoverageTypeId = 2, Description = "Incendio" },
                               new CoverageType() { CoverageTypeId = 3, Description = "Robo" },
                               new CoverageType() { CoverageTypeId = 4, Description = "Pérdida" });
            });

            builder.Entity<InsurancePolicy>(entity =>
            {
                entity.ToTable("InsurancePolicy");
            });

            builder.Entity<InsurancePolicyCovering>(entity => {
                entity.ToTable("InsurancePolicyCovering");
                entity.HasOne(d => d.InsurancePolicy)
                    .WithMany(p => p.InsurancePolicyCoverings)
                    .HasForeignKey(d => d.InsurancePolicyId)
                    .HasConstraintName("Fk_InsurancePolicyCovering_InsurancePolicy");

                entity.HasOne(d => d.CoverageType)
                   .WithMany(p => p.InsurancePolicyCoverings)
                   .HasForeignKey(d => d.CoverageTypeId)
                   .HasConstraintName("Fk_InsurancePolicyCovering_CoverageType");
            });     

            builder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasData(new Customer() { CustomerId = 1, Name = "Juan Palacio" },
                               new Customer() { CustomerId = 2, Name = "Flora Martinez" },
                               new Customer() { CustomerId = 3, Name = "Manuela Molina" },
                               new Customer() { CustomerId = 4, Name = "Toby Tiberio" },
                               new Customer() { CustomerId = 5, Name = "Marcos Pedraza" });
            });


            builder.Entity<CustomerInsurancePolicy>(entity => {
                entity.ToTable("CustomerInsurancePolicy");
                
                entity.HasOne(d => d.InsurancePolicy)
                    .WithMany(p => p.CustomerInsurancePolicies)
                    .HasForeignKey(d => d.InsurancePolicyId)
                    .HasConstraintName("Fk_CustomerInsurancePolicy_InsurancePolicy");

                entity.HasOne(d => d.Customer)
                   .WithMany(p => p.CustomerInsurancePolicies)
                   .HasForeignKey(d => d.CustomerId)
                   .HasConstraintName("Fk_CustomerInsurancePolicy_Customer");
            });        
        }
    }
}
