namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class StudentSystemContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configurations.ConnectionString);
            }

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Student
            builder.Entity<Student>(
                s =>
                {
                    s.Property(st => st.Name).HasColumnType("nvarchar(100)");

                    s.Property(st => st.PhoneNumber).HasColumnType("CHAR(10)").IsUnicode(false).IsRequired(false);

                    s.Property(st => st.Birthday).IsRequired(false);

                    //s.HasMany(st => st.CourseEnrollments)
                    //    .WithOne(ce => ce.Student)
                    //    .HasForeignKey(h => h.StudentId)
                    //    .OnDelete(DeleteBehavior.Restrict);

                    //s.HasMany(st => st.HomeworkSubmissions)
                    //    .WithOne(h => h.Student)
                    //    .HasForeignKey(h => h.StudentId)
                    //    .OnDelete(DeleteBehavior.Restrict);

                    s.ToTable("Students");
                });

            #endregion

            #region Course

            builder.Entity<Course>(
                c =>
                {
                    c.Property(co => co.Name).HasColumnType("NVARCHAR(80)");

                    c.Property(co => co.Description).IsUnicode(true).IsRequired(false);

                    //c.HasMany(co => co.StudentsEnrolled)
                    //    .WithOne(sc => sc.Course)
                    //    .OnDelete(DeleteBehavior.Restrict);

                    //c.HasMany(co => co.Resources)
                    //    .WithOne(r => r.Course)
                    //    .HasForeignKey(r => r.CourseId);

                    //c.HasMany(co => co.HomeworkSubmissions)
                    //    .WithOne(h => h.Course)
                    //    .HasForeignKey(hm => hm.CourseId);

                    c.ToTable("Courses");
                });

            #endregion

            #region Homework
            builder.Entity<Homework>(entity =>
            {
                entity.Property(s => s.Content)
                    .IsUnicode(false);

                entity.HasOne(h => h.Student)
                    .WithMany(s => s.HomeworkSubmissions)
                    .HasForeignKey(h => h.StudentId);

                entity.HasOne(h => h.Course)
                    .WithMany(c => c.HomeworkSubmissions)
                    .HasForeignKey(h => h.CourseId);

                entity.ToTable("HomeworkSubmissions");
            });

            #endregion

            #region Resource
            builder.Entity<Resource>(
                r =>
                {
                    r.Property(re => re.Name).HasColumnType("NVARCHAR(50)");
                    r.Property(re => re.Url).IsUnicode(false);

                    r.HasOne(re => re.Course)
                        .WithMany(c => c.Resources)
                        .HasForeignKey(re => re.CourseId);

                    r.ToTable("Resources"); 
                });

            #endregion

            #region studentsCourses

            builder.Entity<StudentCourse>(e =>
            {
                e.HasKey(
                    a => new
                    {
                        a.StudentId, a.CourseId
                    });


                e.ToTable("StudentCourses");


                e
                .HasOne(sc => sc.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

                e
                .HasOne(sc => sc.Course)
                .WithMany(s => s.StudentsEnrolled)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.Restrict);



            });
            
            #endregion

            // to fix overlaps ?


        }
    }
}