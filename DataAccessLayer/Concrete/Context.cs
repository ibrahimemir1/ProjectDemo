using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
            ("server=NB341127C9524;Database=ProjectDb;integrated security=True;Encrypt=False;");
        }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Process> Processs { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Appointment ile Customer arasında bire-çok ilişki
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.Customer_Id)
                .OnDelete(DeleteBehavior.NoAction);

            // Appointment ile Employee arasında bire-çok ilişki
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.Appointments)
                .HasForeignKey(a => a.Employee_Id)
                .OnDelete(DeleteBehavior.NoAction);

            // Process ile Customer arasında bire-çok ilişki
            modelBuilder.Entity<Process>()
                .HasOne(p => p.Customer)
                .WithMany(c => c.Processes)
                .HasForeignKey(p => p.Customer_Id)
                .OnDelete(DeleteBehavior.NoAction);

            // Process ile Employee arasında bire-çok ilişki
            modelBuilder.Entity<Process>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.Processes)
                .HasForeignKey(p => p.Employee_Id)
                .OnDelete(DeleteBehavior.NoAction);

            // Employee ile Branch arasında bire-çok ilişki
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Branch)
                .WithMany(b => b.Employees)
                .HasForeignKey(e => e.Branch_Id)
                .OnDelete(DeleteBehavior.NoAction);

            // Customer ile Branch arasında bire-çok ilişki
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Branch)
                .WithMany(b => b.Customers)
                .HasForeignKey(c => c.Branch_Id)
                .OnDelete(DeleteBehavior.NoAction);
                 base.OnModelCreating(modelBuilder);
        }
    }
}


