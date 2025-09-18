using System;
using System.Collections.Generic;
using Lab_1_25.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_1_25;

public partial class SapunovaDemoContext : DbContext
{
    public SapunovaDemoContext()
    {
        Database.EnsureCreated();
    }

    public SapunovaDemoContext(DbContextOptions<SapunovaDemoContext> options)
        : base(options)
    {
        Database.EnsureCreated();

    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TEACHERPC;Initial Catalog=SapunovaDemo;User ID=user12;Password=user12;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
