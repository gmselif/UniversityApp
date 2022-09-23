using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace UniversityApp
{
    public partial class ContextDB : DbContext
    {
        public ContextDB()
            : base("name=ContextDB")
        {
        }

        public virtual DbSet<tCourse> tCourse { get; set; }
        public virtual DbSet<tDepartment> tDepartment { get; set; }
        public virtual DbSet<tFaculty> tFaculty { get; set; }
        public virtual DbSet<tInstructor> tInstructor { get; set; }
        public virtual DbSet<tStudent> tStudent { get; set; }
        public virtual DbSet<tStudentCourse> tStudentCourse { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tCourse>()
                .Property(e => e.courseName)
                .IsUnicode(false);

            modelBuilder.Entity<tCourse>()
                .HasMany(e => e.tStudentCourse)
                .WithRequired(e => e.tCourse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tDepartment>()
                .Property(e => e.depName)
                .IsUnicode(false);

            modelBuilder.Entity<tDepartment>()
                .HasMany(e => e.tCourse)
                .WithRequired(e => e.tDepartment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tDepartment>()
                .HasMany(e => e.tStudent)
                .WithRequired(e => e.tDepartment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tFaculty>()
                .Property(e => e.facultyName)
                .IsUnicode(false);

            modelBuilder.Entity<tFaculty>()
                .HasMany(e => e.tDepartment)
                .WithRequired(e => e.tFaculty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tInstructor>()
                .Property(e => e.insName)
                .IsUnicode(false);

            modelBuilder.Entity<tInstructor>()
                .Property(e => e.insLastname)
                .IsUnicode(false);

            modelBuilder.Entity<tInstructor>()
                .HasMany(e => e.tCourse)
                .WithRequired(e => e.tInstructor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tStudent>()
                .Property(e => e.studentFname)
                .IsUnicode(false);

            modelBuilder.Entity<tStudent>()
                .Property(e => e.studentLname)
                .IsUnicode(false);

            modelBuilder.Entity<tStudent>()
                .HasMany(e => e.tStudentCourse)
                .WithRequired(e => e.tStudent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tStudentCourse>()
                .Property(e => e.year)
                .IsUnicode(false);

            modelBuilder.Entity<tStudentCourse>()
                .Property(e => e.semester)
                .IsUnicode(false);

            modelBuilder.Entity<tStudentCourse>()
                .Property(e => e.midterm)
                .IsUnicode(false);

            modelBuilder.Entity<tStudentCourse>()
                .Property(e => e.final)
                .IsUnicode(false);
        }
    }
}
