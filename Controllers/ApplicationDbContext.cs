using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITI_MVC_Assingment_D2.Models;

namespace ITI_MVC_Assingment_D2.Controllers
{
    public class ApplicationDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                   =>optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=ITI_MVC_D2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Trainee and Course Relationship 
            modelBuilder.Entity<Crs_Result>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Crs_Result>()
                .HasOne(x => x.Course)
                .WithMany(x => x.Crs_Results)
                .HasForeignKey(x => x.Crs_id);

            modelBuilder.Entity<Crs_Result>()
                .HasOne(x => x.Trainee)
                .WithMany(x => x.Crs_Results)
                .HasForeignKey(x => x.Trainee_id);
            #endregion

            #region trainee and department relationship
            modelBuilder.Entity<Trainee>()
                .HasOne(x => x.Department)
                .WithMany(x => x.Trainees)
                .HasForeignKey(x => x.Dept_id);
            #endregion

            #region Instructor and Department Relationship
            modelBuilder.Entity<Instructor>()
                .HasOne(x => x.Department)
                .WithMany(x => x.Instructors)
                .HasForeignKey(x => x.Dept_id);
            #endregion

            #region Course and Department Relationship
            modelBuilder.Entity<Course>()
                .HasOne(x => x.Department)
                .WithMany(x => x.Dourses)
                .HasForeignKey(x => x.Dept_id);
            #endregion

            #region Instructor and Course Relationship
            modelBuilder.Entity<Instructor>()
                .HasOne(x => x.Course)
                .WithMany(x => x.Instrctors)
                .HasForeignKey(x => x.Crs_id);
            #endregion


        }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Crs_Result> Crs_result { get; set; }
        
    }
}
