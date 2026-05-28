using EFCore_CodeFirst_Test_Example.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore_CodeFirst_Test_Example.Infrastructure;

public class DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration config) : DbContext(options)
{
    
    DbSet<Course> courses;
    DbSet<Enrollment> enrollments;
    DbSet<Student> students;
    DbSet<Professor> professors;
    DbSet<Departament> departaments;
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.HasDefaultSchema(config["DB:DefaultSchema"]);
        

        modelBuilder.Entity<Departament>(eb =>
        {
            eb.HasKey(d => d.DepartamentId);
            eb.Property(d => d.Name).HasMaxLength(100).IsRequired();
            eb.Property(d => d.FacultyBuilding).HasMaxLength(100).IsRequired();
            eb.Property(d => d.Budget).HasPrecision(10, 2).IsRequired();
            
        });

        modelBuilder.Entity<Student>(eb =>
        {
            eb.HasKey(s => s.StudentId);
            eb.Property(s => s.FirstName).HasMaxLength(100).IsRequired();
            eb.Property(s => s.LastName).HasMaxLength(100).IsRequired();
            eb.Property(s => s.Email).HasMaxLength(100).IsRequired();
            eb.Property(s => s.EnrollmentYear).IsRequired();
        });


        modelBuilder.Entity<Professor>(eb =>
        {
            eb.HasKey(p => p.ProfessorId);
            eb.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
            eb.Property(p => p.LastName).HasMaxLength(100).IsRequired();
            eb.Property(p => p.Email).HasMaxLength(100).IsRequired();

            eb.HasOne(p => p.Departament)
                .WithMany(d => d.Professors)
                .HasForeignKey(p => p.DepartmentId);



        });


        modelBuilder.Entity<Course>(eb =>
        {
            eb.HasKey(c => c.CourseId);
            eb.Property(c => c.Title).HasMaxLength(100).IsRequired();
            eb.Property(c => c.Credits).IsRequired();
            eb.Property(c => c.Semester).IsRequired();

            eb.HasOne(c => c.Professor)
                .WithMany(p => p.Courses)
                .HasForeignKey(c => c.ProfessorId);


        });


        modelBuilder.Entity<Enrollment>(eb =>
        {
            eb.HasKey(e => new { e.CourseId, e.StudentId });
            eb.Property(e => e.Grade).HasPrecision(2, 1).IsRequired(false);
            eb.Property(e => e.Status).HasMaxLength(100).IsRequired();

            eb.HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            eb.HasOne(e => e.Student)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.StudentId);
            
        });










    }
}