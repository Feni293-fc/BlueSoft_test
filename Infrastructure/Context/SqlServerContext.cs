using Domain.Aggregates.Accounts;
using Domain.Aggregates.Customers;
using Domain.Aggregates.Movements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public sealed class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AccountMapper());
            modelBuilder.ApplyConfiguration(new MovementMapper());
            modelBuilder.ApplyConfiguration(new CustomerMapper());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Initial Catalog=bluesoft_test6;Persist Security Info=False;User ID=sql;Password=fernando;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
        }
    }

    public class AccountMapper : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account", "dbo").HasKey(x => x.accountID);

            builder.Property(x => x.accountID).HasColumnName("accountID");
            builder.Property(x => x.numberAccount).HasColumnName("numberAccount");
            builder.Property(x => x.balance).HasColumnName("balance");
            builder.Property(x => x.typeAccount).HasColumnName("typeAccount");
            builder.Property(p => p.city).HasColumnName("city");
            builder.Property(p => p.customerID).HasColumnName("customerID");
        }
    }

    public class MovementMapper : IEntityTypeConfiguration<Movement>
    {
        public void Configure(EntityTypeBuilder<Movement> builder)
        {
            builder.ToTable("Movements", "dbo").HasKey(p => p.movementId);

            builder.Property(x => x.movementId).HasColumnName("movementId");
            builder.Property(x => x.typeMovement).HasColumnName("typeMovement");
            builder.Property(x => x.value).HasColumnName("value");
            builder.Property(x => x.date).HasColumnName("date");
            builder.Property(x => x.city).HasColumnName("city");
            builder.Property(x => x.customerID).HasColumnName("customerID");
            builder.Property(x => x.accountId).HasColumnName("account");
        }
    }

    public class CustomerMapper : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "dbo").HasKey(p => p.CustomerID);

            builder.Property(x => x.nameCustomer).HasColumnName("nameCustomer");
            builder.Property(x => x.CustomerType).HasColumnName("typeCustomer");
        }
    }
}
