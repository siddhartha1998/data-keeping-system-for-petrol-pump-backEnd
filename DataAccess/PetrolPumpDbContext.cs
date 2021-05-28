using data_keeping_system_for_petrol_pump.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace data_keeping_system_for_petrol_pump.DataAccess
{
  public class PetrolPumpDbContext:DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-BIEHV64;Initial Catalog=PetrolPumpDb;Integrated Security=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Customer>().ToTable("tblCustomer");
      modelBuilder.Entity<Sales>().ToTable("tblSales");
    }
    public DbSet<Customer> customers { get; set; }
    public DbSet<Sales> sales { get; set; }
  }
}
