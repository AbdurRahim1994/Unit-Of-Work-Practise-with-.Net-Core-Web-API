using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkPractise.Models;

namespace UnitOfWorkPractise.Context;

public partial class MemorandumDbContext : DbContext
{
    public MemorandumDbContext()
    {
    }

    public MemorandumDbContext(DbContextOptions<MemorandumDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Homemo> Homemos { get; set; }

    public virtual DbSet<HomemoStatus> HomemoStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DataHead;Trusted_Connection=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Homemo>(entity =>
        {
            entity.ToTable("HOMemo");

            entity.Property(e => e.HomemoId).HasColumnName("HOMemoId");
            entity.Property(e => e.BranchCode).HasMaxLength(10);
            entity.Property(e => e.TrDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<HomemoStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HOMemoStatus");

            entity.Property(e => e.BranchCode).HasMaxLength(10);
            entity.Property(e => e.PreparedDate).HasColumnType("datetime");
            entity.Property(e => e.SentDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
