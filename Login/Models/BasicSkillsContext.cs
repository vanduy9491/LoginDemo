using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Login.Models
{
    public partial class BasicSkillsContext : IdentityDbContext<User>
    {
        

        public BasicSkillsContext(DbContextOptions<BasicSkillsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AbilityFactor> AbilityFactors { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventRegit> EventRegits { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<SchoolYear> SchoolYears { get; set; }
        public virtual DbSet<UserOfSchoolYear> UserOfSchoolYears { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ADMIN\\VANDUYSQL;Initial Catalog=BasicSkills;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AbilityFactor>(entity =>
            {
                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.SkillId).HasColumnName("Skill_id");

                entity.Property(e => e.Tags).HasMaxLength(50);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.AbilityFactorsId).HasColumnName("AbilityFactors_Id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EnventRegitsId).HasColumnName("EnventRegits_Id");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.AbilityFactors)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.AbilityFactorsId)
                    .HasConstraintName("FK_Comments_AbilityFactors");

                entity.HasOne(d => d.EnventRegits)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.EnventRegitsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_EventRegits");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_Users");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Icon).HasMaxLength(50);
            });

            modelBuilder.Entity<EventRegit>(entity =>
            {
                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.DevelopedCapacity)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EventId).HasColumnName("Event_Id");

                entity.Property(e => e.OwnAction)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PowerExerted)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.SchoolActivitie)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.SchoolYear).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.WhatWasThought)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventRegits)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventRegits_Events");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventRegits)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventRegits_Userss");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Url).HasMaxLength(250);

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK_Notifications_Comments");
            });

            modelBuilder.Entity<SchoolYear>(entity =>
            {
                entity.Property(e => e.SchoolYear1)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("SchoolYear");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Avatar)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.StudentCode)
                    .HasMaxLength(250)
                    .HasColumnName("Student_Code");
            });

            modelBuilder.Entity<UserOfSchoolYear>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.SchoolYearId });

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.SchoolYearId).HasColumnName("SchoolYear_Id");

                entity.HasOne(d => d.SchoolYear)
                    .WithMany(p => p.UserOfSchoolYears)
                    .HasForeignKey(d => d.SchoolYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserOfSchoolYears_SchoolYears");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserOfSchoolYears)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserOfSchoolYears_Userss");
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
