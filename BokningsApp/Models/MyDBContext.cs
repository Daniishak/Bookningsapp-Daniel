using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BokningsApp;
using BokningsApp.Models;
using Microsoft.EntityFrameworkCore;

public class MyDBContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Booking> Bookings { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=tcp:bokningsapplikaktionen.database.windows.net,1433;Initial Catalog=bokning;Persist Security Info=False;User ID=daniadmin;Password=Dani1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Booking>()
         .HasIndex(u => u.bokade)
         .IsUnique();
    }

}

