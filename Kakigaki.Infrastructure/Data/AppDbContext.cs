using System;
using System.Collections.Generic;
using Kakigaki.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Kakigaki.Infrastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<category> categories { get; set; }

    public virtual DbSet<lesson> lessons { get; set; }

    public virtual DbSet<lesson_detail> lesson_details { get; set; }

    public virtual DbSet<lesson_session> lesson_sessions { get; set; }

    public virtual DbSet<lesson_translation> lesson_translations { get; set; }

    public virtual DbSet<level> levels { get; set; }

    public virtual DbSet<refresh_token> refresh_tokens { get; set; }

    public virtual DbSet<user> users { get; set; }

    public virtual DbSet<user_daily_activity> user_daily_activities { get; set; }

    public virtual DbSet<user_statistic> user_statistics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Japanese_CI_AS");

        modelBuilder.Entity<category>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__categori__3213E83FCC1B992C");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.description).HasColumnType("text");
            entity.Property(e => e.name).HasMaxLength(255);
        });

        modelBuilder.Entity<lesson>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__lessons__3213E83FE77864FE");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.audio_url).HasMaxLength(255);
            entity.Property(e => e.content).HasColumnType("text");
            entity.Property(e => e.created_at).HasColumnType("datetime");
            entity.Property(e => e.title).HasMaxLength(255);

            entity.HasOne(d => d.category).WithMany(p => p.lessons)
                .HasForeignKey(d => d.category_id)
                .HasConstraintName("FK__lessons__categor__398D8EEE");

            entity.HasOne(d => d.level).WithMany(p => p.lessons)
                .HasForeignKey(d => d.level_id)
                .HasConstraintName("FK__lessons__level_i__3A81B327");
        });

        modelBuilder.Entity<lesson_detail>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__lesson_d__3213E83FB914C0C0");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.transcript).HasColumnType("text");

            entity.HasOne(d => d.lesson).WithMany(p => p.lesson_details)
                .HasForeignKey(d => d.lesson_id)
                .HasConstraintName("FK__lesson_de__lesso__3B75D760");
        });

        modelBuilder.Entity<lesson_session>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__lesson_s__3213E83F26A99959");

            entity.Property(e => e.id).ValueGeneratedNever();

            entity.HasOne(d => d.lesson).WithMany(p => p.lesson_sessions)
                .HasForeignKey(d => d.lesson_id)
                .HasConstraintName("FK__lesson_se__lesso__3E52440B");

            entity.HasOne(d => d.user).WithMany(p => p.lesson_sessions)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__lesson_se__user___3D5E1FD2");
        });

        modelBuilder.Entity<lesson_translation>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__lesson_t__3213E83FB0806BB6");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.language_code).HasMaxLength(255);
            entity.Property(e => e.translation).HasColumnType("text");

            entity.HasOne(d => d.lesson_detail).WithMany(p => p.lesson_translations)
                .HasForeignKey(d => d.lesson_detail_id)
                .HasConstraintName("FK__lesson_tr__lesso__3C69FB99");
        });

        modelBuilder.Entity<level>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__levels__3213E83F288D7FC8");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.description).HasColumnType("text");
            entity.Property(e => e.name).HasMaxLength(255);
        });

        modelBuilder.Entity<refresh_token>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__refresh___3213E83F385A52FB");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.expires_at).HasColumnType("datetime");
            entity.Property(e => e.issued_at).HasColumnType("datetime");
            entity.Property(e => e.refresh_token1)
                .HasMaxLength(255)
                .HasColumnName("refresh_token");

            entity.HasOne(d => d.user).WithMany(p => p.refresh_tokens)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__refresh_t__user___36B12243");
        });

        modelBuilder.Entity<user>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__users__3213E83F46AE62B6");

            entity.HasIndex(e => e.email, "UQ__users__AB6E61643258791A").IsUnique();

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.created_at).HasColumnType("datetime");
            entity.Property(e => e.displayname).HasMaxLength(255);
            entity.Property(e => e.email).HasMaxLength(255);
            entity.Property(e => e.google_id).HasMaxLength(255);
            entity.Property(e => e.password_hash).HasMaxLength(255);
            entity.Property(e => e.updated_at).HasColumnType("datetime");
        });

        modelBuilder.Entity<user_daily_activity>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__user_dai__3213E83F1BA5A5B6");

            entity.ToTable("user_daily_activity");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.activity_date).HasColumnType("datetime");
            entity.Property(e => e.created_at).HasColumnType("datetime");

            entity.HasOne(d => d.user).WithMany(p => p.user_daily_activities)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__user_dail__user___38996AB5");
        });

        modelBuilder.Entity<user_statistic>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__user_sta__3213E83FBACC3BEC");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.last_login_date).HasColumnType("datetime");

            entity.HasOne(d => d.user).WithMany(p => p.user_statistics)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__user_stat__user___37A5467C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
