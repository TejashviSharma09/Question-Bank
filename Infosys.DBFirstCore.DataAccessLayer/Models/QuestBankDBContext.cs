using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Infosys.DBFirstCore.DataAccessLayer.Models
{
    public partial class QuestBankDBContext : DbContext
    {
        public QuestBankDBContext()
        {
        }

        public QuestBankDBContext(DbContextOptions<QuestBankDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CreditPoint> CreditPoints { get; set; } = null!;
        public virtual DbSet<DifficultyLvL> DifficultyLvLs { get; set; } = null!;
        public virtual DbSet<EmpSkillSet> EmpSkillSets { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Mcqanswer> Mcqanswers { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<QuestionType> QuestionTypes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<SkillCategory> SkillCategories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json");

            var config = builder.Build();
            var connectionString = config.GetConnectionString("QuestBankDBConnectionString");
            

            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                 optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=QuestBankDB;Trusted_Connection=True;User Id=SA;Password=MS@password;Integrated Security=false;");
            
                optionsBuilder.UseSqlServer(connectionString);
            
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditPoint>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.HasOne(d => d.Emp)
                    .WithMany()
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__CreditPoi__EmpID__3E52440B");
            });

            modelBuilder.Entity<DifficultyLvL>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DifficultyLvL");

                entity.Property(e => e.QuesId).HasColumnName("QuesID");

                entity.HasOne(d => d.Ques)
                    .WithMany()
                    .HasForeignKey(d => d.QuesId)
                    .HasConstraintName("FK__Difficult__QuesI__3C69FB99");
            });

            modelBuilder.Entity<EmpSkillSet>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EmpSkillSet");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.SkillId).HasColumnName("SkillID");

                entity.HasOne(d => d.Emp)
                    .WithMany()
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__EmpSkillS__EmpID__2D27B809");

                entity.HasOne(d => d.Skill)
                    .WithMany()
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK__EmpSkillS__Skill__2E1BDC42");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__AF2DBA792FFF7CDC");

                entity.ToTable("Employee");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Employee__RoleID__267ABA7A");
            });

            modelBuilder.Entity<Mcqanswer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MCQAnswers");

                entity.Property(e => e.Answer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Option1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Option2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Option3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Option4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Option5)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.HasOne(d => d.Question)
                    .WithMany()
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__MCQAnswer__Quest__3A81B327");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.QuesId)
                    .HasName("PK__Question__5F3F5F1453FB5D7F");

                entity.Property(e => e.QuesId).HasColumnName("QuesID");

                entity.Property(e => e.ContributorId).HasColumnName("ContributorID");

                entity.Property(e => e.QuesDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.QuesTypeId).HasColumnName("QuesTypeID");

                entity.Property(e => e.ReviewerId).HasColumnName("ReviewerID");

                entity.HasOne(d => d.Contributor)
                    .WithMany(p => p.QuestionContributors)
                    .HasForeignKey(d => d.ContributorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Questions__Contr__36B12243");

                entity.HasOne(d => d.QuesType)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuesTypeId)
                    .HasConstraintName("FK__Questions__QuesT__35BCFE0A");

                entity.HasOne(d => d.Reviewer)
                    .WithMany(p => p.QuestionReviewers)
                    .HasForeignKey(d => d.ReviewerId)
                    .HasConstraintName("FK__Questions__Revie__37A5467C");
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.HasKey(e => e.QtypeId)
                    .HasName("PK__Question__8247B34D997B9A0F");

                entity.ToTable("QuestionType");

                entity.Property(e => e.QtypeId).HasColumnName("QTypeID");

                entity.Property(e => e.Qtype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QType");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Role1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Role");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.SkillId).HasColumnName("SkillID");

                entity.Property(e => e.SkillName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.SkillCategoryNavigation)
                    .WithMany(p => p.Skills)
                    .HasForeignKey(d => d.SkillCategory)
                    .HasConstraintName("FK__Skills__SkillCat__2B3F6F97");
            });

            modelBuilder.Entity<SkillCategory>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__SkillCat__6A1C8ADA462419A1");

                entity.ToTable("SkillCategory");

                entity.Property(e => e.CatId).HasColumnName("CatID");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
