using System;
using System.Collections.Generic;
using Kakigaki.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Kakigaki.Infrastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<LessonDetail> LessonDetails { get; set; }

    public virtual DbSet<LessonSession> LessonSessions { get; set; }

    public virtual DbSet<LessonTranslation> LessonTranslations { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDailyActivity> UserDailyActivities { get; set; }

    public virtual DbSet<UserStatistic> UserStatistics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=kakigaki;User ID=sa;Password=Datdatdat09@;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Japanese_CI_AS");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83FF96E60E1");

            entity.ToTable("categories");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__lessons__3213E83FDE78F204");

            entity.ToTable("lessons");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AccessLevel).HasColumnName("access_level");
            entity.Property(e => e.AudioUrl)
                .HasMaxLength(255)
                .HasColumnName("audio_url");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.LevelId).HasColumnName("level_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Category).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__lessons__categor__4CA06362");

            entity.HasOne(d => d.Level).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.LevelId)
                .HasConstraintName("FK__lessons__level_i__4D94879B");
        });

        modelBuilder.Entity<LessonDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__lesson_d__3213E83FC0250A69");

            entity.ToTable("lesson_details");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.EndTimeSeconds).HasColumnName("end_time_seconds");
            entity.Property(e => e.LessonId).HasColumnName("lesson_id");
            entity.Property(e => e.LessonIdSeq).HasColumnName("lesson_id_seq");
            entity.Property(e => e.StartTimeSeconds).HasColumnName("start_time_seconds");
            entity.Property(e => e.Transcript)
                .HasColumnType("text")
                .HasColumnName("transcript");

            entity.HasOne(d => d.Lesson).WithMany(p => p.LessonDetails)
                .HasForeignKey(d => d.LessonId)
                .HasConstraintName("FK__lesson_de__lesso__4E88ABD4");
        });

        modelBuilder.Entity<LessonSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__lesson_s__3213E83FAAE42471");

            entity.ToTable("lesson_sessions");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DurationMinutes).HasColumnName("duration_minutes");
            entity.Property(e => e.LastSequence).HasColumnName("last_sequence");
            entity.Property(e => e.LessonId).HasColumnName("lesson_id");
            entity.Property(e => e.TotalCompletedTimes).HasColumnName("total_completed_times");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Lesson).WithMany(p => p.LessonSessions)
                .HasForeignKey(d => d.LessonId)
                .HasConstraintName("FK__lesson_se__lesso__5165187F");

            entity.HasOne(d => d.User).WithMany(p => p.LessonSessions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__lesson_se__user___5070F446");
        });

        modelBuilder.Entity<LessonTranslation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__lesson_t__3213E83F59CFF9CF");

            entity.ToTable("lesson_translations");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.LanguageCode)
                .HasMaxLength(255)
                .HasColumnName("language_code");
            entity.Property(e => e.LessonDetailId).HasColumnName("lesson_detail_id");
            entity.Property(e => e.Translation)
                .HasColumnType("text")
                .HasColumnName("translation");

            entity.HasOne(d => d.LessonDetail).WithMany(p => p.LessonTranslations)
                .HasForeignKey(d => d.LessonDetailId)
                .HasConstraintName("FK__lesson_tr__lesso__4F7CD00D");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__levels__3213E83F91E27F0F");

            entity.ToTable("levels");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__refresh___3213E83FC32A9AA1");

            entity.ToTable("refresh_tokens");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("datetime")
                .HasColumnName("expires_at");
            entity.Property(e => e.IssuedAt)
                .HasColumnType("datetime")
                .HasColumnName("issued_at");
            entity.Property(e => e.RefreshToken1)
                .HasMaxLength(255)
                .HasColumnName("refresh_token");
            entity.Property(e => e.Revoked).HasColumnName("revoked");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__refresh_t__user___49C3F6B7");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F0FCF202C");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ__users__AB6E6164FEBD02FC").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Displayname)
                .HasMaxLength(255)
                .HasColumnName("displayname");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.GoogleId)
                .HasMaxLength(255)
                .HasColumnName("google_id");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<UserDailyActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_dai__3213E83F870F6B06");

            entity.ToTable("user_daily_activity");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ActivityDate)
                .HasColumnType("datetime")
                .HasColumnName("activity_date");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.LessonsCompleted).HasColumnName("lessons_completed");
            entity.Property(e => e.StudyTimeMinutes).HasColumnName("study_time_minutes");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserDailyActivities)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__user_dail__user___4BAC3F29");
        });

        modelBuilder.Entity<UserStatistic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_sta__3213E83F31FF2295");

            entity.ToTable("user_statistics");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CurrentStreakDays).HasColumnName("current_streak_days");
            entity.Property(e => e.LastLoginDate)
                .HasColumnType("datetime")
                .HasColumnName("last_login_date");
            entity.Property(e => e.LongestStreakDays).HasColumnName("longest_streak_days");
            entity.Property(e => e.TotalLessonsCompleted).HasColumnName("total_lessons_completed");
            entity.Property(e => e.TotalStudyTimeMinutes).HasColumnName("total_study_time_minutes");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserStatistics)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__user_stat__user___4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
