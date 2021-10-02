﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Server.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AllPerson> AllPeople { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Faq> Faqs { get; set; }
        public virtual DbSet<Img> Imgs { get; set; }
        public virtual DbSet<PerformenSeminar> PerformenSeminars { get; set; }
        public virtual DbSet<Performer> Performers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionSurvey> QuestionSurveys { get; set; }
        public virtual DbSet<RegisterSeminar> RegisterSeminars { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<Seminar> Seminars { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-LP892MBM;Database=EnvironmentalSurvey;user id=sa;password=123456789");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.HasIndex(e => e.Email, "UQ__Account__A9D10534AED2EF40")
                    .IsUnique();

                entity.Property(e => e.Active).HasDefaultValueSql("((0))");

                entity.Property(e => e.Class).HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.IdPeople).HasMaxLength(250);

                entity.Property(e => e.Img).HasMaxLength(250);

                entity.Property(e => e.Password).HasMaxLength(250);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<AllPerson>(entity =>
            {
                entity.HasKey(e => e.IdPerson)
                    .HasName("PK__AllPeopl__A5D4E15BEFB7E960");

                entity.Property(e => e.IdPerson).HasMaxLength(250);

                entity.Property(e => e.Class).HasMaxLength(50);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Img).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("NAME");

                entity.Property(e => e.Position).HasMaxLength(50);
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.Property(e => e.Answer1)
                    .HasMaxLength(250)
                    .HasColumnName("Answer");

                entity.Property(e => e.Updated).HasColumnType("date");

                entity.HasOne(d => d.IdQuestionNavigation)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.IdQuestion)
                    .HasConstraintName("FK_Answer_Question");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.HasOne(d => d.IdAccNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdAcc)
                    .HasConstraintName("FK_Comment_Account");
            });

            modelBuilder.Entity<Faq>(entity =>
            {
                entity.ToTable("FAQ");

                entity.Property(e => e.AnSwer).HasMaxLength(250);

                entity.Property(e => e.Faq1)
                    .HasMaxLength(250)
                    .HasColumnName("Faq");
            });

            modelBuilder.Entity<Img>(entity =>
            {
                entity.ToTable("Img");

                entity.Property(e => e.Path).HasMaxLength(250);

                entity.HasOne(d => d.IdSeminarNavigation)
                    .WithMany(p => p.Imgs)
                    .HasForeignKey(d => d.IdSeminar)
                    .HasConstraintName("FK_Img_Serminar");
            });

            modelBuilder.Entity<PerformenSeminar>(entity =>
            {
                entity.HasKey(e => new { e.IdPerforment, e.IdSeminar })
                    .HasName("PK__Performe__80EC2C61F85622B4");

                entity.ToTable("PerformenSeminar");

                entity.HasOne(d => d.IdPerformentNavigation)
                    .WithMany(p => p.PerformenSeminars)
                    .HasForeignKey(d => d.IdPerforment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerformenSeminar_Performer");

                entity.HasOne(d => d.IdSeminarNavigation)
                    .WithMany(p => p.PerformenSeminars)
                    .HasForeignKey(d => d.IdSeminar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerformenSeminar_Seminar");
            });

            modelBuilder.Entity<Performer>(entity =>
            {
                entity.ToTable("Performer");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Img).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.Question1)
                    .HasMaxLength(250)
                    .HasColumnName("Question");

                entity.Property(e => e.Updated).HasColumnType("date");
            });

            modelBuilder.Entity<QuestionSurvey>(entity =>
            {
                entity.HasKey(e => new { e.IdQuestion, e.IdSurvey })
                    .HasName("PK__Question__E1194D41379FBCD3");

                entity.ToTable("QuestionSurvey");

                entity.Property(e => e.Updated).HasColumnType("date");

                entity.HasOne(d => d.IdQuestionNavigation)
                    .WithMany(p => p.QuestionSurveys)
                    .HasForeignKey(d => d.IdQuestion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QS_Question");

                entity.HasOne(d => d.IdSurveyNavigation)
                    .WithMany(p => p.QuestionSurveys)
                    .HasForeignKey(d => d.IdSurvey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QS_Survey");
            });

            modelBuilder.Entity<RegisterSeminar>(entity =>
            {
                entity.HasKey(e => new { e.IdAcc, e.IdSeminar })
                    .HasName("PK__Register__2CCF44CAAC29FCF4");

                entity.ToTable("RegisterSeminar");

                entity.HasOne(d => d.IdAccNavigation)
                    .WithMany(p => p.RegisterSeminars)
                    .HasForeignKey(d => d.IdAcc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegisterSeminar_Account");

                entity.HasOne(d => d.IdSeminarNavigation)
                    .WithMany(p => p.RegisterSeminars)
                    .HasForeignKey(d => d.IdSeminar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegisterSeminar_Seminar");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.HasKey(e => new { e.IdAcc, e.IdSurvey })
                    .HasName("PK__Score__1409340BF36C9FCE");

                entity.ToTable("Score");

                entity.Property(e => e.Score1).HasColumnName("Score");

                entity.HasOne(d => d.IdAccNavigation)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.IdAcc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Score_Account");

                entity.HasOne(d => d.IdSurveyNavigation)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.IdSurvey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Score_Survey");
            });

            modelBuilder.Entity<Seminar>(entity =>
            {
                entity.ToTable("Seminar");

                entity.Property(e => e.Day).HasColumnType("date");

                entity.Property(e => e.Descriptoin).HasMaxLength(500);

                entity.Property(e => e.Img).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Place).HasMaxLength(50);

                entity.Property(e => e.Presenters).HasMaxLength(250);

                entity.HasOne(d => d.PresentersNavigation)
                    .WithMany(p => p.Seminars)
                    .HasForeignKey(d => d.Presenters)
                    .HasConstraintName("FK_Seminar_AllPeople");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.ToTable("Survey");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Updated).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
